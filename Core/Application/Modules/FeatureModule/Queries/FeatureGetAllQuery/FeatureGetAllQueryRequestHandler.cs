using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FeatureModule.Commands.GetAllQuery
{
    internal class FeatureGetAllQueryRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<FeatureGetAllQueryRequest, IEnumerable<Award>>
    {
        public async Task<IEnumerable<Award>> Handle(FeatureGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}