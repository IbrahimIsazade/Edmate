using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.PlanModule.Commands.AddCommand
{
    internal class PlanAddCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<PlanAddCommandRequest, Award>
    {
        public async Task<Award> Handle(PlanAddCommandRequest request, CancellationToken cancellationToken)
        {
            return await entityService.AddAsync(request, awardRepository, cancellationToken);
        }
    }
}