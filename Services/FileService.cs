using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Services.Registration;

namespace Services
{
    [SingletonLifeTime]
    public class FileService(IHostEnvironment env) : IFileService
    {
        public async Task<string> UploadAsync(IFormFile file, CancellationToken cancellationToken = default)
        {
            if (file is null)
            {
                return null!;
            }

            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{extension}";
            Console.WriteLine($"EVOIRMENT CONTENT ROOT PATH -> {env.ContentRootPath}");
            string fullPath = Path.Combine(env.ContentRootPath, "wwwroot", "Uploads", fileName);

            using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite))
            {
                await file.CopyToAsync(fs, cancellationToken);
            }

            return fileName;
        }
    }
}
