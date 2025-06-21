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
    internal class Markcontroller
    {
        public Markcontroller()
        {

        }
        public class MarkRepository
        {
            public List<Mark> GetAllMarks()
            {
                var marks = new List<Mark>();

                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT StudentId, Name FROM Exams", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var mark = new Mark
                            {
                                StudentId = reader.GetInt32(0),


                            };
                            marks.Add(mark);
                        }
                    }
                }

                return marks;
            }

            public void AddMark(Mark mark)
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("INSERT INTO Marks (StudentId, Score) VALUES (@ExamId, @Score)", conn);
                    cmd.Parameters.AddWithValue("@StudentId", mark.StudentId);
                    cmd.Parameters.AddWithValue("@Score", mark.Score);
                    cmd.ExecuteNonQuery();
                }
            }

            public void UpdateMark(Mark mark)
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("UPDATE Marks SET Score = @Score WHERE StudentId = @StudentId", conn);
                    cmd.Parameters.AddWithValue("@Score", mark.Score);
                    cmd.Parameters.AddWithValue("@CourseId", mark.StudentId);
                    cmd.ExecuteNonQuery();
                }
            }

            public void DeleteMark(int ExamId)
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("DELETE FROM Marks WHERE StudentId = @ExamId", conn);
                    cmd.Parameters.AddWithValue("@StudentId", ExamId);
                    cmd.ExecuteNonQuery();
                }
            }

            public Mark GetCourseById(int ExamId)
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT StudentId, Name FROM Marks WHERE ExamId = @StudentId", conn);
                    cmd.Parameters.AddWithValue("@StudentId", ExamId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Mark
                            {
                                StudentId = reader.GetInt32(0),
                                Score = reader.IsDBNull(1) ? null : reader.GetString(1)
                            };
                        }
                    }
                }
                return null;
            }


        }
    }
}
