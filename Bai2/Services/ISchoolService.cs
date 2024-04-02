using Bai2.Models; // Thay YourNamespace bằng namespace của bạn
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Bai2.Services // Thay YourNamespace bằng namespace của bạn
{
    public interface ISchoolService
    {
        // Student Services
        Task<List<Student>> GetStudentsAsync(); // GET All Students
        Task<Student> GetStudentAsync(int id); // GET Single Student
        Task<Student> AddStudentAsync(Student student); // POST New Student
        Task<Student> UpdateStudentAsync(Student student); // PUT Student
        Task<(bool, string)> DeleteStudentAsync(Student student); // DELETE Student

        // Course Services
        Task<List<Course>> GetCoursesAsync(); // GET All Courses
        Task<Course> GetCourseAsync(int id); // Get Single Course
        Task<Course> AddCourseAsync(Course course); // POST New Course
        Task<Course> UpdateCourseAsync(Course course); // PUT Course
        Task<(bool, string)> DeleteCourseAsync(Course course); // DELETE Course
    }
}
