using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.MessageModule.Queries.GetByIdQuery
{
    internal class MessageGetByIdRequestHandler(IMessageRepository messageRepository) : IRequestHandler<MessageGetByIdRequest, Message>
    {
        public async Task<Message> Handle(MessageGetByIdRequest request, CancellationToken cancellationToken)
        {
            return await messageRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
        }
    }
}
