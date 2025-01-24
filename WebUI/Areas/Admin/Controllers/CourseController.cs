using Microsoft.AspNetCore.Mvc;
using WebUI.Models.DTOs.Course;
using WebUI.Services.Course;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController(ICourseService courseService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await courseService.GetAllAsync();

            if (response == null)
                return RedirectToAction("Signin", "Account", new { area = "" });
            if (!response.IsSuccess)
                return RedirectToAction("WentWrong", "Error");

            return View(response.Data);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await courseService.GetByIdAsync(id);

            if (response == null)
                return RedirectToAction("Signin", "Account", new { area = "" });
            if (!response.IsSuccess)
                return RedirectToAction("WentWrong", "Error");

            return View(response.Data);
        }


        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] CourseEditDto request, int id)
        {
            request.Id = id;

            if (!string.IsNullOrWhiteSpace(Request.Form["Category"]))
                request.CategoryId = int.Parse(Request.Form["Category"]!);

            var response = await courseService.EditAsync(request);

            if (response is null || !response.IsSuccess)
                return RedirectToAction("WentWrong", "Error");

            return RedirectToAction(nameof(Index));
        }
    }
}
