using WebUI.Models.common;
using WebUI.Models.DTOs.Video;

namespace WebUI.Services.Video
{
    public interface IVideoService
    {
        public Task<ApiResponse<IEnumerable<VideoDto>>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<ApiResponse<VideoDto>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<ApiResponse<IEnumerable<VideoDto>>> GetByCourseIdAsync(VideoGetByCourseIdQueryRequest request, CancellationToken cancellationToken = default);
        public Task<ApiResponse> AddAsync(VideoRequestDto request, CancellationToken cancellationToken = default);
        public Task RemoveAsync(int id, CancellationToken cancellation = default);
    }
}
