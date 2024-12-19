using WebUI.Models.common;
using WebUI.Models.DTOs.Mentor;

namespace WebUI.Services.Mentor
{
    public interface IMentorService
    {
        public Task<ApiResponse<IEnumerable<MentorResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<ApiResponse<MentorDto>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<ApiResponse> AddAsync(MentorDto request, CancellationToken cancellationToken = default);
        public Task<ApiResponse> EditAsync(MentorDto request, CancellationToken cancellation = default);
        public Task RemoveAsync(int id, CancellationToken cancellation = default);
    }
}
