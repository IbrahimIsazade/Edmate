using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Repositories;

namespace Application.Modules.FeatureModule.Commands.EditCommand
{
    internal class FeatureEditCommandRequestHandler(IFeatureRepository featureRepository, IBookRepository bookRepository, IEntityService entityService) : IRequestHandler<FeatureEditCommandRequest, Feature>
    {
        public async Task<Feature> Handle(FeatureEditCommandRequest request, CancellationToken cancellationToken)
        {
            if (await bookRepository.GetAsync(m => m.Id == request.BookId, cancellationToken) == null)
                throw new NotFoundException("Book not found");

            return await entityService.Edit(request, request.Id, featureRepository, cancellationToken);
        }
    }
}