using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.MentorModule.Commands.DeleteCommand
{
    internal class MentorDeleteCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<MentorDeleteCommandRequest, void>
    {
        public async Task<void> Handle(MentorDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}