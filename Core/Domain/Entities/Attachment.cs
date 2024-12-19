using Domain.Entities.common;

namespace Domain.Entities
{
    public class Attachment : AuditableEntity, IEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
    }
}
