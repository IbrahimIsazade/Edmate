using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.MessageModule.Command.MessageEditCommand
{
    internal class MessageEditCommandRequestHandler(IMessageRepository messageRepository) : IRequestHandler<MessageEditCommandRequest, Message>
    {
        public async Task<Message> Handle(MessageEditCommandRequest request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Content))
            {
                throw new BadRequestException("Message");
            }

            var entity = await messageRepository.GetAsync(m => m.Id == request.Id);

            entity.Content = request.Content;
            entity.SenderId = request.SenderId;
            entity.RecieverId = request.RecieverId;

            messageRepository.Edit(entity);
            await messageRepository.SaveAsync(cancellationToken);

            return entity;
        }
    }
}
