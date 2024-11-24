using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.StudentModule.Commands.EditCommand
{
    internal class StudentEditCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<StudentEditCommandRequest, Award>
    {
        public async Task<Award> Handle(StudentEditCommandRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}