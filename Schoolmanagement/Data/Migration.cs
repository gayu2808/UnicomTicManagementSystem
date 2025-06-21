using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolmanagement.Data
{
    public static class Migration
    {
        public static void CreateTables()
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Courses (
                        CourseId INTEGER PRIMARY KEY AUTOINCREMENT,
                        CourseName TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Lecturers (
                        LecturerId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Phone TEXT NOT NULL,
                        Address TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Sections (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        SectionName TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Teachers (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        LecturerId INTEGER,
                        FOREIGN KEY (LecturerId) REFERENCES Lecturers(LecturerId)
                    );

                    CREATE TABLE IF NOT EXISTS Students (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Address TEXT NOT NULL,
                        SectionId INTEGER,
                        FOREIGN KEY (SectionId) REFERENCES Sections(Id)
                    );

                    CREATE TABLE IF NOT EXISTS Timetable (
                        StudentId INTEGER NOT NULL,
                        TeacherId INTEGER NOT NULL,
                        TimetableName TEXT NOT NULL,
                        PRIMARY KEY (StudentId, TeacherId),
                        FOREIGN KEY (StudentId) REFERENCES Students(Id),
                        FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
                    );

                    CREATE TABLE IF NOT EXISTS TeacherSections (
                        TeacherId INTEGER NOT NULL,
                        SectionId INTEGER NOT NULL,
                        PRIMARY KEY (TeacherId, SectionId),
                        FOREIGN KEY (TeacherId) REFERENCES Teachers(Id),
                        FOREIGN KEY (SectionId) REFERENCES Sections(Id)
                    );

                    CREATE TABLE IF NOT EXISTS Exams (
                        ExamId INTEGER PRIMARY KEY AUTOINCREMENT,
                        ExamName TEXT NOT NULL,
                        SubjectId INTEGER NOT NULL,
                        FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId)
                    );

                    CREATE TABLE IF NOT EXISTS Staffs (
                        StaffId INTEGER PRIMARY KEY AUTOINCREMENT,
                        StaffName TEXT NOT NULL,
                        StaffAddress TEXT NOT NULL,
                        
                        CourseId INTEGER,
                        FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
                    );

                    CREATE TABLE IF NOT EXISTS Subjects (
                        SubjectId INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectName TEXT NOT NULL,
                        CourseId INTEGER,
                        FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
                    );
                ";

                cmd.ExecuteNonQuery();
            }
        }
    }
}
