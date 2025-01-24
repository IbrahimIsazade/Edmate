using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.DTOs.Video
{
    public class VideoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string VideoPath { get; set; }
        public int CourseId { get; set; }
        public int OrderNumber { get; set; }
        public int Duration { get; set; }
    }

    public class VideoRequestDto
    {
        public string Title { get; set; }

        [Required]
        public IFormFile Video { get; set; }
        public int CourseId { get; set; }
    }

    public class VideoGetByCourseIdQueryRequest
    {
        public int Id { get; set; }
        public int? OrderNumber { get; set; }
    }
}
