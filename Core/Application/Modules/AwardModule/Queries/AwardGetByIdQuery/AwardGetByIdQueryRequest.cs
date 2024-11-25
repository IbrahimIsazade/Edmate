using Domain.Entities;
using MediatR;

namespace Application.Modules.AwardModule.Queries.AwardGetByIdQuery
{
    public class AwardGetByIdQueryRequest : IRequest<Award>
    {
        public int Id { get; set; }
    }
}
