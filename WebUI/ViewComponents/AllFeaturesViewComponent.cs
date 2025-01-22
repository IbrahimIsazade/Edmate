using Microsoft.AspNetCore.Mvc;
using WebUI.Services.Feature;

namespace WebUI.ViewComponents
{
    public class AllFeaturesViewComponent(IFeatureService featureService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id, bool isCourse, string view = null)
        {
            var response = await featureService.GetAllByItemId(id, isCourse);

            if (response is null)
                throw new NullReferenceException();

            return View(response.Data);
        }
    }
}
