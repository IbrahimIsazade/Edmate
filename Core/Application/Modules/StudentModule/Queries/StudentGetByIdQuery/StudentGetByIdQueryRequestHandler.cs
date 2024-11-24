using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.StudentModule.Commands.GetByIdQuery
{
    internal class StudentGetByIdQueryRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<StudentGetByIdQueryRequest, void>
    {
        public async Task<void> Handle(StudentGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            // Logic here
        }
    }
}