using Domain.Entities;
using MediatR;

namespace Application.Modules.VideoModule.Commands.AddCommand
{
    public class VideoAddCommandRequest : IRequest<Award>
    {
        public int Name { get; set; }
    }
}