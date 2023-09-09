using LSGames.Shop.Api.Services;
using LSGames.Shop.Repository.Repositories;

namespace LSGames.Shop.Api.Extensions
{
    public static class ServiceMapperExtension
    {
        public static IServiceCollection? GetServiceProvider(this IServiceCollection? serviceCollection)
        {
            if (serviceCollection != null)
            {
                // Services
                serviceCollection.AddScoped<IShopService, ShopService>();

                // Repositories
                serviceCollection.AddScoped<ICartRepository, CartRepository>();
                serviceCollection.AddScoped<IGoodRepository, GoodRepository>();
            }

            return serviceCollection;
        }
    }
}
