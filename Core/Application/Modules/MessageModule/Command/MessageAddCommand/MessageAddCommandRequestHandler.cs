using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.MessageModule.Command.MessageAddCommand
{
    internal class MessageAddCommandRequestHandler(IMessageRepository messageRepository) : IRequestHandler<MessageAddCommandRequest, Message>
    {
        public async Task<Message> Handle(MessageAddCommandRequest request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Content))
            {
                throw new BadRequestException("Message");
            }

            var message = new Message()
            {
                Content = request.Content,
                SenderId = request.SenderId,
                RecieverId = request.RecieverId
            };

            await messageRepository.AddAsync(message, cancellationToken);
            await messageRepository.SaveAsync(cancellationToken);
            
            return message;
        }
    }
}
