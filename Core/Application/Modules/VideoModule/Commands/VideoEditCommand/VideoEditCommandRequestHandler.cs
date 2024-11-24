using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.VideoModule.Commands.EditCommand
{
    internal class VideoEditCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<VideoEditCommandRequest, Award>
    {
        public async Task<Award> Handle(VideoEditCommandRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}