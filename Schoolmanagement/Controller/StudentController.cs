using Schoolmanagement.Data;
using Schoolmanagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolmanagement.Controller
{
    internal class StudentController
    {
        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();

            using (var conn = DbConfig.GetConnection())
            {
                string query = @"
            SELECT s.StudentId, s.StudentName, s.StudentAddress, s.CourseId, cou.CourseName AS CourseName
            FROM Students s
            LEFT JOIN Courses cou ON s.CourseId = cou.CourseId";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var student = new Student
                        {
                            StudentId = reader.GetInt32(0),
                            StudentName = reader.GetString(1),
                            StudentAddress = reader.GetString(2),
                            CourseId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                            CourseName = reader.IsDBNull(4) ? null : reader.GetString(4)
                        };

                        students.Add(student);
                    }
                }
            }

            return students;
        }

        public void AddStudent(Student student)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var command = new SQLiteCommand(@"
                    INSERT INTO Students (StudentName, StudentAddress, CourseId) 
                    VALUES (@Name, @Address, @CourseId)", conn);

                command.Parameters.AddWithValue("@Name", student.StudentName);
                command.Parameters.AddWithValue("@Address", student.StudentAddress);
                command.Parameters.AddWithValue("@CourseId", student.CourseId);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var command = new SQLiteCommand(@"
                    UPDATE Students 
                    SET StudentName = @Name, StudentAddress = @Address, CourseId = @CourseId 
                    WHERE StudentId = @Id", conn);

                command.Parameters.AddWithValue("@Name", student.StudentName);
                command.Parameters.AddWithValue("@Address", student.StudentAddress);
                command.Parameters.AddWithValue("@CourseId", student.CourseId);
                command.Parameters.AddWithValue("@Id", student.StudentId);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int studentId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var command = new SQLiteCommand("DELETE FROM Students WHERE StudentId = @Id", conn);
                command.Parameters.AddWithValue("@Id", studentId);
                command.ExecuteNonQuery();
            }
        }

        public Student GetStudentById(int id)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
            SELECT s.StudentId, s.StudentName, s.StudentAddress, s.CourseId, cou.CourseName AS CourseName
            FROM Students s
            LEFT JOIN Courses cou ON s.CourseId = cou.CourseId
            WHERE s.StudentId = @Id", conn);

                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Student
                        {
                            StudentId = reader.GetInt32(0),
                            StudentName = reader.GetString(1),
                            StudentAddress = reader.GetString(2),
                            CourseId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                            CourseName = reader.IsDBNull(4) ? null : reader.GetString(4)
                        };
                    }
                }
            }

            return null;
        }
    }
}
