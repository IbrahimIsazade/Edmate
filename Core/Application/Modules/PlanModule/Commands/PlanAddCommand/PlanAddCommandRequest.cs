using Domain.Entities;
using MediatR;

namespace Application.Modules.PlanModule.Commands.AddCommand
{
    public class PlanAddCommandRequest : IRequest<Award>
    {
        public int Name { get; set; }
    }
}