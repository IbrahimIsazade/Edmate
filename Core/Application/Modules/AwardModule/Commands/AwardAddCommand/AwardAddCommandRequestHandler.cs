using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.AwardModule.Commands.AwardAddCommand
{
    internal class AwardAddCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<AwardAddCommandRequest, Award>
    {
        public async Task<Award> Handle(AwardAddCommandRequest request, CancellationToken cancellationToken)
        {
            return await entityService.AddAsync(request, awardRepository, cancellationToken);
        }
    }
}
