using Microsoft.AspNetCore.Mvc;
using WebUI.Models.DTOs.Course;
using WebUI.Services.Course;

namespace WebUI.Controllers
{
    public class CourseController( ICourseService courseService ) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var courses = await courseService.GetAllAsync();

            if (courses == null)
            {
                return RedirectToAction("SignIn", "Account");
            }

            return View(courses.Data);
        }

        public async Task<IActionResult> View(int id)
        {
            var courses = await courseService.GetByIdAsync(id);

            return View(courses.Data);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var courses = await courseService.GetByIdAsync(id);

            return View(courses.Data);
        }

        public async Task<IActionResult> CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseRequest([FromForm] CourseAddRequestDto request)
        {
            request.MentorId = 3; // TO change
            request.CategoryId = int.Parse(Request.Form["Category"]!);
            var course = await courseService.AddAsync(request);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] CourseEditDto request, int id)
        {
            request.Id = id;
            var response = await courseService.EditAsync(request);

            return RedirectToAction(nameof(Index));
        }
    }
}
