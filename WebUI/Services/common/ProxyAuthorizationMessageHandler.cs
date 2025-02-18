﻿using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;
using WebUI.Models.DTOs.Account;
using WebUI.Services.Account;

namespace WebUI.Services.common
{
    public class ProxyAuthorizationMessageHandler(IActionContextAccessor ctx) : DelegatingHandler
    {
        async protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Setting token...");

            if (ctx.ActionContext.HttpContext.Request.Cookies.TryGetValue("accessToken", out string accessToken))
                request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");

            Console.WriteLine("Starting refreshing token...");

            //var language = ctx.ActionContext.HttpContext.GetRouteValue("lang")?.ToString();
            //if (!string.IsNullOrWhiteSpace(language))
            //    request.Headers.TryAddWithoutValidation("Accept-Language", language);

            var response = await base.SendAsync(request, cancellationToken);

            Console.WriteLine("Request send/ cheking for refresh...");
            if (!string.IsNullOrWhiteSpace(accessToken)
                && response.StatusCode == HttpStatusCode.Unauthorized
                && ctx.ActionContext.HttpContext.Request.Cookies.TryGetValue("refreshToken", out string refreshToken)
                && !string.IsNullOrWhiteSpace(refreshToken))
            {
                Console.WriteLine("True `if` statement");
                using (var scope = ctx.ActionContext.HttpContext.RequestServices.CreateScope())
                {
                    var accountService = scope.ServiceProvider.GetService<IAccountService>();

                    var refreshTokenRequest = new RefreshTokenRequestDto
                    {
                        AccessToken = accessToken,
                        RefreshToken = refreshToken
                    };

                    var refreshTokenResponse = await accountService.RefreshTokenAsync(refreshTokenRequest);

                    if (refreshTokenResponse.IsSuccess)
                    {
                        var options = new CookieOptions
                        {
                            HttpOnly = true,
                            Expires = DateTimeOffset.UtcNow.AddDays(7),
                            Path = "/"
                        };

                        ctx.ActionContext.HttpContext.Response.Cookies.Append("accessToken", refreshTokenResponse.Data.AccessToken, options);
                        ctx.ActionContext.HttpContext.Response.Cookies.Append("refreshToken", refreshTokenResponse.Data.RefreshToken, options);

                        request.Headers.TryAddWithoutValidation("raise401", "on");
                        request.Headers.Remove("Authorization");
                        request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {refreshTokenResponse.Data.AccessToken}");
                        response = await base.SendAsync(request, cancellationToken);
                        Console.WriteLine("Updated, sent");
                    }
                }
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
                Console.WriteLine("Unauthorized");

            return response;
        }
    }
}
