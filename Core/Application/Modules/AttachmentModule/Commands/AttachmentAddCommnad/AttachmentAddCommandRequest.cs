using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Modules.AttachmentModule.Commands.AttachmentAddCommnad
{
    public class AttachmentAddCommandRequest : IRequest<Attachment>
    {
        public required int CourseId { get; set; }
        public required IFormFile File { get; set; }
    }
}
