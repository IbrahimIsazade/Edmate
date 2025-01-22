using Microsoft.AspNetCore.Mvc;
using WebUI.Services.Video;

namespace WebUI.ViewComponents
{
    public class AllVideosViewComponent(IVideoService videoService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id, string view = null)
        {
            var response = await videoService.GetByCourseIdAsync(id);

            if (!string.IsNullOrWhiteSpace(view))
                return View(view, response.Data);

            if (response == null)
                Console.WriteLine("NO DATA WAS FOUND");

            return View(response.Data);
        }
    }
}
