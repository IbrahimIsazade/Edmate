using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.MentorModule.Commands.GetAllQuery
{
    internal class MentorGetAllQueryRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<MentorGetAllQueryRequest, IEnumerable<Award>>
    {
        public async Task<IEnumerable<Award>> Handle(MentorGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}