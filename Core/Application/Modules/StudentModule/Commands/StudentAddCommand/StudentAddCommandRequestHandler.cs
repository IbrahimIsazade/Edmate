using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.StudentModule.Commands.AddCommand
{
    internal class StudentAddCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<StudentAddCommandRequest, Award>
    {
        public async Task<Award> Handle(StudentAddCommandRequest request, CancellationToken cancellationToken)
        {
            return await entityService.AddAsync(request, awardRepository, cancellationToken);
        }
    }
}