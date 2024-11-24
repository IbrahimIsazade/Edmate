using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.PlanModule.Commands.GetAllQuery
{
    internal class PlanGetAllQueryRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<PlanGetAllQueryRequest, IEnumerable<Award>>
    {
        public async Task<IEnumerable<Award>> Handle(PlanGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}