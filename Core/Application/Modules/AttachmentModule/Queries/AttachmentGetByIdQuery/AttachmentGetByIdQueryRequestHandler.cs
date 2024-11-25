using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.AttachmentModule.Queries.AttachmentGetByIdQuery
{
    internal class AttachmentGetByIdQueryRequestHandler(IAttachmentRepository attachmentRepository) : IRequestHandler<AttachmentGetByIdQueryRequest, Attachment>
    {
        public async Task<Attachment> Handle(AttachmentGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var entity = await attachmentRepository.GetAsync(m => m.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException("Attachment not found");

            return entity;
        }
    }
}
