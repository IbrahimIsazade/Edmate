using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.CourseModule.Commands.CourseAddCommand
{
    internal class CourseAddCommandRequestHandler(
        ICourseRepository courseRepository,
        ICategoryRepository categoryRepository,
        IMentorRepository mentorRepository,
        IFileService fileService) : IRequestHandler<CourseAddCommandRequest, Course>
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

            var filePath = await fileService.UploadAsync(request.Thumbnail, cancellationToken);

            var course = new Course()
            {
                Title = request.Title,
                Description = request.Description,
                CategoryId = request.CategoryId,
                MentorId = request.MentorId,
                Rating = 0,
                ThumbnailPath = filePath,
                Duration = 0,
            };

            await courseRepository.AddAsync(course, cancellationToken);
            await courseRepository.SaveAsync(cancellationToken);

            return course;
        }
    }
}