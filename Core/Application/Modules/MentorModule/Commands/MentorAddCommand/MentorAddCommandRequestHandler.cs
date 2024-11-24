using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.MentorModule.Commands.AddCommand
{
    internal class MentorAddCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<MentorAddCommandRequest, Award>
    {
        public async Task<Award> Handle(MentorAddCommandRequest request, CancellationToken cancellationToken)
        {
            return await entityService.AddAsync(request, awardRepository, cancellationToken);
        }
    }
}