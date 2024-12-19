using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.DTOs.Course
{
    public class CourseDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int CategoryId { get; set; }
        public required int MentorId { get; set; }
        public required decimal Rating { get; set; }
        public required string ThumbnailPath { get; set; }
        public required int Duration { get; set; } // int represents minutes. FE: 200 -> 2h 20m
    }

    public class CourseAddRequestDto
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
