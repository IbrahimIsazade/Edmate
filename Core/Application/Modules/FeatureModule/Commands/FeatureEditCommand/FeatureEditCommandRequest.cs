using Domain.Entities;
using MediatR;

namespace Application.Modules.FeatureModule.Commands.EditCommand
{
    public class FeatureEditCommandRequest : IRequest<Feature>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int BookId { get; set; }
    }
}