using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.StudentModule.Commands.GetByIdQuery
{
    internal class StudentGetByIdQueryRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<StudentGetByIdQueryRequest>
    {
        public Task Handle(StudentGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}