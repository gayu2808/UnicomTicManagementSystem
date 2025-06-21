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

            public class StaffRepository
            {
                public List<Staff> GetAllStaffs()
                {
                    var staffs = new List<Staff>();

                    using (var conn = DbConfig.GetConnection())
                    {
                string getguery = "SELECT  Staffs * FROM ";
                        var cmd = new SQLiteCommand(getguery, conn);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                        Staff staff = new Staff();

                        staff.StaffId = reader.GetInt32(0);
                        staff.Name = reader.GetString(1);


                                staffs.Add(staff);
                            }
                        }
                    }

                    return staffs;
                }

                public void AddStaff(Staff staff)
                {
                    using (var conn = DbConfig.GetConnection())
                    {
                        var cmd = new SQLiteCommand("INSERT INTO Staffs (StaffId, Name) VALUES (@StaffId, @Name)", conn);
                       
                        cmd.Parameters.AddWithValue("@Name", staff.Name ?? (object)DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                public void UpdateStaff(Staff staff)
                {
                    using (var conn = DbConfig.GetConnection())
                    {
                        var cmd = new SQLiteCommand("UPDATE Staffs SET Name = @Name WHERE StaffId = @StaffId", conn);
                        cmd.Parameters.AddWithValue("@Name", staff.Name ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@StaffId", staff.StaffId);
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

                public Staff GetStaffById(int staffId)
                {
                    using (var conn = DbConfig.GetConnection())
                    {
                        var cmd = new SQLiteCommand("SELECT StaffId, Name FROM Staffs WHERE StaffId = @StaffId", conn);
                        cmd.Parameters.AddWithValue("@StaffId", staffId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Staff
                                {
                                    StaffId = reader.GetInt32(0),
                                    Name = reader.IsDBNull(1) ? null : reader.GetString(1)
                                };
                            }
                        }
                    }
                    return null;
                }
            }    
}
