using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.VideoModule.Commands.GetAllQuery
{
    internal class VideoGetAllQueryRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<VideoGetAllQueryRequest, IEnumerable<Award>>
    {
        public async Task<IEnumerable<Award>> Handle(VideoGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}