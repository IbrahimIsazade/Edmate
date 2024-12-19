using MediatR;
using Repositories;
using Domain.Exceptions;

namespace Application.Modules.AttachmentModule.Commands.AttachmentDeleteCommand
{
    internal class AttachmentDeleteCommandRequestHandler(IAttachmentRepository attachmentRepository) : IRequestHandler<AttachmentDeleteCommandRequest>
    {
        public async Task Handle(AttachmentDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var attachment = await attachmentRepository.GetAsync(m => m.Id == request.Id, cancellationToken);

            if (attachment == null)
                throw new NotFoundException("Attachment not found");

            attachmentRepository.Delete(attachment);
            await attachmentRepository.SaveAsync(cancellationToken);
        }
    }
}
