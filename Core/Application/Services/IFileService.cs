using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public interface IFileService
    {
        public Task<string> UploadAsync(IFormFile file, CancellationToken cancellation = default);

    }
}
