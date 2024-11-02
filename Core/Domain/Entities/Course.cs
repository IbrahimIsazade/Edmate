using Domain.Entities.common;

namespace Domain.Entities
{
    public class Course : AuditableEntity, IEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int CategoryId { get; set; }
        public required int MentorId { get; set; }
        public required int SubjectId { get; set; }
        public required decimal Rating { get; set; }
        public required string ThumbnailPath { get; set; }
        public required int Duration { get; set; } // int represents minutes. FE: 200 -> 2h 20m
    }
}
