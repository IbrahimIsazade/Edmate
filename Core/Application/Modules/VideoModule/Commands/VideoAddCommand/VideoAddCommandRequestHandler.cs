using Application.Services;
using Domain.Entities;
using MediatR;
using Domain.Exceptions;
using Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Modules.VideoModule.Commands.VideoAddCommand
{
    internal class VideoAddCommandRequestHandler(
        IVideoRepository videoRepository,
        ICourseRepository courseRepository,
        //IAproximateTimeService aproximateTimeService,
        IFileService fileService) : IRequestHandler<VideoAddCommandRequest, Video>
    {
        public async Task<Video> Handle(VideoAddCommandRequest request, CancellationToken cancellationToken)
        {
            var course = await courseRepository.GetAsync(m => m.Id == request.CourseId);

            if (course == null)
                throw new NotFoundException("Course not found");

            var videosOfCourseQuery = from videos in videoRepository.GetAll()
                                      where videos.CourseId == request.CourseId
                                      select videos.OrderNumber;

            var videosOfCourse = await videosOfCourseQuery.ToListAsync();

            var entity =  new Video()
            {
                Title = !String.IsNullOrWhiteSpace(request.Title) ? request.Title : throw new ArgumentNullException("Title is null"),
                VideoPath = await fileService.UploadAsync(request.Video),
                CourseId = request.CourseId,
                Duration = /*await aproximateTimeService.GetVideoDuration(request.Video)*/ 1,
                OrderNumber = !videosOfCourse.Any() ? 1 : videosOfCourse.Last() + 1
            };

            await videoRepository.AddAsync(entity, cancellationToken);
            await videoRepository.SaveAsync(cancellationToken);

            return entity;
        }
    }
}