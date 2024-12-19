using Microsoft.AspNetCore.Mvc;
using WebUI.Models.DTOs.Course;
using WebUI.Services.Category;
using WebUI.Services.Course;

namespace WebUI.Controllers
{
    public class CourseController(
        ICourseService courseService,
        ICategoryService categoryService
        ) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var courses = await courseService.GetAllAsync();

            return View(courses.Data);
        }

        public async Task<IActionResult> CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseRequest([FromForm] CourseAddRequestDto request)
        {
            request.MentorId = 3;
            request.CategoryId = int.Parse(Request.Form["Category"]!);
            var course = await courseService.AddAsync(request);

            return RedirectToAction(nameof(Index));
        }
    }
}
