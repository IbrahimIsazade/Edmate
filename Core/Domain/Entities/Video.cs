using Domain.Entities.common;

namespace Domain.Entities
{
    public class Video : AuditableEntity, IEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string VideoPath { get; set; }
        public required int CourseId { get; set; }
        public required int CoursePartId { get; set; }
        public required int Duration { get; set; } // means minutes. FE: 200 -> 3h 20m
    }
}
