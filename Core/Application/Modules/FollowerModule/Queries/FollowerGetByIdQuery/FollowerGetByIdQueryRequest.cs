using Domain.Entities;
using MediatR;

namespace Application.Modules.FollowerModule.Commands.GetByIdQuery
{
    public class FollowerGetByIdQueryRequest : IRequest<Follower>
    {
        public int FollowingId { get; set; }
        public int FollowedId { get; set; }
    }
}