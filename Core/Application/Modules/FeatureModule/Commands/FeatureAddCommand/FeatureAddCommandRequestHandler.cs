using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FeatureModule.Commands.AddCommand
{
    internal class FeatureAddCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<FeatureAddCommandRequest, Award>
    {
        public async Task<Award> Handle(FeatureAddCommandRequest request, CancellationToken cancellationToken)
        {
            return await entityService.AddAsync(request, awardRepository, cancellationToken);
        }
    }
}