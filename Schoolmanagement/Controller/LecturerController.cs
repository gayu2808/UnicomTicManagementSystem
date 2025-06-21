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
    internal class LecturerController
    {

        public LecturerController() 
        {
        
        }
        public List<Lecturer> GetAllLecturers()
        {
            var lecturers= new List<Lecturer>();

            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
                    SELECT le.Id, le.Name, le.Address, le.CourseId, Cou.Name AS CourseName
                    FROM Lecturers le
                    LEFT JOIN Courses cou ON le.courseId = le.Id", conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Lecturer Lecturer = new Lecturer
                    {
                        LecturerId = reader.GetInt32(0),
                        LecturerName = reader.GetString(1),
                        LecturerAddress = reader.GetString(2),
                        PhoneNumber = reader.GetInt32(3),
                        CourseId = reader.GetInt32(4),
                    };
                    Lecturer.Add(Lecturer);

                }
            }

            return lecturers;
        }
        public void AddLecturers(Lecturer lecturer)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var command = new SQLiteCommand("INSERT INTO Lecturers (Name, Address, CourseId) VALUES (@Name, @Address, @CourseId)", conn);
                command.Parameters.AddWithValue("@Name", lecturer.LecturerName);
                command.Parameters.AddWithValue("@Address", lecturer.LecturerAddress);
                command.Parameters.AddWithValue("@CourseId", lecturer.CourseId);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateLecturers(Lecturer lecturer)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var command = new SQLiteCommand("UPDATE Lecturers SET Name = @Name, Address = @Address, CourseId = @CourseId WHERE Id = @Id", conn);
                command.Parameters.AddWithValue("@Name", lecturer.LecturerName);
                command.Parameters.AddWithValue("@Address", lecturer.LecturerAddress);
                command.Parameters.AddWithValue("@Course Id", lecturer.CourseId);
                command.Parameters.AddWithValue("@Id", lecturer.LecturerId);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteLecturers(int lecturerId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var command = new SQLiteCommand("DELETE FROM Lecturers WHERE Id = @Id", conn);
                command.Parameters.AddWithValue("@Id", lecturerId);
                command.ExecuteNonQuery();
            }
        }

        public Lecturer GetLecturertById(int lecturerId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM  Lecturers WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", lecturerId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Lecturer
                        {
                            LecturerId = reader.GetInt32(0),
                            LecturerName = reader.GetString(1),
                            LecturerAddress = reader.GetString(2),
                            CourseId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
                        };
                    }
                }
            }

            return null;
        }
    }
}
