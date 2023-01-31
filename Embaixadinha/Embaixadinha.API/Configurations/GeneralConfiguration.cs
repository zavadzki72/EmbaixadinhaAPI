using Embaixadinha.Models.Interfaces;
using Embaixadinha.Services;

namespace Embaixadinha.API.Configurations
{
    public static class GeneralConfiguration
    {
        public static void AddGeneralConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IScoreService, ScoreService>();
        }
     }
}
