using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FollowerModule.Commands.GetByIdQuery
{
    internal class FollowerGetByIdQueryRequestHandler(IFollowerRepository followerRepository) : IRequestHandler<FollowerGetByIdQueryRequest, Follower>
    {
        public async Task<Follower> Handle(FollowerGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await followerRepository.GetAsync(m => m.FollowingId == request.FollowedId && m.FollowedId == request.FollowedId);
        }
    }
}