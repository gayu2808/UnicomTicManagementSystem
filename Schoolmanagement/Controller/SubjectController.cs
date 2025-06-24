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
    internal class SubjectController
    {
        public List<Subject> GetAllSubjects()
        {
            var subjects = new List<Subject>();

            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT SubjectId, SubjectName FROM Subjects", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var subject = new Subject
                        {
                            SubjectId = reader.GetInt32(0),
                            SubjectName = reader.GetString(1)
                        };
                        subjects.Add(subject);
                    }
                }
            }

            return subjects;
        }

        public void AddSubject(Subject subject)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Subjects (SubjectName) VALUES (@SubjectName)", conn);

                cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateSubject(Subject subject)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Subjects SET SubjectName = @SubjectName WHERE SubjectId = @SubjectId", conn);
                cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SubjectId", subject.SubjectId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSubject(int subjectId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Subjects WHERE SubjectId = @SubjectId", conn);
                cmd.Parameters.AddWithValue("@SubjectId", subjectId);
                cmd.ExecuteNonQuery();
            }
        }

        public Subject GetSubjectById(int subjectId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT SubjectId, SubjectName FROM Subjects WHERE SubjectId = @SubjectId", conn);
                cmd.Parameters.AddWithValue("@SubjectId", subjectId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Subject
                        {
                            SubjectId = reader.GetInt32(0),
                            SubjectName = reader.IsDBNull(1) ? null : reader.GetString(1)
                        };
                    }
                }
            }
            return null;
        }
    }
}



