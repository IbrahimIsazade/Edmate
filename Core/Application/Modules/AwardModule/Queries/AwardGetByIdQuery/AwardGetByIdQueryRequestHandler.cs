using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.AwardModule.Queries.AwardGetByIdQuery
{
    internal class AwardGetByIdQueryRequestHandler(IAwardRepository awardRepository) : IRequestHandler<AwardGetByIdQueryRequest, Award>
    {
        public async Task<Award> Handle(AwardGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await awardRepository.GetAsync(m => m.Id == request.Id);
        }
    }
}
