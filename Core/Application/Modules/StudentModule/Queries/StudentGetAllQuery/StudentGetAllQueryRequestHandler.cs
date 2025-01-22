using Application.Services;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Application.Modules.StudentModule.Commands.GetAllQuery
{
    internal class StudentGetAllQueryRequestHandler(IAwardRepository awardRepository, IEntityService entityService) : IRequestHandler<StudentGetAllQueryRequest, IEnumerable<Award>>
    {
        public async Task<IEnumerable<Award>> Handle(StudentGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}