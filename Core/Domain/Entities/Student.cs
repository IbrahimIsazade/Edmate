using Domain.Entities.common;

namespace Domain.Entities
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ProfileImagePath { get; set; }
        public bool IsStudying { get; set; }
        public int PlanId { get; set; }
    }
}
