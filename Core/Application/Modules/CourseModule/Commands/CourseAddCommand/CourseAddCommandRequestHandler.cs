using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Modules.CourseModule.Commands.CourseAddCommand
{
    internal class CourseAddCommandRequestHandler(
        ICourseRepository courseRepository,
        ICategoryRepository categoryRepository,
        IMentorRepository mentorRepository,
        IAttachmentRepository attachmentRepository,
        IVideoRepository videoRepository,
        IFileService fileService,
        IAproximateTimeService aproximateTimeService) : IRequestHandler<CourseAddCommandRequest, Course>
    {
        public async Task<Course> Handle(CourseAddCommandRequest request, CancellationToken cancellationToken)
        {
            if (await categoryRepository.GetAsync(m => m.Id == request.CategoryId) == null)
            {
                throw new NotFoundException("Category not found");
            }

            if (await mentorRepository.GetAsync(m => m.Id == request.MentorId) == null)
            {
                throw new NotFoundException("Mentor not found");
            }

            var imagePath = await fileService.UploadAsync(request.Image, cancellationToken);

            var course = new Course()
            {
                Title = request.Title,
                Description = request.Description,
                CategoryId = request.CategoryId,
                MentorId = request.MentorId,
                Rating = 0,
                ThumbnailPath = imagePath,
                Duration = await aproximateTimeService.GetVideoDurationAsync(request.Video)
            };


            await courseRepository.AddAsync(course, cancellationToken);
            await courseRepository.SaveAsync(cancellationToken);
            
            var courseId = (from courses in courseRepository.GetAll() where courses.Description == request.Description select courses.Id).First();
            
            var attachment = new Attachment 
            { 
                Title = request.Title,
                CourseId = courseId,
                FilePath = await fileService.UploadAsync(request.Attachment)
            };

            var video = new Video
            { 
                Title = request.Title,
                CourseId = courseId,
                VideoPath = await fileService.UploadAsync(request.Video),
                Duration = await aproximateTimeService.GetVideoDurationAsync(request.Video)
            };


            await attachmentRepository.AddAsync(attachment);
            await attachmentRepository.SaveAsync(cancellationToken);

            await videoRepository.AddAsync(video);
            await videoRepository.SaveAsync(cancellationToken);

            return course;
        }
    }
}