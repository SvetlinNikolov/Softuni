
namespace P01_StudentSystem.Data.Models
{

    public class Resource
    {
        public int ResourceId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int ResourceType { get; set; } 
        public Course Course { get; set; } 
        public int CourseId { get; set; }
    }
}
