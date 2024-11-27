using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FollowerModule.Commands.DeleteCommand
{
    internal class FollowerDeleteCommandRequestHandler(IFollowerRepository followerRepository) : IRequestHandler<FollowerDeleteCommandRequest>
    {
        public async Task Handle(FollowerDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var follower = await followerRepository.GetAsync(m => m.FollowingId == request.FollowedId && m.FollowedId == request.FollowedId);

            followerRepository.Delete(follower);
            await followerRepository.SaveAsync(cancellationToken);
        }
    }
}