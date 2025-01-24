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
            var videos = await videoRepository
                .GetAll()
                .Where(video => video.CourseId == request.Id)
                .ToListAsync(cancellationToken);

            if (videos == null || videos.Count == 0)
                throw new NotFoundException("Videos for course not found/empty");

            if (request.OrderNumber is not -1)
            {
                var currentOrderNumber = request.OrderNumber.Value;

                while (true)
                {
                    var video = videos.Skip(currentOrderNumber).FirstOrDefault(v => v.OrderNumber == currentOrderNumber);

                    if (video != null)
                        return new List<Video> { video };

                    currentOrderNumber++;

                    if (currentOrderNumber > videos.Max(v => v.OrderNumber))
                        return Enumerable.Empty<Video>();
                }
            }

            return videos;
        }

    }
}
