using Microsoft.AspNetCore.Mvc;
using WebUI.Models.DTOs.Feature;
using WebUI.Services.Feature;

namespace WebUI.Controllers
{
    public class FeatureController(IFeatureService featureService) : Controller
    {
        [HttpGet("{id:int:min(1)}/{isCourse:bool}")]
        public IActionResult GetAllByItemId(int id, bool isCourse)
        {
            var response = featureService.GetAllByItemId(id, isCourse);

            if (response is null)
                throw new NullReferenceException();

            return Ok(response);
        }

        public IActionResult Add(int id, string boolean)
        {
            var data = new FeatureDto
            {
                ItemId = id,
                IsCourseFeature = bool.Parse(boolean)
            };

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FeatureRequestDto request, int id, string boolean)
        {
            request.ItemId = id;
            request.IsCourse = bool.Parse(boolean);

            var response = await featureService.AddAsync(request);

            if (response is null)
                throw new NullReferenceException();

            return RedirectToAction("Student", "Dashboard");
        }
    }
}
