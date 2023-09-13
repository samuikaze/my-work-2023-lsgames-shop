using LSGames.Shop.Api.HttpClients;

namespace LSGames.Shop.Api.Extensions
{
    public static class HttpClientExtension
    {
        public static IServiceCollection ConfigureHttpClients(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient<SingleSignOnClient>();

            return serviceCollection;
        }
    }
}
