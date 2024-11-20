using Domain.Entities;
using MediatR;

namespace Application.Modules.BlockedUserModule.Queries.BlockedUserGetByIdQuery
{
    public class BlockedUserGetByIdRequest : IRequest<BlockedUser>
    {
        public int BlockerId { get; set; }
        public int BlockedId { get; set; }
    }
}
