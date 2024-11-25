using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Modules.CourseModule.Commands.CourseAddCommand
{
    public class CourseAddCommandRequest : IRequest<Course>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int MentorId { get; set; }
        public IFormFile Thumbnail { get; set; }
        public int Duration { get; set; } // int represents minutes. FE: 200 -> 2h 20m
    }
}