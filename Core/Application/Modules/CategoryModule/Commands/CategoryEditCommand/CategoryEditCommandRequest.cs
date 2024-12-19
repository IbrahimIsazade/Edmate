using Domain.Entities;
using MediatR;

namespace Application.Modules.CategoryModule.Commands.CategoryEditCommand
{
    public class CategoryEditCommandRequest : IRequest<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}