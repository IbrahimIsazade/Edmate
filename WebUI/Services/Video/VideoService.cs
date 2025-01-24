using WebUI.Models.common;
using WebUI.Models.DTOs.Video;
using WebUI.Services.common;

namespace WebUI.Services.Video
{
    public class VideoService : ProxyService, IVideoService
    {
        public VideoService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration) { }

        public Task<ApiResponse<IEnumerable<VideoDto>>> GetAllAsync(CancellationToken cancellation = default)
           => base.GetAsync<ApiResponse<IEnumerable<VideoDto>>>("/api/Video", cancellation);
        public Task<ApiResponse<VideoDto>> GetByIdAsync(int id, CancellationToken cancellation = default)
            => base.GetAsync<ApiResponse<VideoDto>>($"/api/Video/{id}", cancellation);

        public Task<ApiResponse<IEnumerable<VideoDto>>> GetByCourseIdAsync(VideoGetByCourseIdQueryRequest request, CancellationToken cancellation = default)
            => base.GetAsync<ApiResponse<IEnumerable<VideoDto>>>($"/api/Video/{request.Id}/{request.OrderNumber}", cancellation);

        public Task<ApiResponse> AddAsync(VideoRequestDto request, CancellationToken cancellation = default)
            => base.PostAsync<VideoRequestDto, ApiResponse>("/api/Video", request, cancellation, true);

        public Task<ApiResponse> EditAsync(VideoDto request, CancellationToken cancellation = default)
            => base.PutAsync<VideoDto, ApiResponse>($"/api/Video/{request.Id}", request, cancellation, true);

        public Task RemoveAsync(int id, CancellationToken cancellation = default)
            => base.DeleteAsync($"/api/Video/{id}", cancellation);
    }
}
