using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Application.Modules.VideoModule.Queries.VideoGetByCourseIdQuery
{
    internal class VideoGetByCourseIdQueryRequestHandler(IVideoRepository videoRepository) : IRequestHandler<VideoGetByCourseIdQueryRequest, IEnumerable<Video>>
    {
        public async Task<IEnumerable<Video>> Handle(VideoGetByCourseIdQueryRequest request, CancellationToken cancellationToken)
        {
            var videos = from video in videoRepository.GetAll() where video.CourseId == request.Id
                         select video;

            var data = await videos.ToListAsync();

            if (data == null || data.Count == 0)
                throw new NotFoundException("Videos for course not found/empty");

            if (request.OrderNumber is not null)
            {
                var res = data.Where(m => m.OrderNumber == request.OrderNumber);
                return data;
            }

            return data;
        }
    }
}
