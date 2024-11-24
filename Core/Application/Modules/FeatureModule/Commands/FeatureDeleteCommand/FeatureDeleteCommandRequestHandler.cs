using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FeatureModule.Commands.DeleteCommand
{
    internal class FeatureDeleteCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<FeatureDeleteCommandRequest, void>
    {
        public async Task<void> Handle(FeatureDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}