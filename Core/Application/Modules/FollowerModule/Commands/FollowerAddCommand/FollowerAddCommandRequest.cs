using Domain.Entities;
using MediatR;

namespace Application.Modules.FollowerModule.Commands.AddCommand
{
    public class FollowerAddCommandRequest : IRequest<Award>
    {
        public int Name { get; set; }
    }
}