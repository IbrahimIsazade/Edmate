using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.MessageModule.Queries.GetAllQuery
{
    internal class MessageGetAllQueryRequestHandler(IMessageRepository messageRepository) : IRequestHandler<MessageGetAllQueryRequest, IEnumerable<Message>>
    {
        public async Task<IEnumerable<Message>> Handle(MessageGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            var data = messageRepository.GetAll();

            return data.ToList();
        }
    }
}
