using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.StudentModule.Commands.DeleteCommand
{
    internal class StudentDeleteCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<StudentDeleteCommandRequest, void>
    {
        public async Task<void> Handle(StudentDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}