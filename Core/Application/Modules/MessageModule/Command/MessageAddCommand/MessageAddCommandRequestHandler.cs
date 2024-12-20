﻿using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.MessageModule.Command.MessageAddCommand
{
    internal class MessageAddCommandRequestHandler(IMessageRepository messageRepository, IEntityService entityService) : IRequestHandler<MessageAddCommandRequest, Message>
    {
        public async Task<Message> Handle(MessageAddCommandRequest request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Content))
            {
                throw new BadRequestException("BADREG", new Dictionary<string, IEnumerable<string>>
                {
                    ["UserName"] = ["UserName cannot be empty"]
                });
            }

            return await entityService.AddAsync(request, messageRepository, cancellationToken);
        }
    }
}
