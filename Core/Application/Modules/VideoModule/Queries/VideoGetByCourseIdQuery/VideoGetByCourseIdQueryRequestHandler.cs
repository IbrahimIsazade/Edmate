using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Application.Modules.VideoModule.Queries.VideoGetByCourseIdQuery
{
    internal class VideoGetByCourseIdQueryRequestHandler(IVideoRepository videoRepository, ICourseRepository courseRepository) : IRequestHandler<VideoGetByCourseIdQueryRequest, IEnumerable<Video>>
    {
        public async Task<IEnumerable<Video>> Handle(VideoGetByCourseIdQueryRequest request, CancellationToken cancellationToken)
        {
            var videos = from video in videoRepository.GetAll()
                         join course in courseRepository.GetAll() on video.CourseId equals course.Id
                         where course.Id == request.Id
                         select video;

            var data = await videos.ToListAsync();

            if (data == null || data.Count == 0)
                throw new NotFoundException("Videos for course not found");

            return data;
        }
    }
}
