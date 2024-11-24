using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FeatureModule.Commands.GetByIdQuery
{
    internal class FeatureGetByIdQueryRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<FeatureGetByIdQueryRequest, void>
    {
        public async Task<void> Handle(FeatureGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}