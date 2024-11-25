using Domain.Entities;
using MediatR;

namespace Application.Modules.FeatureModule.Commands.GetAllQuery
{
    public class FeatureGetAllQueryRequest : IRequest<IEnumerable<Feature>>
    {
        // properties if they are needed
    }
}