using Domain.Entities.common;

namespace Domain.Entities
{
    public class Comment : AuditableEntity, IEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public required int CourseId { get; set; }
        public required int UserId { get; set; }
        public int? CommentId { get; set; }
    }
}
