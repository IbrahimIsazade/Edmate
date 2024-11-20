using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.BlockedUserModule.Queries.BlockedUserGetAllQuery
{
    internal class BlockedUserGetAllRequestHandler(IBlockedUserRepository blockedUserRepository) : IRequestHandler<BlockedUserGetAllRequest, IEnumerable<BlockedUser>>
    {
        public async Task<IEnumerable<BlockedUser>> Handle(BlockedUserGetAllRequest request, CancellationToken cancellationToken)
        {
            return blockedUserRepository.GetAll();
        }
    }
}
