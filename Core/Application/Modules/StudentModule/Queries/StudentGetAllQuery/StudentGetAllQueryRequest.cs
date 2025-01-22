using Domain.Entities;
using MediatR;

namespace Application.Modules.StudentModule.Commands.GetAllQuery
{
    public class StudentGetAllQueryRequest : IRequest<IEnumerable<Award>>
    {
        // properties if they are needed
    }
}