using Domain.Entities;
using MediatR;

namespace Application.Modules.AttachmentModule.Queries.AttachmentGetAllQuery
{
    public class AttachmentGetAllRequest : IRequest<IEnumerable<Attachment>> { }
}
