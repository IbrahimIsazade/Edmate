using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.AwardModule.Commands.AwardEditCommand
{
    internal class AwardEditCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<AwardEditCommandRequest, Award>
    {
        public async Task<Award> Handle(AwardEditCommandRequest request, CancellationToken cancellationToken)
        {
            return await entityService.Edit(request, request.Id, awardRepository, cancellationToken);
        }
    }
}
