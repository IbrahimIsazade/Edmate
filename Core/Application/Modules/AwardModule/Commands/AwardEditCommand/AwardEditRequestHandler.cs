using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.AwardModule.Commands.AwardEditCommand
{
    internal class AwardEditRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<AwardEditRequest, Award>
    {
        public async Task<Award> Handle(AwardEditRequest request, CancellationToken cancellationToken)
        {
            return await entityService.Edit(request, request.Id, awardRepository, cancellationToken);
        }
    }
}
