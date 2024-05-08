using System.Security.Claims;
using DataAccess.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Extensions
{
    internal static class ServiceControllerExtensions
    {
        public static IServiceCollection AddCookiesAuthentication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    options.SlidingExpiration = true;

                    options.LoginPath = "/api/Authentication/error";
                    options.AccessDeniedPath = "/api/Authentication/error";
                });

            return serviceCollection;
        }

        public static IServiceCollection AddRoles(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.AddPolicy("Subordinate", policyBuilder =>
                {
                    AccountRole[] allowedRoles = { AccountRole.Subordinate };
                    policyBuilder
                        .RequireClaim(ClaimTypes.Role, allowedRoles.Select(x => x.ToString()))
                        .Build();
                });
                options.AddPolicy("Manager", policyBuilder =>
                {
                    AccountRole[] allowedRoles = { AccountRole.Manager };
                    policyBuilder
                        .RequireClaim(ClaimTypes.Role, allowedRoles.Select(x => x.ToString()))
                        .Build();
                });
            });
        }
    }
}
