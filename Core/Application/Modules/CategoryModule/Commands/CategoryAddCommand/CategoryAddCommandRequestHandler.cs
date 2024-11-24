using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.CategoryModule.Commands.CategoryAddCommand
{
    internal class CategoryAddCommandRequestHandler(ICategoryRepository categoryRepository, IEntityService entityService) : IRequestHandler<CategoryAddCommandRequest, Category>
    {
        public async Task<Category> Handle(CategoryAddCommandRequest request, CancellationToken cancellationToken)
        {
            return await entityService.AddAsync(request, categoryRepository, cancellationToken);
        }
    }
}