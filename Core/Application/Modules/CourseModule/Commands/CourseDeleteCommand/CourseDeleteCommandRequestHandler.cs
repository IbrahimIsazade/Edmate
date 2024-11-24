using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.CourseModule.Commands.DeleteCommand
{
    internal class CourseDeleteCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<CourseDeleteCommandRequest, void>
    {
        public async Task<void> Handle(CourseDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}