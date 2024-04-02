using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bai2.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public List<StudentCourse>? StudentCourses { get; set; }
    }
}
