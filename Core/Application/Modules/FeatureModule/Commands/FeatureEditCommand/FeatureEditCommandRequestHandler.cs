using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FeatureModule.Commands.EditCommand
{
    internal class FeatureEditCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<FeatureEditCommandRequest, Award>
    {
        public async Task<Award> Handle(FeatureEditCommandRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}