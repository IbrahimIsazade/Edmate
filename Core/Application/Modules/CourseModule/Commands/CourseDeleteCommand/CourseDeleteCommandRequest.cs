using Domain.Entities;
using MediatR;

namespace Application.Modules.CourseModule.Commands.CourseDeleteCommand
{
    public class CourseDeleteCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}