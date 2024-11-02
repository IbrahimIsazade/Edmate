using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.AttachmentModule.Queries.AttachmentGetAllQuery
{
    internal class AttachmentGetAllRequestHandler(IAttachmentRepository attachmentRepository) : IRequestHandler<AttachmentGetAllRequest, IEnumerable<Attachment>>
    {
        public async Task<IEnumerable<Attachment>> Handle(AttachmentGetAllRequest request, CancellationToken cancellationToken)
        {
            return attachmentRepository.GetAll().ToList();
        }
    }
}
