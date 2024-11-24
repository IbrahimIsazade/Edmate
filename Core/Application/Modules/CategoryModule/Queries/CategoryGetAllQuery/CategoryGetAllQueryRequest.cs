using Domain.Entities;
using MediatR;

namespace Application.Modules.CategoryModule.Queries.CategoryGetAllQuery
{
    public class CategoryGetAllQueryRequest : IRequest<IEnumerable<Category>>
    {
        // properties if they are needed
    }
}