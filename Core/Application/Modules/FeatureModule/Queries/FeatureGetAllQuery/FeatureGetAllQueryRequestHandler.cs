using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Application.Modules.FeatureModule.Commands.GetAllQuery
{
    internal class FeatureGetAllQueryRequestHandler(IFeatureRepository featureRepository) : IRequestHandler<FeatureGetAllByIdQueryRequest, IEnumerable<Feature>>
    {
        public async Task<IEnumerable<Feature>> Handle(FeatureGetAllByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await (from features in featureRepository.GetAll() where (features.IsCourseFeature == request.IsCourse) && (features.ItemId == request.Id)
                           select features).ToListAsync(cancellationToken);

            if (response is null)
                throw new ArgumentNullException(nameof(response));

            return response;
        }
    }
}