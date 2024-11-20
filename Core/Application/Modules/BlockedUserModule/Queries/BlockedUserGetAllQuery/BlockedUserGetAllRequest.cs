using Domain.Entities;
using MediatR;

namespace Application.Modules.BlockedUserModule.Queries.BlockedUserGetAllQuery
{
    public class BlockedUserGetAllRequest : IRequest<IEnumerable<BlockedUser>> { }
}
