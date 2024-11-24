using Domain.Entities;
using MediatR;

namespace Application.Modules.FollowerModule.Commands.GetByIdQuery
{
    public class FollowerGetByIdQueryRequest : IRequest
    {
        public int Id { get; set; }
    }
}