using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.MentorModule.Commands.GetByIdQuery
{
    internal class MentorGetByIdQueryRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<MentorGetByIdQueryRequest, void>
    {
        public async Task<void> Handle(MentorGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}