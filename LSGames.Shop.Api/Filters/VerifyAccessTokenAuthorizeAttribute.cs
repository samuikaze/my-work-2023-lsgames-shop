using LSGames.Shop.Api.HttpClients;
using LSGames.Shop.Api.Models.ServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LSGames.Shop.Api.Filters
{
    public class VerifyAccessTokenAuthorizeAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private SingleSignOnClient _singleSignOnClient;

        public VerifyAccessTokenAuthorizeAttribute(SingleSignOnClient httpClient)
        {
            _singleSignOnClient = httpClient;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var accessToken = context.HttpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(accessToken))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            UserServiceModel? authorized = await _verifyAccessToken(accessToken);

            if (authorized == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            context.HttpContext.Items["User"] = authorized;
        }

        /// <summary>
        /// 驗證存取權杖
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        private async Task<UserServiceModel?> _verifyAccessToken(string? accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                return null;
            }

            _singleSignOnClient.AddHeaders("Authorization", accessToken);

            var result = await _singleSignOnClient.VerifyAuthorization();

            if (!result.IsSuccessStatusCode)
            {
                return null;
            };

            HttpClientBaseResponseServiceModel<UserServiceModel>? response =
                await result.Content.ReadFromJsonAsync<HttpClientBaseResponseServiceModel<UserServiceModel>>();

            return (response == null) ? null : response.Data;
        }
    }
}
