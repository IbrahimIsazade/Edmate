using Domain.Entities.common;

namespace Domain.Entities
{
    public class Category : AuditableEntity, IEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
