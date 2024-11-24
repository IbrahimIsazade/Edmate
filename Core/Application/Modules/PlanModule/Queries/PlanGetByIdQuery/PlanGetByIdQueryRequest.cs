using Domain.Entities;
using MediatR;

namespace Application.Modules.PlanModule.Commands.GetByIdQuery
{
    public class PlanGetByIdQueryRequest : IRequest
    {
        public int Id { get; set; }
    }
}