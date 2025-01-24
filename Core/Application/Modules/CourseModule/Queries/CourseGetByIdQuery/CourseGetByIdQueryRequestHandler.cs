using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Application.Modules.CourseModule.Queries.CourseGetByIdQuery
{
    internal class CourseGetByIdQueryRequestHandler(
        ICourseRepository courseRepository,
        IMentorRepository mentorRepository,
        ICategoryRepository categoryRepository,
        IAttachmentRepository attachmentRepository) : IRequestHandler<CourseGetByIdQueryRequest, CourseGetByIdResponse>
    {
        public async Task<CourseGetByIdResponse> Handle(CourseGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await (from course in courseRepository.GetAll() where course.Id == request.Id
                           join mentor in mentorRepository.GetAll() on course.MentorId equals mentor.Id
                           join category in categoryRepository.GetAll() on course.CategoryId equals category.Id
                           select new CourseGetByIdResponse()
                           {
                               Id = course.Id,
                               Title = course.Title,
                               Description = course.Description,
                               CategoryName = category.Name,
                               MentorName = mentor.FirstName + mentor.LastName,
                               MentorId = mentor.Id,
                               MentorProfilePath = mentor.ProfilePath,
                               Rating = course.Rating,
                               ThumbnailPath = course.ThumbnailPath,
                               Duration = course.Duration
                           }).SingleOrDefaultAsync();

            if (response == null)
                throw new NotFoundException("Course not found");

            return response;
        }
    }
}