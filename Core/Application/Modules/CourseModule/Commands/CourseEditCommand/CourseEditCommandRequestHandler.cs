using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.CourseModule.Commands.EditCommand
{
    internal class CourseEditCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<CourseEditCommandRequest, Award>
    {
        public async Task<Award> Handle(CourseEditCommandRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}