using System.Text.Json.Serialization;

namespace Bai2.Models
{
    public class StudentCourse
    {
        public int? StudentID { get; set; }
        public int? CourseID { get; set; }

        [JsonIgnore]
        public Student? Student { get; set; }

        [JsonIgnore]
        public Course? Course { get; set; }
    }
}
