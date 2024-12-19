using Domain.Entities;
using MediatR;

namespace Application.Modules.VideoModule.Commands.VideoDeleteCommand
{
    public class VideoDeleteCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}