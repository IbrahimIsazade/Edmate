using Application.Services;
using MediatR;
using Repositories;

namespace Application.Modules.MessageModule.Command.MessageDeleteCommand
{
    internal class MessageDeleteCommandRequestHandler(IMessageRepository messageRepository, IEntityService entityService) : IRequestHandler<MessageDeleteCommandRequest>
    {
        public async Task Handle(MessageDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            await entityService.Delete(request, request.Id, messageRepository, cancellationToken);
        }
    }
}
