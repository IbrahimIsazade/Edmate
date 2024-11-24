using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.AttachmentModule.Commands.AttachmentAddCommnad
{
    internal class AttachmentAddCommandRequestHandler(IAttachmentRepository attachmentRepository, ICourseRepository courseRepository, IFileService fileService) : IRequestHandler<AttachmentAddCommandRequest, Attachment>
    {
        public async Task<Attachment> Handle(AttachmentAddCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await courseRepository.GetAsync(m => m.Id == request.CourseId);

            if (entity == null)
                throw new NotFoundException("Course with Id: " + request.CourseId + " was not found");

            var filePath = await fileService.UploadAsync(request.File);

            var attachment = new Attachment()
            {
                FilePath = filePath,
                CourseId = request.CourseId
            };

            await attachmentRepository.AddAsync(attachment);
            await attachmentRepository.SaveAsync();

            return attachment;
        }
    }
}
