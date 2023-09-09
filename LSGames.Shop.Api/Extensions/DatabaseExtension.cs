using LSGames.Shop.Repository.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace LSGames.Shop.Api.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection serviceCollection, IConfiguration config)
        {
            // 若有需要使用資料庫，請將下面的註解打開，並修改為正確的值
            string? connectionString = config.GetConnectionString("LSGamesShop");
            string? username = config.GetValue<string>("Credentials:LSGamesShop:Username");
            string? password = config.GetValue<string>("Credentials:LSGamesShop:Password");
            if (connectionString == null || username == null || password == null)
            {
                throw new ArgumentNullException("Connection string, Username or Password setting in appsettings.json can not be null.");
            }

            connectionString = connectionString.Replace("$USERNAME", username).Replace("$PASSWORD", password);

            MariaDbServerVersion serverVersion = new MariaDbServerVersion(new Version(10, 6, 12));

            // 完成 DB 逆向工程後，請將下列註解打開，並將 DBContext 更改為正確的類別名稱
            serviceCollection.AddDbContext<LsgamesShopContext>(options =>
                options.UseMySql(connectionString, serverVersion)
                    .LogTo(Console.WriteLine, LogLevel.Debug)
                    .EnableDetailedErrors());

            return serviceCollection;
        }
    }
}
