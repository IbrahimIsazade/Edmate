using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FollowerModule.Commands.EditCommand
{
    internal class FollowerEditCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<FollowerEditCommandRequest, Award>
    {
        public async Task<Award> Handle(FollowerEditCommandRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}