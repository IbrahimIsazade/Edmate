using Domain.Entities;
using MediatR;

namespace Application.Modules.FeatureModule.Commands.AddCommand
{
    public class FeatureAddCommandRequest : IRequest<Award>
    {
        public int Name { get; set; }
    }
}