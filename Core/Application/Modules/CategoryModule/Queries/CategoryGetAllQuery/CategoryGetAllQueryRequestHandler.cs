using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.CategoryModule.Queries.CategoryGetAllQuery
{
    internal class CategoryGetAllQueryRequestHandler(ICategoryRepository categoryRepository) : IRequestHandler<CategoryGetAllQueryRequest, IEnumerable<Category>>
    {
        public async Task<IEnumerable<Category>> Handle(CategoryGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            return categoryRepository.GetAll().ToList();
        }
    }
}