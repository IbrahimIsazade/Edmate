using Microsoft.AspNetCore.Mvc;
using WebUI.Models.DTOs.Video;
using WebUI.Services.Video;

namespace WebUI.Controllers
{
    public class VideoController(IVideoService videoService) : Controller
    {
        public IActionResult Add(int id)
        {
            var data = new VideoRequestDto
            {
                CourseId = id,
            };

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] VideoRequestDto request, int id)
        {
            request.CourseId = id;
            var response = await videoService.AddAsync(request);

            if (response is null)
                throw new NullReferenceException();
            else if (!response.IsSuccess)
                throw new Exception("Bad request");

            return RedirectToAction("Edit", "Course", new { id });
        }
    }
}
