using Application.Services;
using MediatR;
using Repositories;

namespace Application.Modules.AwardModule.Commands.AwardDeleteCommand
{
    internal class AwardDeleteRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<AwardDeleteRequest>
    {
        public async Task Handle(AwardDeleteRequest request, CancellationToken cancellationToken)
        {
            await entityService.Delete(request, request.Id, awardRepository, cancellationToken);
        }
    }
}
