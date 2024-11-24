using Domain.Entities;
using MediatR;

namespace Application.Modules.StudentModule.Commands.AddCommand
{
    public class StudentAddCommandRequest : IRequest<Award>
    {
        public int Name { get; set; }
    }
}