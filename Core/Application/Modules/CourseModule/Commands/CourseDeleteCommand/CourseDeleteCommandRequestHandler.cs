using Application.Services;
using MediatR;
using Repositories;

namespace Application.Modules.CourseModule.Commands.CourseDeleteCommand
{
    internal class CourseDeleteCommandRequestHandler(ICourseRepository courseRepository, IEntityService entityService) : IRequestHandler<CourseDeleteCommandRequest>
    {
        public async Task Handle(CourseDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            await entityService.Delete(request, request.Id, courseRepository, cancellationToken);
        }
    }
}