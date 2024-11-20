using Domain.Entities.common;

namespace Domain.Entities
{
    public class Award : AuditableEntity, IEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public required int Name { get; set; }
        public required int CourseId { get; set; }
    }
}
