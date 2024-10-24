using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.MessageModule.Command.MessageDeleteCommand
{
    internal class MessageDeleteCommandRequestHandler(IMessageRepository messageRepository) : IRequestHandler<MessageDeleteCommandRequest>
    {
        public async Task Handle(MessageDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await messageRepository.GetAsync(m => m.Id == request.Id);

            if (entity == null)
                throw new NotFoundException("Message not found");

            messageRepository.Delete(entity);
            await messageRepository.SaveAsync();
        }
    }
}
