using Microsoft.Extensions.DependencyInjection;
using Project.MovieStore.Application.Authentication;

namespace Project.MovieStore.Application.Authorization
{
    public static class AuthorizationConfigurationInjection
    {
        public static void AddAuthorizationConfiguration(this IServiceCollection services)
        {
            services.AddAuthorization(x =>
            {
                x.AddPolicy(nameof(PolicyGroup.CHECK_CLAIM_POLICY), policy => policy.RequireClaim(nameof(ClaimType.Id)));
                x.AddPolicy(nameof(PolicyGroup.REFRESH_TOKEN_POLICY), policy => policy.RequireClaim(nameof(ClaimType.RefreshToken)));
            }); 
        }
    }
}
