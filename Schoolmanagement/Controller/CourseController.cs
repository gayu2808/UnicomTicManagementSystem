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
        public CourseController()
        {

        }
        public class CourseRepository
        {
            public List<Course> GetAllCourses()
            {
                var courses = new List<Course>();

                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT CourseId, Name FROM Courses", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var course = new Course
                            {
                                CourseId = reader.GetInt32(0),


                            };
                            courses.Add(course);
                        }
                    }
                }

                return courses;
            }

            public void AddCourse(Course course)
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("INSERT INTO Courses (CourseId, Name) VALUES (@CourseId, @Name)", conn);
                    cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                    cmd.Parameters.AddWithValue("@Name", course.CourseName ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }

            public void UpdateCourse(Course course)
            {
                using (var conn = DbConfig.GetConnection()) 
                {
                    var cmd = new SQLiteCommand("UPDATE Courses SET Name = @Name WHERE CourseId = @CourseId", conn);
                    cmd.Parameters.AddWithValue("@Name", course.CourseName ?? (object)DBNull.Value);
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
                    var cmd = new SQLiteCommand("SELECT CourseId, Name FROM Courses WHERE CourseId = @CourseId", conn);
                    cmd.Parameters.AddWithValue("@CourseId", courseId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Course
                            {
                                CourseId = reader.GetInt32(0),
                                CourseName = reader.IsDBNull(1) ? null : reader.GetString(1)
                            };
                        }
                    }
                }
                return null;
            }
        }
    }
}


