using Domain.Entities.common;

namespace Domain.Entities
{
    public class Follower
    {
        public required int FollowerId { get; set; }
        public required int FollowedId { get; set; }
    }
}
