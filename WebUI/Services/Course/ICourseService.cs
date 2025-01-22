using WebUI.Models.common;
using WebUI.Models.DTOs.Course;

namespace WebUI.Services.Course
{
    public interface ICourseService
    {
        public Task<ApiResponse<IEnumerable<CourseGetAllResponse>>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<ApiResponse<CourseGetByIdResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<ApiResponse> AddAsync(CourseAddRequestDto request, CancellationToken cancellationToken = default);
        public Task<ApiResponse> EditAsync(CourseEditDto request, CancellationToken cancellation = default);
        public Task RemoveAsync(int id, CancellationToken cancellation = default);
    }
}
