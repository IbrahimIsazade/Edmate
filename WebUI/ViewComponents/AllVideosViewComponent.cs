using Microsoft.AspNetCore.Mvc;
using WebUI.Models.DTOs.Video;
using WebUI.Services.Video;

namespace WebUI.ViewComponents
{
    public class AllVideosViewComponent(IVideoService videoService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id, int? orderNumber = -1, string view = null)
        {
            var request = new VideoGetByCourseIdQueryRequest
            {
                Id = id,
                OrderNumber = orderNumber,
            };

            var response = await videoService.GetByCourseIdAsync(request);

            if (!string.IsNullOrWhiteSpace(view))
                return View(view, response.Data);

            if (response == null)
                throw new Exception("Data was not found");

            return View(response.Data);
        }
    }
}
