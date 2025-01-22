using Domain.Entities;
using MediatR;

namespace Application.Modules.FeatureModule.Commands.AddCommand
{
    public class FeatureAddCommandRequest : IRequest<Feature>
    {
        public string Title { get; set; }
        public int ItemId { get; set; }
        public bool IsCourse { get; set; }
    }
}