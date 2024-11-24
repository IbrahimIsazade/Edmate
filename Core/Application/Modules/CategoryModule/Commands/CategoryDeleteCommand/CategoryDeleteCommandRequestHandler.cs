using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.CategoryModule.Commands.CategoryDeleteCommand
{
    internal class CategoryDeleteCommandRequestHandler(ICategoryRepository categoryRepository, IEntityService entityService) : IRequestHandler<CategoryDeleteCommandRequest>
    {
        async Task IRequestHandler<CategoryDeleteCommandRequest>.Handle(CategoryDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            await entityService.Delete(request, request.Id, categoryRepository, cancellationToken);
        }
    }
}