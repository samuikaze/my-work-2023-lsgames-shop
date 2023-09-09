using LSGames.Shop.Api.HttpClients;

namespace LSGames.Shop.Api.Extensions
{
    public class HttpClientExtension
    {
        public static IServiceCollection ConfigureHttpClients(IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient<SingleSignOnClient>();

            return serviceCollection;
        }
    }
}
