using Domain.Entities;
using MediatR;

namespace Application.Modules.CategoryModule.Commands.CategoryDeleteCommand
{
    public class CategoryDeleteCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}