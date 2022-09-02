using Api.Extensions;
using Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api.Config
{
    public static class IdentityConfig
    {
        public static IServiceCollection ConfigIdentity(this IServiceCollection services,
            IConfiguration configuration)
        {
            var ConfigurationString = configuration.GetConnectionString("MySqlString");
            services.AddDbContext<IdentityAppContext>(options =>
            options.UseMySql(ConfigurationString, ServerVersion.AutoDetect(ConfigurationString)));

            services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityAppContext>()
            .AddDefaultTokenProviders();

            //JWT
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSetingsJWT>(appSettingsSection);


            var appSettings = appSettingsSection.Get<AppSetingsJWT>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.ValidoEm,
                    ValidIssuer = appSettings.Emissor
                };

            });
            //JWT
        

            return services;
        }

    }
}
