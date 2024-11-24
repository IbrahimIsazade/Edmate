using Domain.Entities;
using MediatR;

namespace Application.Modules.AwardModule.Queries.AwardGetByIdQuery
{
    public class AwardGetByIdRequest : IRequest<Award>
    {
        public int Id { get; set; }
    }
}
