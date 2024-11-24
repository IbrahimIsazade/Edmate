using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.VideoModule.Commands.AddCommand
{
    internal class VideoAddCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<VideoAddCommandRequest, Award>
    {
        public async Task<Award> Handle(VideoAddCommandRequest request, CancellationToken cancellationToken)
        {
            return await entityService.AddAsync(request, awardRepository, cancellationToken);
        }
    }
}