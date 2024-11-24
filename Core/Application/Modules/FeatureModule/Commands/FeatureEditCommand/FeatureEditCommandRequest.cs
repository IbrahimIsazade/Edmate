using Domain.Entities;
using MediatR;

namespace Application.Modules.FeatureModule.Commands.EditCommand
{
    public class FeatureEditCommandRequest : IRequest<Award>
    {
        public int Id { get; set; } public int Name { get; set; }
    }
}