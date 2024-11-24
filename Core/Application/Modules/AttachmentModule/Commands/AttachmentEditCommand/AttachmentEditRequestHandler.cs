using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.AttachmentModule.Commands.AttachmentEditCommand
{
    internal class AttachmentEditRequestHandler(IAttachmentRepository attachmentRepository, ICourseRepository courseRepository, IFileService fileService) : IRequestHandler<AttachmentEditRequest, Attachment>
    {
        public async Task<Attachment> Handle(AttachmentEditRequest request, CancellationToken cancellationToken)
        {
            var attachment = await attachmentRepository.GetAsync(m => m.Id == request.Id);

            var entity = await courseRepository.GetAsync(m => m.Id == request.CourseId);

            if (entity == null)
                throw new NotFoundException("Course with Id: " + request.CourseId + " was not found");

            var filePath = await fileService.UploadAsync(request.File);

            attachment.FilePath = filePath;
            attachment.CourseId = request.CourseId;

            attachmentRepository.Edit(attachment);
            await attachmentRepository.SaveAsync();

            return attachment;
        }
    }
}
