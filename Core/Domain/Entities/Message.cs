using Domain.Entities.common;

namespace Domain.Entities
{
    public class Message : AuditableEntity, IAuditableEntity, IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public bool IsSeen { get; set; } = false;
    }
}
