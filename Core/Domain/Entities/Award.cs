using Domain.Entities.common;

namespace Domain.Entities
{
    public class Award : AuditableEntity, IEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int CourseId { get; set; }
    }
}
