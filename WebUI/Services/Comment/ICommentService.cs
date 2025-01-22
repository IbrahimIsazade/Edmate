using WebUI.Models.common;
using WebUI.Models.DTOs.Comment;

namespace WebUI.Services.Comment
{
    public interface ICommentService
    {
        public Task<ApiResponse<IEnumerable<CommentResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<ApiResponse<CommentResponseDto>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<ApiResponse<IEnumerable<CommentResponseDto>>> GetAllByCourseId(int id, CancellationToken cancellationToken = default);
        public Task<ApiResponse> AddAsync(CommentRequestDto request, CancellationToken cancellationToken = default);
        public Task<ApiResponse> EditAsync(CommentDto request, CancellationToken cancellation = default);
        public Task RemoveAsync(int id, CancellationToken cancellation = default);
    }
}
