using Domain.Entities;
using MediatR;

namespace Application.Modules.FeatureModule.Commands.GetAllQuery
{
    public class FeatureGetAllQueryRequest : IRequest<IEnumerable<Award>>
    {
        // properties if they are needed
    }
}