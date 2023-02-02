namespace Embaixadinha.API.Configurations
{
    public static class CorsConfiguration
    {

        private static readonly string[] _urls = {
            "https://jogos.marccusz.com",
            "https://marccusz.com",
            "https://www.marccusz.com",
            "https://www.jogos.marccusz.com",
            "https://embaixadinha.marccusz.com",
            "https://www.embaixadinha.marccusz.com",
            "https://altinha.marccusz.com",
            "https://altinha.marccusz.com/",
            "https://www.altinha.marccusz.com",
        };

        public static void AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("AllowOnlyMyDomains", builder => {
                    builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins(_urls)
                    .AllowCredentials();
                });
            });

            services.AddCors(options => {
                options.AddPolicy("AllowAll", builder => {
                    builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(x => true)
                    .AllowCredentials();
                });
            });
        }

        public static void UseCorsConfiguration(this IApplicationBuilder app)
        {
#if DEBUG
            app.UseCors("AllowAll");
#else
            app.UseCors("AllowOnlyMyDomains");
#endif
        }

    }
}
