using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.VideoModule.Queries.VideoGetAllQuery
{
    internal class VideoGetAllQueryRequestHandler(IVideoRepository videoRepository) : IRequestHandler<VideoGetAllQueryRequest, IEnumerable<Video>>
    {
        public async Task<IEnumerable<Video>> Handle(VideoGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            return videoRepository.GetAll().ToList();
        }
    }
}