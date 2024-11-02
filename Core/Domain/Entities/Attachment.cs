using Domain.Entities.common;

namespace Domain.Entities
{
    public class Attachment : AuditableEntity, IEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public required int CourseId { get; set; }
        public required string FilePath { get; set; }
    }
}
