using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models.DTOs.Course;
using WebUI.Services.Course;
using WebUI.Services.Video;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VideoController(IVideoService videoService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await videoService.GetAllAsync();

            if (response == null)
                return RedirectToAction("Signin", "Account", new { area = "" });
            if (!response.IsSuccess)
                return RedirectToAction("WentWrong", "Error");

            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await videoService.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
