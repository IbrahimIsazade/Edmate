using Domain.Entities;
using MediatR;

namespace Application.Modules.MentorModule.Commands.AddCommand
{
    public class MentorAddCommandRequest : IRequest<Award>
    {
        public int Name { get; set; }
    }
}