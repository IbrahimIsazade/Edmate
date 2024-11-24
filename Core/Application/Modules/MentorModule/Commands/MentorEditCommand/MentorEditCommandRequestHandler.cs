using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.MentorModule.Commands.EditCommand
{
    internal class MentorEditCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<MentorEditCommandRequest, Award>
    {
        public async Task<Award> Handle(MentorEditCommandRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}