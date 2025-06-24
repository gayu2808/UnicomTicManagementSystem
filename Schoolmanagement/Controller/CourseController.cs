using Schoolmanagement.Data;
using Schoolmanagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolmanagement.Controller
{
    internal class CourseController
    {
        public void AddCourse(Course course)
        {
            using (var conn = DbConfig.GetConnection())
            {
                // Do not include the CourseId as SQLite will auto-generate it
                var cmd = new SQLiteCommand("INSERT INTO Courses (CourseName) VALUES (@Name)", conn);
                cmd.Parameters.AddWithValue("@Name", course.CourseName);
                cmd.ExecuteNonQuery();
            }
        }


        public List<Course> GetAllCourses()
        {
            var courses = new List<Course>();

            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT CourseId, CourseName FROM Courses", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var course = new Course
                        {
                            CourseId = reader.GetInt32(0),
                            CourseName = reader.GetString(1),
                        };
                        courses.Add(course);
                    }
                }
            }

            return courses;
        }

        public void UpdateCourse(Course course)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Courses SET CourseName = @Name WHERE CourseId = @CourseId", conn);
                cmd.Parameters.AddWithValue("@Name", course.CourseName);
                cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCourse(int courseId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Courses WHERE CourseId = @CourseId", conn);
                cmd.Parameters.AddWithValue("@CourseId", courseId);
                cmd.ExecuteNonQuery();
            }
        }

        public Course GetCourseById(int courseId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT CourseId, CourseName FROM Courses WHERE CourseId = @CourseId", conn);
                cmd.Parameters.AddWithValue("@CourseId", courseId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Course
                        {
                            CourseId = reader.GetInt32(0),
                            CourseName = reader.GetString(1)
                        };
                    }
                }
            }
            return null;
        }
    }
}


