using Domain.Entities;
using MediatR;

namespace Application.Modules.StudentModule.Commands.EditCommand
{
    public class StudentEditCommandRequest : IRequest<Award>
    {
        public int Id { get; set; } public int Name { get; set; }
    }
}