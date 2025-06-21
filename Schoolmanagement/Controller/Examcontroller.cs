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
        
        
    }
    public class ExamRepository
    {
        public List<Exam> GetAllExams()
        {
            var exams = new List<Exam>();

            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT ExamsId, Name FROM Exams", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var exam = new Exam
                        {
                            ExamId = reader.GetInt32(0),


                        };
                        exams.Add(exam);
                    }
                }
            }

            return exams;
        }

        public void AddExam(Exam exam)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Exams (ExamId, Name) VALUES (@ExamId, @Name)", conn);
                cmd.Parameters.AddWithValue("@ExamId",exam.ExamId);
                cmd.Parameters.AddWithValue("@Name", exam.ExamName ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateExam(Exam exam)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Exams SET Name = @Name WHERE ExamId = @ExamId", conn);
                cmd.Parameters.AddWithValue("@Name", exam.ExamName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ExamId", exam.ExamId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteExam(int examId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Exams WHERE ExamId = @ExamId", conn);
                cmd.Parameters.AddWithValue("@CourseId", examId);
                cmd.ExecuteNonQuery();
            }
        }

        public Exam GetExamById(int ExamId) 
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT ExamId, Name FROM Exams WHERE ExamId = @ExamId", conn);
                cmd.Parameters.AddWithValue("@ExamId", ExamId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Exam
                        {
                            ExamId = reader.GetInt32(0),
                            ExamName = reader.IsDBNull(1) ? null : reader.GetString(1)
                        };
                    }
                }
            }
            return null;
        }
    }
}


    

