using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FollowerModule.Commands.GetByIdQuery
{
    internal class FollowerGetByIdQueryRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<FollowerGetByIdQueryRequest, void>
    {
        public async Task<void> Handle(FollowerGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}