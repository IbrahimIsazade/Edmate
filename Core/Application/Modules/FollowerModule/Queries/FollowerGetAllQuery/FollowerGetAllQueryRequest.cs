using Domain.Entities;
using MediatR;

namespace Application.Modules.FollowerModule.Commands.GetAllQuery
{
    public class FollowerGetAllQueryRequest : IRequest<IEnumerable<Award>>
    {
        // properties if they are needed
    }
}