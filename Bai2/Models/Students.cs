using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bai2.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string? Name { get; set; }


        public List<StudentCourse>? StudentCourses { get; set; }
    }
}
