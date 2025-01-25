using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.BookModule
{
    public class BookResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int PublisherId { get; set; } // Mentor (you should use IMentorRepository)
        public string PublisherName { get; set; } // Mentor (you should use IMentorRepository)
        public string PubllisherProfilePath { get; set; } // Mentor (you should use IMentorRepository)
        public string ThumbnailPath { get; set; }
        public string PdfPath { get; set; }
        public int AproximateReading { get; set; }
    }
}
