//using LSGames.Shop.Api.Middlewares;

namespace LSGames.Shop.Api.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder ConfigureMiddlewares(this IApplicationBuilder builder)
        {
             //builder.UseMiddleware<VerifyAccessTokenMiddleware>();

            return builder;
        }
    }
}
