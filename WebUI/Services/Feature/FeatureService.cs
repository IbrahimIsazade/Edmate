using WebUI.Models.common;
using WebUI.Models.DTOs.Feature;
using WebUI.Services.common;

namespace WebUI.Services.Feature
{
    public class FeatureService : ProxyService, IFeatureService
    {
        public FeatureService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration)
        {
        }

        public Task<ApiResponse<IEnumerable<FeatureDto>>> GetAllAsync(CancellationToken cancellation = default)
           => base.GetAsync<ApiResponse<IEnumerable<FeatureDto>>>("/api/Feature", cancellation);

        public Task<ApiResponse<IEnumerable<FeatureDto>>> GetAllByItemId(int id, bool isCourse, CancellationToken cancellation = default)
            => base.GetAsync<ApiResponse<IEnumerable<FeatureDto>>>($"/api/Feature/{id}/{isCourse}", cancellation);

        public Task<ApiResponse> AddAsync(FeatureRequestDto request, CancellationToken cancellation = default)
            => base.PostAsync<FeatureRequestDto, ApiResponse>("/api/Feature", request, cancellation);

        public Task<ApiResponse> EditAsync(FeatureDto request, CancellationToken cancellation = default)
            => base.PutAsync<FeatureDto, ApiResponse>($"/api/Feature/{request.Id}", request, cancellation, true);

        public Task RemoveAsync(int id, CancellationToken cancellation = default)
            => base.DeleteAsync($"/api/Feature/{id}", cancellation);
    }
}
