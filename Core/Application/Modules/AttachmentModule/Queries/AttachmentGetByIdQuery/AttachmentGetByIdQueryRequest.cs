using Domain.Entities;
using MediatR;

namespace Application.Modules.AttachmentModule.Queries.AttachmentGetByIdQuery
{
    public class AttachmentGetByIdQueryRequest : IRequest<Attachment>
    {
        public int Id { get; set; }
    }
}
