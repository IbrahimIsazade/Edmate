using Domain.Entities;
using MediatR;

namespace Application.Modules.CategoryModule.Commands.CategoryAddCommand
{
    public class CategoryAddCommandRequest : IRequest<Category>
    {
        public string Name { get; set; }
    }
}