using WebUI.Models.common;
using WebUI.Models.DTOs.Comment;
using WebUI.Models.DTOs.Feature;

namespace WebUI.Services.Feature
{
    public interface IFeatureService
    {
        public Task<ApiResponse<IEnumerable<FeatureDto>>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<ApiResponse<IEnumerable<FeatureDto>>> GetAllByItemId(int id, bool isCourse, CancellationToken cancellationToken = default);
        public Task<ApiResponse> AddAsync(FeatureRequestDto request, CancellationToken cancellationToken = default);
        public Task<ApiResponse> EditAsync(FeatureDto request, CancellationToken cancellation = default);
        public Task RemoveAsync(int id, CancellationToken cancellation = default);
    }
}
