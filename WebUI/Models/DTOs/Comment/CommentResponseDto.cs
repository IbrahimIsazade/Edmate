namespace WebUI.Models.DTOs.Comment
{
    public class CommentResponseDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public string ProfilePath { get; set; }
        public bool IsMentor { get; set; }
    }
}
