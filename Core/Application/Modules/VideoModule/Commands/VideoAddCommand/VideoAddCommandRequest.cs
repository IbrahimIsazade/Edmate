using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Modules.VideoModule.Commands.VideoAddCommand
{
    public class VideoAddCommandRequest : IRequest<Video>
    {
        public string Title { get; set; }
        public IFormFile Video { get; set; }
        public int CourseId { get; set; }
    }
}