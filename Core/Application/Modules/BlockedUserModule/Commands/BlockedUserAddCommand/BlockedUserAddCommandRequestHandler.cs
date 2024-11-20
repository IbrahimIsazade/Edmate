using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.BlockedUserModule.Commands.BlockedUserAddCommand
{
    internal class BlockedUserAddCommandRequestHandler(IBlockedUserRepository blockedUserRepository) : IRequestHandler<BlockedUserAddCommandRequest, BlockedUser>
    {
        public async Task<BlockedUser> Handle(BlockedUserAddCommandRequest request, CancellationToken cancellationToken)
        {
            var blockedUser = new BlockedUser()
            {
                BlockedId = request.BlockedId,
                BlockerId = request.BlockerId
            };

            await blockedUserRepository.AddAsync(blockedUser, cancellationToken);
            await blockedUserRepository.SaveAsync(cancellationToken);

            return blockedUser;
        }
    }
}
