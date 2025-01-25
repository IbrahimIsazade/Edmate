using WebUI.Models.common;
using WebUI.Models.DTOs.Book;

namespace WebUI.Services.Book
{
    public interface IBookService
    {
        public Task<ApiResponse<IEnumerable<BookResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<ApiResponse<BookResponseDto>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<ApiResponse> AddAsync(BookRequestDto request, CancellationToken cancellationToken = default);
        public Task<ApiResponse> EditAsync(BookRequestDto request, CancellationToken cancellation = default);
        public Task RemoveAsync(int id, CancellationToken cancellation = default);
    }
}
