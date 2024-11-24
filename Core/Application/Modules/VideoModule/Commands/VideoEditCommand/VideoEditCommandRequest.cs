using Domain.Entities;
using MediatR;

namespace Application.Modules.VideoModule.Commands.EditCommand
{
    public class VideoEditCommandRequest : IRequest<Award>
    {
        public int Id { get; set; } public int Name { get; set; }
    }
}