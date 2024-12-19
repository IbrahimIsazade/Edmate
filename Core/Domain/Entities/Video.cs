using Domain.Entities.common;

namespace Domain.Entities
{
    public class Video : AuditableEntity, IEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public  string Title { get; set; }
        public  string VideoPath { get; set; }
        public  int CourseId { get; set; }
        public  int OrderNumber { get; set; }
        public  int Duration { get; set; } // means minutes. FE: 200 -> 3h 20m
    }
}
