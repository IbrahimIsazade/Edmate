using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.AttachmentModule.Queries.AttachmentGetAllQuery
{
    internal class AttachmentGetAllQueryRequestHandler(IAttachmentRepository attachmentRepository) : IRequestHandler<AttachmentGetAllQueryRequest, IEnumerable<Attachment>>
    {
        public async Task<IEnumerable<Attachment>> Handle(AttachmentGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            return attachmentRepository.GetAll().ToList();
        }
    }
}
