using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Modules.CourseModule.Commands.CourseEditCommand
{
    public class CourseEditCommandRequest : IRequest<Domain.Entities.Course>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public IFormFile? Thumbnail { get; set; }
    }
}