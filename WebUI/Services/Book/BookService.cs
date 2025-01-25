using WebUI.Models.common;
using WebUI.Models.DTOs.Book;
using WebUI.Services.common;

namespace WebUI.Services.Book
{
    public class BookService : ProxyService, IBookService
    {
        public BookService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration)
        {
        }

        public Task<ApiResponse<IEnumerable<BookResponseDto>>> GetAllAsync(CancellationToken cancellation = default)
           => base.GetAsync<ApiResponse<IEnumerable<BookResponseDto>>>("/api/Book", cancellation);

        public Task<ApiResponse<BookResponseDto>> GetByIdAsync(int id, CancellationToken cancellation = default)
            => base.GetAsync<ApiResponse<BookResponseDto>>($"/api/Book/{id}", cancellation);

        public Task<ApiResponse> AddAsync(BookRequestDto request, CancellationToken cancellation = default)
            => base.PostAsync<BookRequestDto, ApiResponse>("/api/Book", request, cancellation, true);

        public Task<ApiResponse> EditAsync(BookRequestDto request, CancellationToken cancellation = default)
            => base.PutAsync<BookRequestDto, ApiResponse>($"/api/Book/{request.Id}", request, cancellation);

        public Task RemoveAsync(int id, CancellationToken cancellation = default)
            => base.DeleteAsync($"/api/Book/{id}", cancellation);
    }
}
