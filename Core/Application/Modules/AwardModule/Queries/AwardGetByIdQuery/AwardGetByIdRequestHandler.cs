using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.AwardModule.Queries.AwardGetByIdQuery
{
    internal class AwardGetByIdRequestHandler(IAwardRepository awardRepository) : IRequestHandler<AwardGetByIdRequest, Award>
    {
        public async Task<Award> Handle(AwardGetByIdRequest request, CancellationToken cancellationToken)
        {
            return await awardRepository.GetAsync(m => m.Id == request.Id);
        }
    }
}
