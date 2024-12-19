namespace WebUI.Models.DTOs.Attachment
{
    public class AttachmentDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
    }
}
