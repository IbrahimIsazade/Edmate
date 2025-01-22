using Domain.Entities.common;

namespace Domain.Entities
{
    public class Comment : AuditableEntity, IEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }
    }
}
