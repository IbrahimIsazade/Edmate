using Domain.Entities;
using MediatR;

namespace Application.Modules.FollowerModule.Commands.EditCommand
{
    public class FollowerEditCommandRequest : IRequest<Award>
    {
        public int Id { get; set; } public int Name { get; set; }
    }
}