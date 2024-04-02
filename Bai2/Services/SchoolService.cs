using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bai2.Data;
using Bai2.Models;


namespace Bai2.Services // Thay YourNamespace bằng namespace của bạn
{
    public class SchoolService : ISchoolService
    {
        private readonly SchoolDbContext _db;

        public SchoolService(SchoolDbContext db)
        {
            _db = db;
        }

        #region Students

        public async Task<List<Student>> GetStudentsAsync()
        {
            try
            {
                var students = await _db.Students
                    .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                    .ToListAsync();

                // Now, each student object will contain the list of courses with their IDs
                return students;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return null;
            }
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            try
            {
                return await _db.Students.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            try
            {
                await _db.Students.AddAsync(student);
                await _db.SaveChangesAsync();
                return await _db.Students.FindAsync(student.StudentID); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occurred
            }
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            try
            {
                _db.Entry(student).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return student;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteStudentAsync(Student student)
        {
            try
            {
                var dbStudent = await _db.Students.FindAsync(student.StudentID);

                if (dbStudent == null)
                {
                    return (false, "Student could not be found.");
                }

                _db.Students.Remove(student);
                await _db.SaveChangesAsync();

                return (true, "Student got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occurred. Error Message: {ex.Message}");
            }
        }

        #endregion Students

        #region Courses

        public async Task<List<Course>> GetCoursesAsync()
        {
            try
            {
                return await _db.Courses.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Course> GetCourseAsync(int id)
        {
            try
            {
                return await _db.Courses.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Course> AddCourseAsync(Course course)
        {
            try
            {
                await _db.Courses.AddAsync(course);
                await _db.SaveChangesAsync();
                return await _db.Courses.FindAsync(course.CourseID); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occurred
            }
        }

        public async Task<Course> UpdateCourseAsync(Course course)
        {
            try
            {
                _db.Entry(course).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return course;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteCourseAsync(Course course)
        {
            try
            {
                var dbCourse = await _db.Courses.FindAsync(course.CourseID);

                if (dbCourse == null)
                {
                    return (false, "Course could not be found.");
                }

                _db.Courses.Remove(course);
                await _db.SaveChangesAsync();

                return (true, "Course got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occurred. Error Message: {ex.Message}");
            }
        }

        #endregion Courses
    }
}
