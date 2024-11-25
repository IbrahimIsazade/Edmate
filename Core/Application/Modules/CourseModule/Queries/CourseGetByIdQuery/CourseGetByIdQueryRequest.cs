using Domain.Entities;
using MediatR;

namespace Application.Modules.CourseModule.Queries.CourseGetByIdQuery
{
    public class CourseGetByIdQueryRequest : IRequest<Course>
    {
        public int Id { get; set; }
    }
}