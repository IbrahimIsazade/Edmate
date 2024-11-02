using Domain.Entities.common;

namespace Domain.Entities
{
    public class Plan : AuditableEntity, IEntity, ICreateableEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }

    }
}
