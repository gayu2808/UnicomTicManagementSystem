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
        public List<Lecturer> GetAllLecturers()
        {
            var lecturers = new List<Lecturer>();

            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
        SELECT LecturerId, Name, Address,Phone FROM Lecturers", conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Lecturer lecturer = new Lecturer
                    {
                        LecturerId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        Phone = reader.GetString(3),
                    };
                    lecturers.Add(lecturer);
                }
            }

            return lecturers;
        }


        public void AddLecturers(Lecturer lecturer)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var command = new SQLiteCommand("INSERT INTO Lecturers (Name, Address, Phone) VALUES (@Name, @Address, @Phone)", conn);
                command.Parameters.AddWithValue("@Name", lecturer.Name);
                command.Parameters.AddWithValue("@Address", lecturer.Address);
                command.Parameters.AddWithValue("@Phone", lecturer.Phone);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateLecturers(Lecturer lecturer)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var command = new SQLiteCommand("UPDATE Lecturers SET Name = @Name, Address = @Address, Phone = @Phone WHERE LecturerId = @Id", conn);
                command.Parameters.AddWithValue("@Name", lecturer.Name);
                command.Parameters.AddWithValue("@Address", lecturer.Address);
                command.Parameters.AddWithValue("@Phone", lecturer.Phone);
                command.Parameters.AddWithValue("@Id", lecturer.LecturerId); 
                command.ExecuteNonQuery();
            }
        }

        public void DeleteLecturers(int lecturerId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var command = new SQLiteCommand("DELETE FROM Lecturers WHERE LecturerId = @Id", conn);
                command.Parameters.AddWithValue("@Id", lecturerId);
                command.ExecuteNonQuery();
            }
        }

        public Lecturer GetLecturertById(int lecturerId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Lecturers WHERE LecturerId = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", lecturerId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Lecturer
                        {
                            LecturerId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Address = reader.GetString(2),
                            Phone = reader.GetString(3),
                        };
                    }
                }
            }

            return null;
        }
    }
}
