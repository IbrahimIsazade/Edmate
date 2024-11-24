using Domain.Entities;
using MediatR;

namespace Application.Modules.FeatureModule.Commands.GetByIdQuery
{
    public class FeatureGetByIdQueryRequest : IRequest
    {
        public int Id { get; set; }
    }
}