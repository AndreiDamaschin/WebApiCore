using BackEnd.Models;
using BackEnd.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace BackEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAuthorization(options => {options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();});
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {options.RequireHttpsMetadata = false; options.TokenValidationParameters = new TokenValidationParameters {ValidateIssuer = true, ValidIssuer = AuthorizationConfig.server, ValidateAudience = true, ValidAudience = AuthorizationConfig.issuer, ValidateLifetime = true, IssuerSigningKey = AuthorizationConfig.SymmetricSecurityKey(), ValidateIssuerSigningKey = true};});
            services.AddDbContext<UsersIEP_dev01Context>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionStrings")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc();

            //Если посетитель без Токена
            //app.UseExceptionHandler(appBuilder =>
            //{
            //    appBuilder.Use(async (context, next) =>
            //    {
            //        var error = context.Features[typeof(IExceptionHandlerFeature)] as IExceptionHandlerFeature;

            //        if (error != null && error.Error is SecurityTokenExpiredException)
            //        {
            //            context.Response.StatusCode = 401;
            //            context.Response.ContentType = "application/json";

            //            await context.Response.WriteAsync(JsonConvert.SerializeObject(new RequestResult
            //            {
            //                State = RequestState.NotAuth,
            //                Msg = "token expired"
            //            }));
            //        }
            //        else await next();
            //    });
            //});
        }
    }
}
