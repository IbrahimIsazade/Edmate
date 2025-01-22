using Domain.Entities;
using MediatR;

namespace Application.Modules.StudentModule.Commands.DeleteCommand
{
    public class StudentDeleteCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}