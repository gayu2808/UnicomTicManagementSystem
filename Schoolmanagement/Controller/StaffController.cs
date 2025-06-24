using Schoolmanagement.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schoolmanagement.Models;

namespace Schoolmanagement.Controller
{
    public class StaffController
    {
        public void AddStaff(StaffForm staff)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
                    INSERT INTO Staffs (StaffName, StaffAddress, CourseId )
                    VALUES (@StaffName, @StaffAddress, @CourseId)", conn);

                cmd.Parameters.AddWithValue("@StaffName", staff.StaffName);
                cmd.Parameters.AddWithValue("@StaffAddress", staff.StaffAddress);
                cmd.Parameters.AddWithValue("@CourseId", staff.CourseId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<StaffForm> GetAllStaffs()
        {
            var staffs = new List<StaffForm>();

            using (var conn = DbConfig.GetConnection())
            {
                string query = "SELECT StaffId, StaffName, StaffAddress, CourseId FROM Staffs";
                var cmd = new SQLiteCommand(query, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var staff = new StaffForm
                        {
                            StaffId = reader.GetInt32(0),
                            StaffName = reader.GetString(1),
                            StaffAddress = reader.GetString(2),
                            CourseId = reader.GetInt32(3)
                        };

                        staffs.Add(staff);
                    }
                }
            }
            return staffs;
        }

        public void UpdateStaff(StaffForm staff)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
                    UPDATE Staffs 
                    SET StaffName = @StaffName, StaffAddress = @StaffAddress, CourseId = @CourseId
                    WHERE StaffId = @StaffId", conn);

                cmd.Parameters.AddWithValue("@StaffName", staff.StaffName);
                cmd.Parameters.AddWithValue("@StaffAddress", staff.StaffAddress);
                cmd.Parameters.AddWithValue("@CourseId", staff.CourseId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStaff(int staffId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Staffs WHERE StaffId = @StaffId", conn);
                cmd.Parameters.AddWithValue("@StaffId", staffId);
                cmd.ExecuteNonQuery();
            }
        }

        public StaffForm GetStaffById(int staffId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
                    SELECT StaffId, StaffName, StaffAddress, CourseId
                    FROM Staffs 
                    WHERE StaffId = @StaffId", conn);

                cmd.Parameters.AddWithValue("@StaffId", staffId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new StaffForm
                        {
                            StaffId = reader.GetInt32(0),
                            StaffName = reader.GetString(1),
                            StaffAddress = reader.GetString(2),
                            CourseId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                        };
                    }
                }
            }

            return null;
        }
    }
}

    
