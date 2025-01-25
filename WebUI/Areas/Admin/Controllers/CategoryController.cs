using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models.DTOs.Category;
using WebUI.Models.DTOs.Course;
using WebUI.Services.Category;
using WebUI.Services.Course;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(ICategoryService categoryService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await categoryService.GetAllAsync();

            if (response == null)
                return RedirectToAction("Signin", "Account", new { area = "" });
            if (!response.IsSuccess)
                return RedirectToAction("WentWrong", "Error");

            return View(response.Data);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await categoryService.GetByIdAsync(id);

            if (response == null)
                return RedirectToAction("Signin", "Account", new { area = "" });
            if (!response.IsSuccess)
                return RedirectToAction("WentWrong", "Error");

            return View(response.Data);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] CategoryDto request, int id)
        {
            request.Id = id;

            var response = await categoryService.EditAsync(request);

            if (response is null || !response.IsSuccess)
                return RedirectToAction("WentWrong", "Error");

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto request)
        {
            var response = await categoryService.AddAsync(request);

            if (response is null || !response.IsSuccess)
                return RedirectToAction("WentWrong", "Error");

            return RedirectToAction(nameof(Index));
        }
    }
}
