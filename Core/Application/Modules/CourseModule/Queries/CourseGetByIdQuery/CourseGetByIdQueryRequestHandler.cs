using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.CourseModule.Queries.CourseGetByIdQuery
{
    internal class CourseGetByIdQueryRequestHandler(ICourseRepository courseRepository) : IRequestHandler<CourseGetByIdQueryRequest, Course>
    {
        public async Task<Course> Handle(CourseGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await courseRepository.GetAsync(m => m.Id == request.Id);
        }
    }
}