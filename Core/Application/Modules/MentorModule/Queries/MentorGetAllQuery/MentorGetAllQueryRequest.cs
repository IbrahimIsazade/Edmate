using Domain.Entities;
using MediatR;

namespace Application.Modules.MentorModule.Commands.GetAllQuery
{
    public class MentorGetAllQueryRequest : IRequest<IEnumerable<Award>>
    {
        // properties if they are needed
    }
}