using Domain.Entities;
using MediatR;

namespace Application.Modules.MentorModule.Commands.EditCommand
{
    public class MentorEditCommandRequest : IRequest<Award>
    {
        public int Id { get; set; } public int Name { get; set; }
    }
}