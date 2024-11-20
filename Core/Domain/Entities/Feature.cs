using Domain.Entities.common;

namespace Domain.Entities
{
    public class Feature : AuditableEntity, IEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required int BookId { get; set; }
    }
}
