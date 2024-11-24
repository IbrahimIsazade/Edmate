using Domain.Entities;
using MediatR;

namespace Application.Modules.PlanModule.Commands.GetAllQuery
{
    public class PlanGetAllQueryRequest : IRequest<IEnumerable<Award>>
    {
        // properties if they are needed
    }
}