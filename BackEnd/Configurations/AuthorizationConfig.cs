using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace BackEnd.Configurations
{
    public class AuthorizationConfig
    {
        public const string issuer = "*";
        public const string password = "eln57DY7";
        public const string cacheName = "cacheName";
        public const string server = "MyAuthServer";
        public const string userStringBegin = "CN=";
        public const string login = "Elk@365.iep.ru";
        public const string domain = "dc-03.iet.int";
        public static string serviceUser = "svc-imb";
        public static string defaultDC = "DC=iet,DC=int";
        public static string servicePassword = "gh200ibb";
        public const string key = "mysupersecret_secretkey!123";
        public const string verificationCode = "verificationCode";
        public const double lifeTimeForAuthorizationInsideInstitute = 31;
        public const double lifeTimeForAuthorizationOutsideInstitute = 7;
        public const string recaptchaKey = "6Ldb2YkUAAAAAJnyNa8mEvhyF7mVBw6-qhS6o3Nm";
        public const double lifeTimeForCheckOutEmailOrChangePasswordForUnauthUser = 0;
        public const string userStringStuff = ",OU=IEP Staff,OU=Corp Users 365,DC=iet,DC=int";
        public const string userStringNonStuff = ",OU=IEP non Staff,OU=Corp Users 365,DC=iet,DC=int";

        public static SymmetricSecurityKey SymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
        }
    }
}
