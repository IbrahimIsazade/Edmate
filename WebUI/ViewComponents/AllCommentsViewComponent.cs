using Microsoft.AspNetCore.Mvc;
using WebUI.Services.Comment;

namespace WebUI.ViewComponents
{
    public class AllCommentsViewComponent(ICommentService commentService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id, string view = null)
        {
            var response = await commentService.GetAllByCourseId(id);

            if (!string.IsNullOrWhiteSpace(view))
                return View(view, response.Data);

            return View(response.Data);
        }
    }
}
