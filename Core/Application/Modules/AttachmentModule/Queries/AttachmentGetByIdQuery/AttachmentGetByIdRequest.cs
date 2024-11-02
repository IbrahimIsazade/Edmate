using Domain.Entities;
using MediatR;

namespace Application.Modules.AttachmentModule.Queries.AttachmentGetByIdQuery
{
    public class AttachmentGetByIdRequest : IRequest<Attachment>
    {
        public int Id { get; set; }
    }
}
