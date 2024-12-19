using Domain.Exceptions;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.VideoModule.Queries.VideoGetByIdQuery
{
    internal class VideoGetByIdQueryRequestHandler(IVideoRepository videoRepository) : IRequestHandler<VideoGetByIdQueryRequest, Video>
    {
        Task<Video> IRequestHandler<VideoGetByIdQueryRequest, Video>.Handle(VideoGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var entity = videoRepository.GetAsync(m => m.Id == request.Id);

            if (entity == null)
                throw new NotFoundException("Video not found");

            return entity;
        }
    }
}