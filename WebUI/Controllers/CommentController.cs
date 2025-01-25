using Microsoft.AspNetCore.Mvc;
using WebUI.Models.DTOs.Comment;
using WebUI.Services.Comment;

namespace WebUI.Controllers
{
    public class CommentController(ICommentService commentService) : Controller
    {
        //[HttpPost("{id:int:min(1)}")]
        //public async Task<IActionResult> PostComment(CommentRequestDto request, int id)
        //{
        //    request.CourseId = id;
        //    var response = await commentService.AddAsync(request);

        //    if (response is null || !response.IsSuccess)
        //        return BadRequest(response);

        //    return RedirectToAction("Index","Course");
        //}
    }
}
