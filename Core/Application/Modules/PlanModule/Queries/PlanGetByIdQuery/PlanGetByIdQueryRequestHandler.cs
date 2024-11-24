using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.PlanModule.Commands.GetByIdQuery
{
    internal class PlanGetByIdQueryRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<PlanGetByIdQueryRequest, void>
    {
        public async Task<void> Handle(PlanGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}