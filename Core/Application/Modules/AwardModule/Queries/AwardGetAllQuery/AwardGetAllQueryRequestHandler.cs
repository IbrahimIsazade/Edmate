using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.AwardModule.Queries.AwardGetAllQuery
{
    internal class AwardGetAllQueryRequestHandler(IAwardRepository awardRepository) : IRequestHandler<AwardGetAllQueryRequest, IEnumerable<Award>>
    {
        public async Task<IEnumerable<Award>> Handle(AwardGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            return awardRepository.GetAll().ToList();
        }
    }
}
