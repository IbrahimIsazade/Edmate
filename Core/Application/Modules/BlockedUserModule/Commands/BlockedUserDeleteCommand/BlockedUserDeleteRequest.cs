using Domain.Entities;
using MediatR;

namespace Application.Modules.BlockedUserModule.Commands.BlockedUserDeleteCommand
{
    public class BlockedUserDeleteRequest : IRequest
    {
        public required int BlockerId { get; set; }
        public required int BlockedId { get; set; }
    }
}
