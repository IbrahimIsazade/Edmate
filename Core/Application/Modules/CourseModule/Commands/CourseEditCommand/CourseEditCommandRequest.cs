using Domain.Entities;
using MediatR;

namespace Application.Modules.CourseModule.Commands.EditCommand
{
    public class CourseEditCommandRequest : IRequest<Award>
    {
        public int Id { get; set; } public int Name { get; set; }
    }
}