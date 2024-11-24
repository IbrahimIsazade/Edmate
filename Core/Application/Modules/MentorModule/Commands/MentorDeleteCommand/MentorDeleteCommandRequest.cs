using Domain.Entities;
using MediatR;

namespace Application.Modules.MentorModule.Commands.DeleteCommand
{
    public class MentorDeleteCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}