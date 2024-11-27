using Domain.Entities.common;

namespace Domain.Entities
{
    public class Mentor : AuditableEntity, IEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
        public int CategoryId { get; set; }
        public string ProfilePath { get; set; }
        public string CoverPath { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public int Likes { get; set; }
        public bool IsVerified { get; set; }
    }
}
