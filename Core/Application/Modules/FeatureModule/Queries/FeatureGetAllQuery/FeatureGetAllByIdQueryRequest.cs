using Domain.Entities;
using MediatR;

namespace Application.Modules.FeatureModule.Commands.GetAllQuery
{
    public class FeatureGetAllByIdQueryRequest : IRequest<IEnumerable<Feature>>
    {
        public int Id { get; set; }
        public bool IsCourse { get; set; }
    }
}