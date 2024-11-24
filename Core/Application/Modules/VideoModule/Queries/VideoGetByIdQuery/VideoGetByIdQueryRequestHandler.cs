using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.VideoModule.Commands.GetByIdQuery
{
    internal class VideoGetByIdQueryRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<VideoGetByIdQueryRequest, void>
    {
        public async Task<void> Handle(VideoGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}