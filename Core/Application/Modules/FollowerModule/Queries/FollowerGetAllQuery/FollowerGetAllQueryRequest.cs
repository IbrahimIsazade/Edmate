using Domain.Entities;
using MediatR;

namespace Application.Modules.FollowerModule.Commands.GetAllQuery
{
    public class FollowerGetAllQueryRequest : IRequest<IEnumerable<Follower>>
    {
        // properties if they are needed
    }
}