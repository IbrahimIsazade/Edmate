using Domain.Entities;
using MediatR;

namespace Application.Modules.FollowerModule.Commands.DeleteCommand
{
    public class FollowerDeleteCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}