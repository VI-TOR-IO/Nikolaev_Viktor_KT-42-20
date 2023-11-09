using _3_lab.Models;

namespace _1_lab.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
