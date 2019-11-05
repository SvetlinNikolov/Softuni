
namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Homework
    {
        
        public int HomeworkId { get; set; }
        public string Content { get; set; }
        public ContentTypes ContentType { get; set; }
        public DateTime SubmissionTime { get; set; }
        public Student MyProperty { get; set; }
        public int StudentId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
