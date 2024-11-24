using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.AwardModule.Commands.AwardAddCommand
{
    internal class AwardAddRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<AwardAddRequest, Award>
    {
        public async Task<Award> Handle(AwardAddRequest request, CancellationToken cancellationToken)
        {
            return await entityService.AddAsync(request, awardRepository, cancellationToken);
        }
    }
}
