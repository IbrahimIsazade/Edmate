namespace Domain.Entities
{
    public class BlockedUser
    {
        public required int BlockerId { get; set; }
        public required int BlockedId { get; set; }
    }
}
