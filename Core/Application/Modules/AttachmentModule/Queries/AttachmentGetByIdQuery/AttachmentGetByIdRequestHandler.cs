using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.AttachmentModule.Queries.AttachmentGetByIdQuery
{
    internal class AttachmentGetByIdRequestHandler(IAttachmentRepository attachmentRepository) : IRequestHandler<AttachmentGetByIdRequest, Attachment>
    {
        public async Task<Attachment> Handle(AttachmentGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await attachmentRepository.GetAsync(m => m.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException("Attachment not found");

            return entity;
        }
    }
}
