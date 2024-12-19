using Microsoft.AspNetCore.Mvc;
using WebUI.Services.Mentor;

namespace WebUI.Controllers
{
    public class MentorController(IMentorService mentorService) : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            var mentors = await mentorService.GetAllAsync();

            if (mentors == null || !mentors.IsSuccess)
            {
                Console.WriteLine("Unauthorized user request / Bad request");
                return View();
            }
                

            return View(mentors.Data);
        }
    }
}
