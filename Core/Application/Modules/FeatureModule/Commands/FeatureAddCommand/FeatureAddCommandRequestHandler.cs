using Application.Services;
using Domain.Exceptions;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FeatureModule.Commands.AddCommand
{
    internal class FeatureAddCommandRequestHandler(IFeatureRepository featureRepository, IBookRepository bookRepository, IEntityService entityService) : IRequestHandler<FeatureAddCommandRequest, Feature>
    {
        public async Task<Feature> Handle(FeatureAddCommandRequest request, CancellationToken cancellationToken)
        {
            if (await bookRepository.GetAsync(m => m.Id == request.BookId, cancellationToken) == null)
                throw new NotFoundException("Book not found");

            return await entityService.AddAsync(request, featureRepository, cancellationToken);
        }
    }
}