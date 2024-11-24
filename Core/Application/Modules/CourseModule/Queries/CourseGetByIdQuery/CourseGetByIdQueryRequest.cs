using Domain.Entities;
using MediatR;

namespace Application.Modules.CourseModule.Commands.GetByIdQuery
{
    public class CourseGetByIdQueryRequest : IRequest
    {
        public int Id { get; set; }
    }
}