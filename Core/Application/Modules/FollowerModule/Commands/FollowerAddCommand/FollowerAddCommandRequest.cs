using Domain.Entities;
using MediatR;

namespace Application.Modules.FollowerModule.Commands.AddCommand
{
    public class FollowerAddCommandRequest : IRequest<Follower>
    {
        public int FollowingId { get; set; }
        public int FollowedId { get; set; }
    }
}