using Application.Services;
using MediatR;
using Repositories;

namespace Application.Modules.FeatureModule.Commands.DeleteCommand
{
    internal class FeatureDeleteCommandRequestHandler(IFeatureRepository featureRepository, IEntityService entityService) : IRequestHandler<FeatureDeleteCommandRequest>
    {
        public async Task Handle(FeatureDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            await entityService.Delete(request, request.Id, featureRepository, cancellationToken);
        }
    }
}