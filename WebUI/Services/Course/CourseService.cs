using WebUI.Models.common;
using WebUI.Models.DTOs.Course;
using WebUI.Services.common;

namespace WebUI.Services.Course
{
    public class CourseService : ProxyService, ICourseService
    {
        public CourseService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration)
        {
        }

        public Task<ApiResponse<IEnumerable<CourseGetAllResponse>>> GetAllAsync(CancellationToken cancellation = default)
           => base.GetAsync<ApiResponse<IEnumerable<CourseGetAllResponse>>>("/api/Course", cancellation);

        public Task<ApiResponse<CourseGetByIdResponse>> GetByIdAsync(int id, CancellationToken cancellation = default)
            => base.GetAsync<ApiResponse<CourseGetByIdResponse>>($"/api/Course/{id}", cancellation);

        public Task<ApiResponse> AddAsync(CourseAddRequestDto request, CancellationToken cancellation = default)
            => base.PostAsync<CourseAddRequestDto, ApiResponse>("/api/Course", request, cancellation, true);

        public Task<ApiResponse> EditAsync(CourseEditDto request, CancellationToken cancellation = default)
            => base.PutAsync<CourseEditDto, ApiResponse>($"/api/Course/{request.Id}", request, cancellation, true);

        public Task RemoveAsync(int id, CancellationToken cancellation = default)
            => base.DeleteAsync($"/api/Course/{id}", cancellation);
    }
}
