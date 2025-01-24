using Microsoft.AspNetCore.Mvc;
using WebUI.Services.Video;

namespace WebUI.ViewComponents
{
    public class AllVideoTitlesViewComponent(IVideoService videoService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id, int currentOrderNum, string view = null)
        {
            var data = await videoService.GetAllAsync();

            if (data is null)
                throw new Exception("Data not found");
            if (!data.IsSuccess)
                throw new Exception("Bad reg");

            var response = data.Data!.Where(x => x.CourseId == id);

            if (!string.IsNullOrWhiteSpace(view))
                return View(view, response);

            return View(response);
        }
    }
}
