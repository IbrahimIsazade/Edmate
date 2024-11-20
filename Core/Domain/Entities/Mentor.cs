using Domain.Entities.common;

namespace Domain.Entities
{
    public class Mentor : AuditableEntity, IEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Location { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Bio { get; set; }
        public required int CategoryId { get; set; }
        public required string ProfilePath { get; set; }
        public required string CoverPath { get; set; }
        public required int Followers { get; set; }
        public required int Following { get; set; }
        public required int Likes { get; set; }
        public required bool IsVerified { get; set; }
    }
}
