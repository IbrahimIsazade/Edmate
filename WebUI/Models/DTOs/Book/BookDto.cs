namespace WebUI.Models.DTOs.Book
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; } // Mentor (you should use IMentorRepository)
        public string ThumbnailPath { get; set; }
        public string PdfPath { get; set; }
        public int AproximateReading { get; set; }
    }
    
    public class BookRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
