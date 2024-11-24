using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.FollowerModule.Commands.DeleteCommand
{
    internal class FollowerDeleteCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<FollowerDeleteCommandRequest, void>
    {
        public async Task<void> Handle(FollowerDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}