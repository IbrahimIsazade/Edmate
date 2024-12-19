using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Modules.CourseModule.Commands.CourseAddCommand
{
    public class CourseAddCommandRequest : IRequest<Course>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int MentorId { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        [Required]
        public IFormFile Video { get; set; }
        public string VideoTitle { get; set; }

        [Required]
        public IFormFile Attachment { get; set; }
        public string AttachmentTitle { get; set; }
        public string AttachmentDescription { get; set; }
    }
}