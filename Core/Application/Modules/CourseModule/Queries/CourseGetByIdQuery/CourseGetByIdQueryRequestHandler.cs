using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.CourseModule.Commands.GetByIdQuery
{
    internal class CourseGetByIdQueryRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<CourseGetByIdQueryRequest, void>
    {
        public async Task<void> Handle(CourseGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}