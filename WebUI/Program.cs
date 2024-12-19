using WebUI.Services.Account;
using WebUI.Services.Category;
using WebUI.Services.common;
using WebUI.Services.Course;
using WebUI.Services.Mentor;

namespace WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<ProxyAuthorizationMessageHandler>();
            builder.Services.AddHttpClient("httpClient").AddHttpMessageHandler<ProxyAuthorizationMessageHandler>();   
            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<ICategoryService, CategoryService>();
            builder.Services.AddSingleton<IMentorService, MentorService>();
            builder.Services.AddSingleton<ICourseService, CourseService>();
            builder.Services.AddSingleton<IAccountService, AccountService>();
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Course}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
