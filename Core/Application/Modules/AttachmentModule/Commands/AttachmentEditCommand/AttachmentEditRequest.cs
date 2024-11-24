using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Modules.AttachmentModule.Commands.AttachmentEditCommand
{
    public class AttachmentEditRequest : IRequest<Attachment>
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public IFormFile File { get; set; }
    }
}
