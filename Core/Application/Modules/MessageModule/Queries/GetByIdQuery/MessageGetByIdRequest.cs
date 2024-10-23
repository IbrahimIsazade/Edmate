using Domain.Entities;
using MediatR;

namespace Application.Modules.MessageModule.Queries.GetByIdQuery
{
    public class MessageGetByIdRequest : IRequest<Message> 
    {
        public int Id { get; set; }
    }
}
