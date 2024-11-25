using Application.Services;
using MediatR;
using Repositories;

namespace Application.Modules.AwardModule.Commands.AwardDeleteCommand
{
    internal class AwardDeleteCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<AwardDeleteCommandRequest>
    {
        public async Task Handle(AwardDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            await entityService.Delete(request, request.Id, awardRepository, cancellationToken);
        }
    }
}
