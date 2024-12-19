using WebUI.Models.common;
using WebUI.Models.DTOs.Category;

namespace WebUI.Services.Category
{
    public interface ICategoryService
    {
        public Task<ApiResponse<IEnumerable<CategoryDto>>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<ApiResponse<CategoryDto>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<ApiResponse> AddAsync(CategoryDto request, CancellationToken cancellationToken = default);
        public Task<ApiResponse> EditAsync(CategoryDto request, CancellationToken cancellation = default);
        public Task RemoveAsync(int id, CancellationToken cancellation = default);
    }
}
