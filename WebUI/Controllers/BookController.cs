using Microsoft.AspNetCore.Mvc;
using WebUI.Models.DTOs.Book;
using WebUI.Services.Book;

namespace WebUI.Controllers
{
    public class BookController(IBookService bookService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await bookService.GetAllAsync();

            return View(response.Data);
        }
        
        public async Task<IActionResult> View(int id)
        {
            var response = await bookService.GetByIdAsync(id);

            return View(response.Data);
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            var response = await bookService.GetByIdAsync(id);

            return View(response.Data);
        }

        [HttpPost("{id:int:min(1)}")]
        public async Task<IActionResult> Edit(BookRequestDto request, int id)
        {
            request.Id = id;

            if (!string.IsNullOrWhiteSpace(Request.Form["Category"]))
                request.CategoryId = int.Parse(Request.Form["Category"]!);

            var response = await bookService.EditAsync(request);

            return RedirectToAction(nameof(View), new { id = id});
        }
    }
}
