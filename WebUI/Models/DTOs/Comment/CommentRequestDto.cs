namespace WebUI.Models.DTOs.Comment
{
    public class CommentRequestDto
    {
        public string Content { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public int? CommentId { get; set; }
    }
}
