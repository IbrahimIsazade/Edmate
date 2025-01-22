using Application.Services;
using Domain.Exceptions;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FeatureModule.Commands.AddCommand
{
    internal class FeatureAddCommandRequestHandler(
        IFeatureRepository featureRepository, 
        IBookRepository bookRepository, 
        ICourseRepository courseRepository) : IRequestHandler<FeatureAddCommandRequest, Feature>
    {
        public async Task<Feature> Handle(FeatureAddCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = new Feature()
            {
                Title = request.Title,
                ItemId = request.ItemId,
                IsCourseFeature = request.IsCourse,
            };

            if (await courseRepository.GetAsync(m => m.Id == request.ItemId, cancellationToken) != null
                || await bookRepository.GetAsync(m => m.Id == request.ItemId, cancellationToken) != null)
            {
                await featureRepository.AddAsync(entity, cancellationToken);
                await featureRepository.SaveAsync(cancellationToken);

                return entity;
            }

            throw new NotFoundException("Entity not found (Handler)");
        }
    }
}