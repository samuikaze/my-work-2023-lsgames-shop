using System.Reflection;

namespace LSGames.Shop.Api.Extensions
{
    public static class SwaggerDefinitionExtensions
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(config =>
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetEntryAssembly()?.GetName().Name}.xml");
                config.IncludeXmlComments(filePath);
                config.EnableAnnotations();
            });

            return serviceCollection;
        }
    }
}
