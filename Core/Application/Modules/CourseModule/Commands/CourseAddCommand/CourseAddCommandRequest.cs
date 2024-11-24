using Domain.Entities;
using MediatR;

namespace Application.Modules.CourseModule.Commands.AddCommand
{
    public class CourseAddCommandRequest : IRequest<Award>
    {
        public int Name { get; set; }
    }
}