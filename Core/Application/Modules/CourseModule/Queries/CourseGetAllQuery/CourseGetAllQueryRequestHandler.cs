using MediatR;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Application.Modules.CourseModule.Queries.CourseGetAllQuery
{
    internal class CourseGetAllQueryRequestHandler(
        ICourseRepository courseRepository,
        IMentorRepository mentorRepository,
        ICategoryRepository categoryRepository,
        IVideoRepository videoRepository) : IRequestHandler<CourseGetAllQueryRequest, IEnumerable<CourseGetAllResponse>>
    {
        async Task<IEnumerable<CourseGetAllResponse>> IRequestHandler<CourseGetAllQueryRequest, IEnumerable<CourseGetAllResponse>>.Handle(CourseGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await (from course in courseRepository.GetAll()
                           join mentor in mentorRepository.GetAll() on course.MentorId equals mentor.Id
                           join category in categoryRepository.GetAll() on course.CategoryId equals category.Id
                           select new CourseGetAllResponse()
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
                               LessonsCount = videoRepository.GetAll().Where(m => m.CourseId == course.Id).Count(),
                               Duration = course.Duration
                           }).ToListAsync(cancellationToken);

            return response;
        }
    }
}