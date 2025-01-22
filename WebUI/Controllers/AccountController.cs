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
        
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AuthentificationRequestDto request)
        {
            var response = await accountService.SignInAsync(request);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError("Password", "Name or password incorrect");
                return View();
            }

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

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpRequestDto request)
        {
            request.IsMentor = true;
            var response = await accountService.SignUp(request);

            return RedirectToAction(nameof(SignIn));
        }
    }
}
