using Newtonsoft.Json;
using WebUI.Models.common;
using WebUI.Models.DTOs.Category;
using WebUI.Services.common;

namespace WebUI.Services.Category
{
    public class CategoryService : ProxyService, ICategoryService
    {
        public CategoryService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration)
        {
        }

        public Task<ApiResponse<IEnumerable<CategoryDto>>> GetAllAsync(CancellationToken cancellation = default)
           => base.GetAsync<ApiResponse<IEnumerable<CategoryDto>>>("/api/Category", cancellation);

        public Task<ApiResponse<CategoryDto>> GetByIdAsync(int id, CancellationToken cancellation = default)
            => base.GetAsync<ApiResponse<CategoryDto>>($"/api/Category/{id}", cancellation);

        public Task<ApiResponse> AddAsync(CategoryDto request, CancellationToken cancellation = default)
            => base.PostAsync<CategoryDto, ApiResponse>("/api/Category", request, cancellation);

        public Task<ApiResponse> EditAsync(CategoryDto request, CancellationToken cancellation = default)
            => base.PutAsync<CategoryDto, ApiResponse>($"/api/Category/{request.Id}", request, cancellation);

        public Task RemoveAsync(int id, CancellationToken cancellation = default)
            => base.DeleteAsync($"/api/Category/{id}", cancellation);
    }
}
