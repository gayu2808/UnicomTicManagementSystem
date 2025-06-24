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
    public class Examcontroller
    {
        public void AddExam(Exam exam)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Exams (ExamName, SubjectId) VALUES (@Name, @SubjectId)", conn);
                cmd.Parameters.AddWithValue("@Name", exam.ExamName);
                cmd.Parameters.AddWithValue("@SubjectId", exam.SubjectId); // Assuming SubjectId is part of the 'exam' object
                cmd.ExecuteNonQuery();

            }
        }

        public List<Exam> GetAllExams()
        {
            var exams = new List<Exam>();

            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand(
                    @"SELECT Exams.ExamName, Subjects.SubjectId 
              FROM Exams 
              LEFT JOIN Subjects ON Exams.SubjectId = Subjects.SubjectId",
                    conn);

                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var exam = new Exam()
                    {
                        ExamName = reader["ExamName"].ToString(),
                        // Check if SubjectId is DBNull and handle accordingly
                        SubjectId = reader["SubjectId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SubjectId"]),
                    };

                    exams.Add(exam);
                }
            }

            return exams;
        }



        public void UpdateExam(Exam exam)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Exams SET ExamName = @Name WHERE ExamId = @ExamId", conn);
                cmd.Parameters.AddWithValue("@Name", exam.ExamName);
                cmd.Parameters.AddWithValue("@ExamId", exam.ExamId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteExam(int examId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Exams WHERE ExamId = @ExamId", conn);
                cmd.Parameters.AddWithValue("@ExamId", examId);
                cmd.ExecuteNonQuery();
            }
        }

        public Exam GetExamById(int ExamId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT ExamId, ExamName FROM Exams WHERE ExamId = @ExamId", conn);
                cmd.Parameters.AddWithValue("@ExamId", ExamId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Exam
                        {
                            ExamId = reader.GetInt32(0),
                            ExamName = reader.GetString(1)
                        };
                    }
                }
            }
            return null;
        }
    }
}
    

