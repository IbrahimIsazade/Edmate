namespace Application.Modules.CourseModule
{
    public class CourseGetAllResponse
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string CategoryName { get; set; }
        public required string MentorName { get; set; }
        public required string MentorProfilePath { get; set; }
        public required int MentorId { get; set; }
        public required decimal Rating { get; set; }
        public required string ThumbnailPath { get; set; }
        public required int LessonsCount { get; set; }
        public required int Duration { get; set; } // int represents minutes. FE: 200 -> 2h 20m
    }
    public class CourseGetByIdResponse
    {
        public int Id { get; set; }
        public  string Title { get; set; }
        public  string Description { get; set; }
        public  string CategoryName { get; set; }
        public  string MentorName { get; set; }
        public  string MentorProfilePath { get; set; }
        public  int MentorId { get; set; }
        public  decimal Rating { get; set; }
        public  string ThumbnailPath { get; set; }
        public  string? AttachmentPath { get; set; }
        public  int Duration { get; set; }
    }
}
