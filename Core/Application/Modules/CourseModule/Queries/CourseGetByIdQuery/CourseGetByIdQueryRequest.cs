using Domain.Entities;
using MediatR;

namespace Application.Modules.CourseModule.Queries.CourseGetByIdQuery
{
    public class CourseGetByIdQueryRequest : IRequest<CourseGetByIdResponse>
    {
        public int Id { get; set; }
    }
}