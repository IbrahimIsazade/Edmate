using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FollowerModule.Commands.AddCommand
{
    internal class FollowerAddCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<FollowerAddCommandRequest, Award>
    {
        public async Task<Award> Handle(FollowerAddCommandRequest request, CancellationToken cancellationToken)
        {
            return await entityService.AddAsync(request, awardRepository, cancellationToken);
        }
    }
}