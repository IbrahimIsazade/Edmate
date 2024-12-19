using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models.DTOs.Account;
using WebUI.Services.Account;

namespace WebUI.Controllers
{
    public class AccountController(IAccountService accountService) : Controller
    {
        //[Route("signin.html")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [Route("Account/SignIn")]
        public async Task<IActionResult> SignIn(SignInRequestDto request)
        {
            var response = await accountService.SignIn(request);

            Response.Cookies.Delete("accessToken");
            Response.Cookies.Delete("refreshToken");

            var options = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTimeOffset.UtcNow.AddMinutes(100),
                Path = "/"
            };

            Response.Cookies.Append("accessToken", response.Data!.AccessToken, options);
            Response.Cookies.Append("refreshToken", response.Data!.RefreshToken, options);

            var callbackUrl = Request.Query["ReturnUrl"];

            if (!string.IsNullOrWhiteSpace(callbackUrl))
            {
                return Redirect(callbackUrl!);
            }

            return RedirectToAction("Index", "Course");
        }
    }
}
