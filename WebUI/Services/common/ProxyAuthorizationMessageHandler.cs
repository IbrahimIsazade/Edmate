
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace WebUI.Services.common
{
    public class ProxyAuthorizationMessageHandler(IHttpContextAccessor ctx ) : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //if (ctx.HttpContext!.User?.Identity is { IsAuthenticated: false })
            //{
            //    ctx.HttpContext.Response.Redirect("/Account/SignIn");
            //    ctx.HttpContext.Response.StatusCode = StatusCodes.Status302Found;

            //    return new HttpResponseMessage
            //    {
            //        StatusCode = System.Net.HttpStatusCode.Redirect,
            //        RequestMessage = request
            //    };
            //}

            if (ctx.HttpContext!.Request.Cookies.TryGetValue("accessToken", out string token))
            {
                request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
