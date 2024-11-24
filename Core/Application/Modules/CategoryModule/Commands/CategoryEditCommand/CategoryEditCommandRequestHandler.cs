using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.CategoryModule.Commands.CategoryEditCommand
{
    internal class CategoryEditCommandRequestHandler(ICategoryRepository categoryRepository, IEntityService entityService) : IRequestHandler<CategoryEditCommandRequest, Category>
    {
        public async Task<Category> Handle(CategoryEditCommandRequest request, CancellationToken cancellationToken)
        {
            return await entityService.Edit(request, request.Id, categoryRepository, cancellationToken);
        }
    }
}