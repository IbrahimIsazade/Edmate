using Domain.Entities;
using MediatR;

namespace Application.Modules.PlanModule.Commands.DeleteCommand
{
    public class PlanDeleteCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}