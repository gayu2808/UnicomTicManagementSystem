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
        public StudentController() 
        {
        
        }
        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();

            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
                    SELECT s.Id, s.Name, s.Address, s.CourseId, Cou.Name AS CourseName
                    FROM Students s
                    LEFT JOIN Courses cou ON s.courseId = sec.Id", conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student
                    {
                        StudentId = reader.GetInt32(0),
                        StudentName = reader.GetString(1),
                        StudentAddress = reader.GetString(2),
                        CourseId = reader.GetInt32(3),
                    };
                    students.Add(student);

                }
            }

            return students;
        }
        public void AddStudent(Student student)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var command = new SQLiteCommand("INSERT INTO Students (Name, Address, CourseId) VALUES (@Name, @Address, @CourseId)", conn);
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
                var command = new SQLiteCommand("UPDATE Students SET Name = @Name, Address = @Address, CourseId = @CourseId WHERE Id = @Id", conn);
                command.Parameters.AddWithValue("@Name", student.StudentName);
                command.Parameters.AddWithValue("@Address", student.StudentAddress);
                command.Parameters.AddWithValue("@Course Id", student.CourseId);
                command.Parameters.AddWithValue("@Id", student.StudentId);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int studentId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var command = new SQLiteCommand("DELETE FROM Students WHERE Id = @Id", conn);
                command.Parameters.AddWithValue("@Id", studentId);
                command.ExecuteNonQuery();
            }
        }

        public Student GetStudentById(int id)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Students WHERE Id = @Id", conn);
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
                            CourseId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
                        };
                    }
                }
            }

            return null;
        }
    }
}
