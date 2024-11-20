using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.BlockedUserModule.Queries.BlockedUserGetByIdQuery
{
    internal class BlockedUserGetByIdRequestHandler(IBlockedUserRepository blockedUserRepository) : IRequestHandler<BlockedUserGetByIdRequest, BlockedUser>
    {
        public async Task<BlockedUser> Handle(BlockedUserGetByIdRequest request, CancellationToken cancellationToken)
        {
            return await blockedUserRepository.GetAsync(m => m.BlockerId == request.BlockerId && m.BlockedId == request.BlockedId);
        }
    }
}
