using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ScheduleSystem.API.Application._1._1_IServices;
using ScheduleSystem.API.Application._1._3_Services;
using ScheduleSystem.API.Data._3._1._2_Repositories;
using ScheduleSystem.API.Data._3._1._3_UnitOfWork;
using ScheduleSystem.API.Data._3._1._4_Interfaces;
using ScheduleSystem.API.Domain._1._5_Interfaces._1._5._1_IUnitOfWork;
using ScheduleSystem.API.Domain._1._5_Interfaces._1._5._2_IRepositories;
using ScheduleSystem.API.Domain._2._4_IRepositories;
using ScheduleSystem.API.Identity;
using ScheduleSystem.API.Identity.Entities;
using ScheduleSystem.API.Infra._3._1_Context;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ScheduleSystem.API.CrossCutting
{
    public class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            #region Application
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IDbContext, ScheduleSystemContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ScheduleSystemContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"))
            );
            #endregion


            #region ## Identity
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"))
            );

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            });
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            // ===== Add Jwt Authentication ========
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = configuration["JwtIssuer"],
                        ValidAudience = configuration["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });
            #endregion

            #region Services
            services.AddScoped<IUsersService, UsersService>();
            #endregion

            #region Repositories
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUsersRepository, UsersRepository>();
            //services.AddScoped<ILogger, Logger>();
            #endregion
        }
    }
}