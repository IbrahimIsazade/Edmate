using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.CourseModule.Commands.GetAllQuery
{
    internal class CourseGetAllQueryRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<CourseGetAllQueryRequest, IEnumerable<Award>>
    {
        public async Task<IEnumerable<Award>> Handle(CourseGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}