using Domain.Entities;
using MediatR;

namespace Application.Modules.PlanModule.Commands.EditCommand
{
    public class PlanEditCommandRequest : IRequest<Award>
    {
        public int Id { get; set; } public int Name { get; set; }
    }
}