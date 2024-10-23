using Domain.Entities;
using MediatR;

namespace Application.Modules.MessageModule.Queries.GetAllQuery
{
    public class MessageGetAllQueryRequest : IRequest<IEnumerable<Message>> { }
}
