using Microsoft.AspNetCore.Mvc;
using WebUI.Models.DTOs.Book;
using WebUI.Models.DTOs.Course;
using WebUI.Services.Book;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController(IBookService bookService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await bookService.GetAllAsync();

            if (response == null)
                return RedirectToAction("Signin", "Account", new { area = "" });
            if (!response.IsSuccess)
                return RedirectToAction("WentWrong", "Error");

            return View(response.Data);
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            var response = await bookService.GetByIdAsync(id);

            if (response == null)
                return RedirectToAction("Signin", "Account", new { area = "" });
            if (!response.IsSuccess)
                return RedirectToAction("WentWrong", "Error");

            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] BookRequestDto request, int id)
        {
            request.Id = id;

            if (!string.IsNullOrWhiteSpace(Request.Form["Category"]))
                request.CategoryId = int.Parse(Request.Form["Category"]!);

            var response = await bookService.EditAsync(request);

            if (response is null || !response.IsSuccess)
                return RedirectToAction("WentWrong", "Error");

            return RedirectToAction(nameof(Index));
        }
    }
}
