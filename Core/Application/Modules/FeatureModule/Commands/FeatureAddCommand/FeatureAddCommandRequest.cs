using Domain.Entities;
using MediatR;

namespace Application.Modules.FeatureModule.Commands.AddCommand
{
    public class FeatureAddCommandRequest : IRequest<Feature>
    {
        public required string Title { get; set; }
        public required int BookId { get; set; }
    }
}