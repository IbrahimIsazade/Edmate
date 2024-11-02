using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.MessageModule.Command.MessageEditCommand
{
    internal class MessageEditCommandRequestHandler(IMessageRepository messageRepository, IEntityService entityService) : IRequestHandler<MessageEditCommandRequest, Message>
    {
        public async Task<Message> Handle(MessageEditCommandRequest request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Content))
            {
                throw new BadRequestException("BADREG", new Dictionary<string, IEnumerable<string>>
                {
                    ["UserName"] = ["UserName cannot be empty"]
                });
            }

            return await entityService.Edit(request, request.Id ,messageRepository, cancellationToken);
        }
    }
}
