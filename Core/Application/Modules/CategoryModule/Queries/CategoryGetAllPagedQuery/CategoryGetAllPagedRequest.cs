using Application.common;
using Domain.Entities;
using Domain.StableModels;
using MediatR;

namespace Application.Modules.CategoryModule.Queries.CategoryGetAllPagedQuery
{
    public class CategoryGetAllPagedRequest : Pageable, IRequest<IPagedResponse<Category>>, IPageable, ISortable
    {
        public string Column {get; set;}

        public SortOrder Order {get; set;}
    }
}
