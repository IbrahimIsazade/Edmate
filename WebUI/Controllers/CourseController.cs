using Microsoft.AspNetCore.Mvc;
using WebUI.Models.DTOs.Course;
using WebUI.Services.Course;

namespace WebUI.Controllers
{
    public class CourseController(ICourseService courseService) : Controller
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

        public async Task<IActionResult> View(int id, int orderNumber)
        {
            var courses = await courseService.GetByIdAsync(id);

            if (courses is null || !courses.IsSuccess)
                throw new Exception("Bad Request");

            var data = new CourseViewDto
            {
                Data = courses.Data!,
                OrderNumber = orderNumber,
            };

            return View(data);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var courses = await courseService.GetByIdAsync(id);

            return View(courses.Data);
        }

        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromForm] CourseAddRequestDto request)
        {
            request.MentorId = 3;
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
