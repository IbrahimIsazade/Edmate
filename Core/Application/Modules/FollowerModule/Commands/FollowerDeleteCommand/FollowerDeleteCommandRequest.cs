using Domain.Entities;
using MediatR;

namespace Application.Modules.FollowerModule.Commands.DeleteCommand
{
    public class FollowerDeleteCommandRequest : IRequest
    {
        public int FollowingId { get; set; }
        public int FollowedId { get; set; }
    }
}