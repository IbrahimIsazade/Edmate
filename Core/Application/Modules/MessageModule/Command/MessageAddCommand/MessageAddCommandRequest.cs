using Domain.Entities;
using MediatR;

namespace Application.Modules.MessageModule.Command.MessageAddCommand
{
    public class MessageAddCommandRequest : IRequest<Message>
    {
        public string Content { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
    }
}
