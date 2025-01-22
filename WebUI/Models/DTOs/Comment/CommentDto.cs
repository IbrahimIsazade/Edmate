namespace WebUI.Models.DTOs.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }
    }
}
