using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FeatureModule.Commands.GetAllQuery
{
    internal class FeatureGetAllQueryRequestHandler(IFeatureRepository featureRepository) : IRequestHandler<FeatureGetAllQueryRequest, IEnumerable<Feature>>
    {
        public async Task<IEnumerable<Feature>> Handle(FeatureGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            return featureRepository.GetAll().ToList();
        }
    }
}