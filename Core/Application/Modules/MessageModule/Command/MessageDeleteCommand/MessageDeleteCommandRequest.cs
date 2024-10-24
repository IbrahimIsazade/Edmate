using MediatR;

namespace Application.Modules.MessageModule.Command.MessageDeleteCommand
{
    public class MessageDeleteCommandRequest : IRequest 
    {
        public int Id { get; set; }
    }
}
