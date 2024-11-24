using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.PlanModule.Commands.DeleteCommand
{
    internal class PlanDeleteCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<PlanDeleteCommandRequest, void>
    {
        public async Task<void> Handle(PlanDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}