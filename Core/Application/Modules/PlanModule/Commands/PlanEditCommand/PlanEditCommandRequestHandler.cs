using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.PlanModule.Commands.EditCommand
{
    internal class PlanEditCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<PlanEditCommandRequest, Award>
    {
        public async Task<Award> Handle(PlanEditCommandRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}