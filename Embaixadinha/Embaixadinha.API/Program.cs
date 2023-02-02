using Embaixadinha.API.Attributes;
using Embaixadinha.API.Configurations;
using Embaixadinha.API.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(options =>
    {
        options.Filters.Add(new RestrictDomainAttribute(
            "https://jogos.marccusz.com",
            "https://marccusz.com",
            "https://www.marccusz.com",
            "https://www.jogos.marccusz.com",
            "https://embaixadinha.marccusz.com",
            "https://embaixadinha.marccusz.com/",
            "https://www.embaixadinha.marccusz.com",
            "https://altinha.marccusz.com",
            "https://altinha.marccusz.com/",
            "https://www.altinha.marccusz.com",
            "localhost"
        ));
    })
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvcCore().AddDataAnnotations();

builder.Services.AddSwaggerConfiguration();
builder.Services.AddAuthenticationConfiguration(builder.Configuration);
builder.Services.AddCorsConfiguration();
builder.Services.AddEntityFrameworkConfiguration(builder.Configuration);
builder.Services.AddGeneralConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwaggerSetup();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.UseCorsConfiguration();

app.MapControllers();

app.Run();
