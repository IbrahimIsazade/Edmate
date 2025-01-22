using Microsoft.AspNetCore.Mvc;
using WebUI.Models.DTOs.Category;
using WebUI.Services.Category;

namespace WebUI.Controllers
{
    public class CategoryController(ICategoryService categoryService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var res = await categoryService.GetAllAsync();

            return View(res.Data);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto request)
        {
            var res = await categoryService.AddAsync(request);

            if (!res.IsSuccess)
                throw new Exception("Bad request");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var res = await categoryService.GetByIdAsync(id);

            if (!res.IsSuccess)
                throw new Exception($"Not found");

            return View(res.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDto request)
        {
            var res = await categoryService.EditAsync(request);

            if (!res.IsSuccess)
                throw new Exception("Bad request");

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await categoryService.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
