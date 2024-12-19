using WebUI.Models.common;
using WebUI.Models.DTOs.Mentor;
using WebUI.Models.DTOs.Video;

namespace WebUI.Services.Video
{
    public interface IVideoService
    {
        public Task<ApiResponse<IEnumerable<VideoDto>>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<ApiResponse<VideoDto>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<ApiResponse> AddAsync(VideoDto request, CancellationToken cancellationToken = default);
        public Task<ApiResponse> EditAsync(VideoDto request, CancellationToken cancellation = default);
        public Task RemoveAsync(int id, CancellationToken cancellation = default);
    }
}
