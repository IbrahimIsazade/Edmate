using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebUI.Binders.BooleanBinder;
using WebUI.Services.Account;
using WebUI.Services.Category;
using WebUI.Services.Comment;
using WebUI.Services.common;
using WebUI.Services.Course;
using WebUI.Services.Feature;
using WebUI.Services.Mentor;
using WebUI.Services.Video;

namespace WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<ProxyAuthorizationMessageHandler>();
            builder.Services.AddHttpClient("httpClient").AddHttpMessageHandler<ProxyAuthorizationMessageHandler>();   
            builder.Services.AddControllersWithViews(cfg =>
            {
                cfg.ModelBinderProviders.Insert(0, new BooleanBinderProvider());
            });

            builder.Services.AddSingleton<ICategoryService, CategoryService>();
            builder.Services.AddSingleton<IMentorService, MentorService>();
            builder.Services.AddSingleton<ICourseService, CourseService>();
            builder.Services.AddSingleton<ICommentService, CommentService>();
            builder.Services.AddSingleton<IAccountService, AccountService>();
            builder.Services.AddSingleton<IVideoService, VideoService>();
            builder.Services.AddSingleton<IFeatureService, FeatureService>();
            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.Limits.MaxRequestBodySize = 300 * 1024 * 1024;
            });

            builder.Services.Configure<FormOptions>(options => {
                options.MultipartBodyLengthLimit = 1024 * 1024 * 300; // 300 MB
            });

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
            app.UseStatusCodePagesWithReExecute("/Account/Login");

            app.MapControllerRoute(name: "areas",
                pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Course}/{action=Index}/{id?}/{boolean?}");

            app.Run();
        }
    }
}
