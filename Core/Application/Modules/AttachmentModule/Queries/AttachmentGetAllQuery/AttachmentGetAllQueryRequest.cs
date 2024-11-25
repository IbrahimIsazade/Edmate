using Domain.Entities;
using MediatR;

namespace Application.Modules.AttachmentModule.Queries.AttachmentGetAllQuery
{
    public class AttachmentGetAllQueryRequest : IRequest<IEnumerable<Attachment>> { }
}
