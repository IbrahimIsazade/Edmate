using Domain.Entities;
using MediatR;

namespace Application.Modules.FeatureModule.Commands.DeleteCommand
{
    public class FeatureDeleteCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}