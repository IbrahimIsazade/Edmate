using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FollowerModule.Commands.GetAllQuery
{
    internal class FollowerGetAllQueryRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<FollowerGetAllQueryRequest, IEnumerable<Award>>
    {
        public async Task<IEnumerable<Award>> Handle(FollowerGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}