using Domain.Exceptions

using Domain.Entities;
using MediatR;
using Repositories;
using Application.Services;

namespace Application.Modules.CourseModule.Commands.CourseEditCommand
{
    internal class CourseEditCommandRequestHandler(ICourseRepository courseRepository, ICategoryRepository categoryRepository, IFileService fileService) : IRequestHandler<CourseEditCommandRequest, Course>
    {
        public async Task<Course> Handle(CourseEditCommandRequest request, CancellationToken cancellationToken)
        {
            var course = await courseRepository.GetAsync(m => m.Id == request.Id);

            if (await categoryRepository.GetAsync(m => m.Id == request.CategoryId) == null)
                throw new NotFoundException("Category not found");

            if (request.Thumbnail != null)
            {
                var filePath = await fileService.UploadAsync(request.Thumbnail);
                course.ThumbnailPath = filePath;
            }

            course.Title = request.Title;
            course.Description = request.Description;
            course.CategoryId = request.CategoryId;

            courseRepository.Edit(course);
            await courseRepository.SaveAsync(cancellationToken);

            return course;
        }
    }
}