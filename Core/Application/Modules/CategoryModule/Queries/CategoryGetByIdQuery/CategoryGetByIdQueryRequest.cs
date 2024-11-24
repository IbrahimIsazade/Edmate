using Domain.Entities;
using MediatR;

namespace Application.Modules.CategoryModule.Queries.CategoryGetByIdQuery
{
    public class CategoryGetByIdQueryRequest : IRequest<Category>
    {
        public int Id { get; set; }
    }
}