using Domain.Entities.common;

namespace Domain.Entities
{
    public class Follower
    {
        public int FollowingId { get; set; }
        public int FollowedId { get; set; }
    }
}
