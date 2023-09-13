using LSGames.Shop.Api.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

CorsHandlerExtension.ConfigureCorsHeaders(builder.Services);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
}); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

SwaggerDefinitionExtensions.ConfigureSwagger(builder.Services);
ServiceMapperExtension.GetServiceProvider(builder.Services);
DatabaseExtension.AddDatabaseContext(builder.Services, builder.Configuration);
AuthorizationExtension.ConfigureAuthorization(builder.Services);
HttpClientExtension.ConfigureHttpClients(builder.Services);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger(config =>
    {
        string? path = app.Configuration.GetValue<string>("Swagger:RoutePrefix");
        if (!string.IsNullOrEmpty(path))
        {
            config.PreSerializeFilters.Add((swaggerDoc, httpRequest) =>
            {
                string httpScheme = (app.Environment.IsDevelopment()) ? httpRequest.Scheme : "https";
                swaggerDoc.Servers = new List<OpenApiServer> {
                    new OpenApiServer { Url = $"{httpScheme}://{httpRequest.Host.Value}{path}" }
                };
            });
        }
    });
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.ConfigureMiddlewares();

app.UseCors(CorsHandlerExtension.CorsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
