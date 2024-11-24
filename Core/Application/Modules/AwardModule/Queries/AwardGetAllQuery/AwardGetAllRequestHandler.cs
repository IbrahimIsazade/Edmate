using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.AwardModule.Queries.AwardGetAllQuery
{
    internal class AwardGetAllRequestHandler(IAwardRepository awardRepository) : IRequestHandler<AwardGetAllRequest, IEnumerable<Award>>
    {
        public async Task<IEnumerable<Award>> Handle(AwardGetAllRequest request, CancellationToken cancellationToken)
        {
            return awardRepository.GetAll().ToList();
        }
    }
}
