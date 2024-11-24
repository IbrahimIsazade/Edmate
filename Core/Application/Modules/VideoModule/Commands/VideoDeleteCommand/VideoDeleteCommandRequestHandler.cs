using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.VideoModule.Commands.DeleteCommand
{
    internal class VideoDeleteCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<VideoDeleteCommandRequest, void>
    {
        public async Task<void> Handle(VideoDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}