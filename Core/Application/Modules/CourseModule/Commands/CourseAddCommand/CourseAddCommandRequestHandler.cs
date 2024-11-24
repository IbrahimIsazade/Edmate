using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.CourseModule.Commands.AddCommand
{
    internal class CourseAddCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<CourseAddCommandRequest, Award>
    {
        public async Task<Award> Handle(CourseAddCommandRequest request, CancellationToken cancellationToken)
        {
            return await entityService.AddAsync(request, awardRepository, cancellationToken);
        }
    }
}