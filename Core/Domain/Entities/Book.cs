using Domain.Entities.common;

namespace Domain.Entities
{
    public class Book : AuditableEntity, IEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int CategoryId { get; set; }
        public required int PublisherId { get; set; }
        public required string ThumbnailPath { get; set; }
        public required string PdfPath { get; set; }
        public required string AproximateReading { get; set; }
    }
}
