using Domain.Entities.common;

namespace Domain.Entities
{
    public class Student : IEntity
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string ProfileImagePath { get; set; }
        public required bool IsStudying { get; set; }
        public required int PlanId { get; set; }
    }
}
