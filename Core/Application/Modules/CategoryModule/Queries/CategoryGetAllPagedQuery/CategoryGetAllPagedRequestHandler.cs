using Application.common;
using Application.Extensions;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.CategoryModule.Queries.CategoryGetAllPagedQuery
{
    public class CategoryGetAllPagedRequestHandler(ICategoryRepository categoryRepository) : IRequestHandler<CategoryGetAllPagedRequest, IPagedResponse<Category>>
    {
        public async Task<IPagedResponse<Category>> Handle(CategoryGetAllPagedRequest request, CancellationToken cancellationToken)
        {
            var response = await categoryRepository.GetAll()
                .Sort(request)
                .ToPaginateAsync(request, cancellationToken);

            return response;
        }
    }
}
