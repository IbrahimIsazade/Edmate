using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Modules.CourseModule.Commands.CourseEditCommand
{
    public class CourseEditCommandRequest : IRequest<Domain.Entities.Course>
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int CategoryId { get; set; }
        public required IFormFile Thumbnail { get; set; }
    }
}