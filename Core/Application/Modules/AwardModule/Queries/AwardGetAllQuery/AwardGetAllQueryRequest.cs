using Domain.Entities;
using MediatR;

namespace Application.Modules.AwardModule.Queries.AwardGetAllQuery
{
    public class AwardGetAllQueryRequest : IRequest<IEnumerable<Award>>
    {
    }
}
