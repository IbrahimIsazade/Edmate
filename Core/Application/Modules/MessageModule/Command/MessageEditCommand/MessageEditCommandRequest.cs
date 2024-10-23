using Domain.Entities;
using MediatR;

namespace Application.Modules.MessageModule.Command.MessageEditCommand
{
    public class MessageEditCommandRequest : IRequest<Message>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
    }
}
