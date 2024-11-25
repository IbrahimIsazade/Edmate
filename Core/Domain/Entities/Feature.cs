using Domain.Entities.common;

namespace Domain.Entities
{
    public class Feature : AuditableEntity, IEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int BookId { get; set; }
    }
}
