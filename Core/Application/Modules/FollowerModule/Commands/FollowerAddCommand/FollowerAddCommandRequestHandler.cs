using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FollowerModule.Commands.AddCommand
{
    internal class FollowerAddCommandRequestHandler(IFollowerRepository followerRepository) : IRequestHandler<FollowerAddCommandRequest, Follower>
    {
        public async Task<Follower> Handle(FollowerAddCommandRequest request, CancellationToken cancellationToken)
        {
            var follower = new Follower() 
            { 
                FollowedId = request.FollowedId,
                FollowingId = request.FollowingId
            };

            await followerRepository.AddAsync(follower, cancellationToken);
            await followerRepository.SaveAsync(cancellationToken);

            return follower;
        }
    }
}