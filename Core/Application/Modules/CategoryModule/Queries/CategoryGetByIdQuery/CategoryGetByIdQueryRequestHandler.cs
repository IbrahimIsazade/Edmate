using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.CategoryModule.Queries.CategoryGetByIdQuery
{
    internal class CategoryGetByIdQueryRequestHandler(ICategoryRepository categoryRepository) : IRequestHandler<CategoryGetByIdQueryRequest, Category>
    {
        async Task<Category> IRequestHandler<CategoryGetByIdQueryRequest, Category>.Handle(CategoryGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await categoryRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
        }
    }
}