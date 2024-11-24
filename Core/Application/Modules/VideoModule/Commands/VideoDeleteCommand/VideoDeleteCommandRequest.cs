using Domain.Entities;
using MediatR;

namespace Application.Modules.VideoModule.Commands.DeleteCommand
{
    public class VideoDeleteCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}