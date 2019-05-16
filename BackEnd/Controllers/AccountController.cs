using System;
using System.Linq;
using BackEnd.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using Newtonsoft.Json.Linq;
using Novell.Directory.Ldap;
using BackEnd.Configurations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using System.DirectoryServices.AccountManagement;
using Microsoft.Exchange.WebServices.Autodiscover;


namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        readonly IMemoryCache iMemoryCache;
        static Dictionary<string,string> verificationCodes = new Dictionary<string, string>();

        public AccountController(IMemoryCache iMemoryCache)
        {
            this.iMemoryCache = iMemoryCache;
        }

        [HttpPost]
        [ActionName("Authorization")]
        public async Task Authorization(Object json)
        {
            dynamic jsonDynamic = JObject.Parse(json.ToString());
            string username = jsonDynamic.username;
            string password = jsonDynamic.password;
            Response.ContentType = "application/json";
            if (CheckOutUsernameAndPassword(username, password))
                await Response.WriteAsync(JsonConvert.SerializeObject(new {access_token = GenerateToken(username, Request.HttpContext.Connection.RemoteIpAddress.ToString().Contains("10.208.") ? AuthorizationConfig.lifeTimeForAuthorizationInsideInstitute : AuthorizationConfig.lifeTimeForAuthorizationOutsideInstitute)}, new JsonSerializerSettings {Formatting = Formatting.Indented}));
            else
                await Response.WriteAsync(JsonConvert.SerializeObject(new {Response = "Invalid username or password."}, new JsonSerializerSettings {Formatting = Formatting.Indented}));
        }

        [HttpPost]
        [ActionName("ChangePassForAuthUser")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task ChangePassForAuthUser(Object json)
        {
            SprHuman[] sprHuman;
            dynamic jsonDynamic = JObject.Parse(json.ToString());
            try
            {
                string username = GetUsernameFromToken();
                string newPassword = jsonDynamic.newPassword;
                if (!iMemoryCache.TryGetValue(username, out sprHuman))
                {
                    if (!CheckOutUsernameAndPassword(username, jsonDynamic.password.ToString()) & !(GetInformationFromDatabase(username)[0].Birthday == DateTime.Parse(jsonDynamic.birthdate.ToString())) & newPassword == null)
                    {
                        await Response.WriteAsync($"Password is not changed.");
                        return;
                    }
                }
                else
                {
                    iMemoryCache.Remove(username);
                }
                using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, AuthorizationConfig.domain, AuthorizationConfig.defaultDC, AuthorizationConfig.serviceUser, AuthorizationConfig.servicePassword))
                {
                    using (UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(principalContext, IdentityType.SamAccountName, username))
                    {
                        userPrincipal.SetPassword(newPassword);
                        userPrincipal.SetPassword(newPassword);
                    }
                }
                await Authorization(JsonConvert.SerializeObject(new {username = username, password = newPassword}, new JsonSerializerSettings {Formatting = Formatting.Indented}));
            }
            catch (Exception ex)
            {
                await Response.WriteAsync($"Password is not changed. {ex.Message}");
            }
        }

        [HttpPost]
        [ActionName("SendEmailWithVerificationCode")]
        public async Task SendEmailWithVerificationCode(Object json)
        {
            string name;
            string username;
            SprHuman[] sprHuman;
            dynamic jsonDynamic = JObject.Parse(json.ToString());
            //if (!CheckOutGoogleRecaptchaToken(jsonDynamic.captcha.ToString()))
            //{
            //    await Response.WriteAsync("Is invalid recaptcha token !");
            //    return;
            //}
            AutodiscoverRedirectionUrlValidationCallback autodiscoverRedirectionUrlValidationCallback = (string redirectionUrl) => {Uri redirectionUri = new Uri(redirectionUrl); if (redirectionUri.Scheme == "https") return true; else return false;};
            Microsoft.Exchange.WebServices.Data.ExchangeService exchangeService = new Microsoft.Exchange.WebServices.Data.ExchangeService(Microsoft.Exchange.WebServices.Data.ExchangeVersion.Exchange2013_SP1);
            exchangeService.Credentials = new Microsoft.Exchange.WebServices.Data.WebCredentials(AuthorizationConfig.login, AuthorizationConfig.password);
            try
            {
                string email = jsonDynamic.email;
                DateTime birthday = DateTime.Parse(jsonDynamic.birthdate.ToString());
                sprHuman = GetInformationFromDatabase(email);
                if (birthday != sprHuman[0].Birthday)
                {
                    await Response.WriteAsync($"Email is doesn't send !");
                    return;
                }
                name = $"{sprHuman[0].FirstName} {sprHuman[0].LastName}";
                username = sprHuman[0].SamaccountName;
                Random random = new Random();
                string verificationCode = AuthorizationConfig.verificationCode;
                for (int i = 0; i <= 10; i++)
                {
                    char characterLetter = (char)random.Next('A', 'Z');
                    char characterDigit = (char)random.Next('1', '9');
                    char[] characters = { characterLetter, '~', '!', characterDigit, '@', '#', characterLetter, '$', '&', characterDigit, '*', '(', characterLetter, ')', '_', characterDigit, '+', '?', characterLetter, ':', '-', characterDigit, '=', ',', characterLetter, '.', ';', characterDigit, '[', ']', characterLetter };
                    verificationCode += $"{characters[random.Next(characters.Length)]}";
                }
                verificationCodes.Add(verificationCode, username);
                exchangeService.Timeout = 300000;
                exchangeService.AutodiscoverUrl(AuthorizationConfig.login, autodiscoverRedirectionUrlValidationCallback);
                ThreadStart threadStart = () => {Action action = () => {Thread.Sleep(300000); verificationCodes.Remove(verificationCodes[verificationCode]);};};
                Thread thread = new Thread(threadStart);
                thread.Start();
                Microsoft.Exchange.WebServices.Data.EmailMessage emailMessage = new Microsoft.Exchange.WebServices.Data.EmailMessage(exchangeService);
                emailMessage.ToRecipients.Add(email);
                emailMessage.Subject = "Hello World";
                emailMessage.Body = new Microsoft.Exchange.WebServices.Data.MessageBody($"Hello {name} ! This is the verification code {verificationCode} which you must to introduce in following link http://elk-test.iep.ru/password-reset/{GenerateToken(username, AuthorizationConfig.lifeTimeForCheckOutEmailOrChangePasswordForUnauthUser)}");
                await emailMessage.SendAndSaveCopy();
                await Response.WriteAsync("Email is sent !");
            }
            catch (Exception ex)
            {
                await Response.WriteAsync($"Email is doesn't send ! {ex.Message}");
            }
        }

        [HttpPost]
        [ActionName("CheckOutVerificationCode")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task CheckOutVerificationCode(Object json)
        {
            dynamic jsonDynamic = JObject.Parse(json.ToString());
            //if (!CheckOutGoogleRecaptchaToken(jsonDynamic.captcha.ToString()))
            //{
            //    await Response.WriteAsync("Is invalid recaptcha token !");
            //    return;
            //}
            Response.ContentType = "application/json";
            try
            {
                if (verificationCodes.ContainsKey(jsonDynamic.verificationCode.ToString()))
                {
                    await Response.WriteAsync(JsonConvert.SerializeObject(new {access_token = GenerateToken(GetUsernameFromToken(), AuthorizationConfig.lifeTimeForCheckOutEmailOrChangePasswordForUnauthUser)}, new JsonSerializerSettings {Formatting = Formatting.Indented}));
                    verificationCodes.Remove(jsonDynamic.verificationCode.ToString());
                }
            }
            catch (Exception ex)
            {
                await Response.WriteAsync(JsonConvert.SerializeObject(new {Response = "Not correct code !"}, new JsonSerializerSettings {Formatting = Formatting.Indented}));
                return;
            }
        }

        bool CheckOutUsernameAndPassword(string username, string password)
        {
            string userStuff = $"{AuthorizationConfig.userStringBegin}{username}{AuthorizationConfig.userStringStuff}";
            string userNonStaff = $"{AuthorizationConfig.userStringBegin}{username}{AuthorizationConfig.userStringNonStuff}";
            using (LdapConnection connection = new LdapConnection {SecureSocketLayer = false})
            {
                connection.ConnectionTimeout = 300000;
                connection.Connect(AuthorizationConfig.domain, LdapConnection.DEFAULT_PORT);
                try
                {
                    connection.Bind(userStuff, password);
                }
                catch (LdapException ex)
                {
                    Console.WriteLine("{0} Exception caught.", ex.Message);
                }

                try
                {
                    connection.Bind(userNonStaff, password);
                }
                catch (LdapException ex)
                {
                    Console.WriteLine("{0} Exception caught.", ex.Message);
                }

                if (connection.Bound)
                    return true;
                else
                    return false;
            }
        }

        bool CheckOutGoogleRecaptchaToken(string recaptchaToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromMinutes(5);
                try
                {
                    using (HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"https://www.google.com/recaptcha/api/siteverify?secret={AuthorizationConfig.recaptchaKey}&response={recaptchaToken}").Result)
                    {
                        string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        dynamic jsonGoogle = JObject.Parse(response);
                        if (jsonGoogle.success == "true")
                            return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} Exception caught.", ex.Message);
                }
            }
            return false;
        }

        string GenerateToken(string username, double lifetime)
        {
            Claim[] claims = new Claim[] { new Claim(ClaimsIdentity.DefaultNameClaimType, username)};
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: AuthorizationConfig.server, audience: AuthorizationConfig.issuer, notBefore: DateTime.UtcNow, claims: claimsIdentity.Claims, expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(lifetime)), signingCredentials: new SigningCredentials(AuthorizationConfig.SymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        SprHuman[] GetInformationFromDatabase(string emailOrUsername) 
        {
            using (UsersIEP_dev01Context usersIEP_Dev01Context = new UsersIEP_dev01Context())
            {
                SprHuman[] sprHuman = emailOrUsername.Contains("@") ? usersIEP_Dev01Context.SprHuman.Where(x => x.MailAddress == emailOrUsername).ToArray() : usersIEP_Dev01Context.SprHuman.Where(x => x.SamaccountName == emailOrUsername).ToArray();
                iMemoryCache.Set(sprHuman[0].SamaccountName, sprHuman, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5)));
                return sprHuman;
            }
        }

        string GetUsernameFromToken()
        {
            return (new JwtSecurityTokenHandler().ReadToken((Request.Headers.Values.ToArray())[5].ToString().Remove(0, 7)) as JwtSecurityToken).Claims.First().Value;
        }
    }

    //private ClaimsIdentity GetUser(string username, string password)
    //{
    //    List<User> users = new List<User> {new User {login = "admin@gmail.com", password = "12345", role = "admin"}, new User {login = "qwerty", password = "55555", role = "user"}};
    //    User user = users.FirstOrDefault(x => x.Login == username && x.Password == password);
    //    if (user != null)
    //    {
    //        List<Claim> claims = new List<Claim> {new Claim(ClaimsIdentity.DefaultNameClaimType, user.login), new Claim(ClaimsIdentity.DefaultRoleClaimType, user.role)};
    //        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
    //        return claimsIdentity;
    //    }
    //    return null;
    //}
}