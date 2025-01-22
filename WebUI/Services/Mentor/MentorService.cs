using WebUI.Models.common;
using WebUI.Models.DTOs.Mentor;
using WebUI.Services.common;

namespace WebUI.Services.Mentor
{
    public class MentorService : ProxyService, IMentorService
    {
        public MentorService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration)
        {
        }

        public Task<ApiResponse<IEnumerable<MentorResponseDto>>> GetAllAsync(CancellationToken cancellation = default)
           => base.GetAsync<ApiResponse<IEnumerable<MentorResponseDto>>>("/api/Mentor", cancellation);

        public Task<ApiResponse<MentorDto>> GetByIdAsync(int id, CancellationToken cancellation = default)
            => base.GetAsync<ApiResponse<MentorDto>>($"/api/Mentor/{id}", cancellation);

        public Task<ApiResponse> AddAsync(MentorDto request, CancellationToken cancellation = default)
            => base.PostAsync<MentorDto, ApiResponse>("/api/Mentor", request, cancellation, true);

        public Task<ApiResponse> EditAsync(MentorDto request, CancellationToken cancellation = default)
            => base.PutAsync<MentorDto, ApiResponse>($"/api/Mentor/{request.Id}", request, cancellation, true);

        public Task RemoveAsync(int id, CancellationToken cancellation = default)
            => base.DeleteAsync($"/api/Mentor/{id}", cancellation);
    }
}
