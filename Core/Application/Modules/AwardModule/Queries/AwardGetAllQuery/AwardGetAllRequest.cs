using Domain.Entities;
using MediatR;

namespace Application.Modules.AwardModule.Queries.AwardGetAllQuery
{
    public class AwardGetAllRequest : IRequest<IEnumerable<Award>>
    {
    }
}
