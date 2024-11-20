using MediatR;
using Repositories;
using Domain.Entities;
using Domain.Exceptions;
using Application.Modules.BlockedUserModule.Commands.BlockedUserDeleteCommand;

namespace Application.Modules.BlockedUserModule.Commands.BlockedUserEditCommand
{
    internal class BlockedUserDeleteRequestHandler(IBlockedUserRepository blockedUserRepository) : IRequestHandler<BlockedUserDeleteRequest>
    {
        async Task IRequestHandler<BlockedUserDeleteRequest>.Handle(BlockedUserDeleteRequest request, CancellationToken cancellationToken)
        {
            BlockedUser entity = await blockedUserRepository.GetAsync(m => m.BlockerId == request.BlockerId && m.BlockedId == request.BlockedId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException("Blocked user not found");
            }

            blockedUserRepository.Delete(entity);
            await blockedUserRepository.SaveAsync(cancellationToken);

        }

    }
}
