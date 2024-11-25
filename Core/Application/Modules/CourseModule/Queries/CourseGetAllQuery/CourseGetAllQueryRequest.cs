using Domain.Entities;
using MediatR;

namespace Application.Modules.CourseModule.Queries.CourseGetAllQuery
{
    public class CourseGetAllQueryRequest : IRequest<IEnumerable<Course>> { }
}