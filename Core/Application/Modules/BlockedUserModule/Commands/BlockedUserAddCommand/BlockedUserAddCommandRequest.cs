using Domain.Entities;
using MediatR;

namespace Application.Modules.BlockedUserModule.Commands.BlockedUserAddCommand
{
    public class BlockedUserAddCommandRequest : IRequest<BlockedUser>
    {
        public required int BlockerId { get; set; }
        public required int BlockedId { get; set; }
    }
}
