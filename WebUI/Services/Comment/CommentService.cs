using WebUI.Models.common;
using WebUI.Models.DTOs.Comment;
using WebUI.Services.common;

namespace WebUI.Services.Comment
{
    public class CommentService : ProxyService, ICommentService
    {
        public CommentService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration) { }

        public Task<ApiResponse<IEnumerable<CommentResponseDto>>> GetAllAsync(CancellationToken cancellation = default)
           => base.GetAsync<ApiResponse<IEnumerable<CommentResponseDto>>>("/api/Comment", cancellation);

        public Task<ApiResponse<CommentResponseDto>> GetByIdAsync(int id, CancellationToken cancellation = default)
            => base.GetAsync<ApiResponse<CommentResponseDto>>($"/api/Comment/{id}", cancellation);
        public Task<ApiResponse<IEnumerable<CommentResponseDto>>> GetAllByCourseId(int id, CancellationToken cancellation = default)
            => base.GetAsync<ApiResponse<IEnumerable<CommentResponseDto>>>($"/api/Comment/{id}", cancellation);

        public Task<ApiResponse> AddAsync(CommentRequestDto request, CancellationToken cancellation = default)
            => base.PostAsync<CommentRequestDto, ApiResponse>("/api/Comment", request, cancellation);

        public Task<ApiResponse> EditAsync(CommentDto request, CancellationToken cancellation = default)
            => base.PutAsync<CommentDto, ApiResponse>($"/api/Comment/{request.Id}", request, cancellation);

        public Task RemoveAsync(int id, CancellationToken cancellation = default)
            => base.DeleteAsync($"/api/Comment/{id}", cancellation);

        
    }
}
