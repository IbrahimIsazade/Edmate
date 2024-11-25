using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.CourseModule.Queries.CourseGetAllQuery
{
    internal class CourseGetAllQueryRequestHandler(ICourseRepository courseRepository) : IRequestHandler<CourseGetAllQueryRequest, IEnumerable<Course>>
    {
        public async Task<IEnumerable<Course>> Handle(CourseGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            return courseRepository.GetAll().ToList();
        }
    }
}