using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.StudentModule.Commands.DeleteCommand
{
    internal class StudentDeleteCommandRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<StudentDeleteCommandRequest>
    {
        public Task Handle(StudentDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}