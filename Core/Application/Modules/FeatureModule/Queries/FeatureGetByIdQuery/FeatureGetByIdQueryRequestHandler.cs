using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FeatureModule.Commands.GetByIdQuery
{
    internal class FeatureGetByIdQueryRequestHandler(IFeatureRepository featureRepository) : IRequestHandler<FeatureGetByIdQueryRequest, Feature>
    {
        public async Task<Feature> Handle(FeatureGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await featureRepository.GetAsync(m => m.Id == request.Id);
        }
    }
}