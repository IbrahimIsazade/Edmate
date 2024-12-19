using MediatR;

namespace Application.Modules.AttachmentModule.Commands.AttachmentDeleteCommand
{
    public class AttachmentDeleteCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}
