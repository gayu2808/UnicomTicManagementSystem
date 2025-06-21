using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schoolmanagement.Data;
using Schoolmanagement.Models;

namespace Schoolmanagement.Controller
{
    internal class Timetablecontroll
    {
        public void AddTimetable(Timetable timetable)
        {
            using (var conn = DbConfig.GetConnection())
            {
                conn.Open();

                var cmd = new SQLiteCommand("INSERT INTO Timetables (SubjectId, Name) VALUES (@SubjectId, @Name)", conn);
                cmd.Parameters.AddWithValue("@SubjectId", timetable.TimetableId);
                cmd.Parameters.AddWithValue("@Name", timetable.TimetableName ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Timetable> GetTimetables()
        {
            var timetables = new List<Timetable>();

            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT SubjectId, Name FROM Timetables", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var timetable = new Timetable
                        {
                            TimetableId = reader.GetInt32(0),
                            TimetableName = reader.IsDBNull(1) ? null : reader.GetString(1)
                        };
                        timetables.Add(timetable);
                    }
                }
            }

            return timetables;
        }

        public void UpdateTimetable(Timetable timetable)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Timetables SET Name = @Name WHERE SubjectId = @SubjectId", conn);
                cmd.Parameters.AddWithValue("@Name", timetable.TimetableName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SubjectId", timetable.TimetableId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTimetable(int timetableId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Timetables WHERE SubjectId = @SubjectId", conn);
                cmd.Parameters.AddWithValue("@SubjectId", timetableId);
                cmd.ExecuteNonQuery();
            }
        }

        public Timetable GetTimetableById(int timetableId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT SubjectId, Name FROM Timetables WHERE SubjectId = @SubjectId", conn);
                cmd.Parameters.AddWithValue("@SubjectId", timetableId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Timetable
                        {
                            TimetableId = reader.GetInt32(0),
                            TimetableName = reader.IsDBNull(1) ? null : reader.GetString(1)
                        };
                    }
                }
            }
            return null;
        }
    }
}
