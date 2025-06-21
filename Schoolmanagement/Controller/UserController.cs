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
    internal class UserController
    {

        public UserController()
        {

        }
        public class UserRepository
        {
            public List<User> GetAllUsers()
            {
                var users = new List<User>();

                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT UserId, Name FROM Users", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User
                            {
                                UserId = reader.GetInt32(0),


                            };
                            users.Add(user);
                        }
                    }
                }

                return users;
            }

            public void AddUser(User user)
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("INSERT INTO Users (UserId, Name) VALUES (@UserId, @Name)", conn);
                    cmd.Parameters.AddWithValue("@UserId", user.UserId);
                    cmd.Parameters.AddWithValue("@Name", user.UserName ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }

            public void UpdateUser(User user)
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("UPDATE Users SET Name = @Name WHERE UserId = @UserId", conn);
                    cmd.Parameters.AddWithValue("@Name", user.UserName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserId", user.UserId);
                    cmd.ExecuteNonQuery();
                }
            }

            public void DeleteUser(int userId)
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("DELETE FROM Users WHERE UserId = @UserId", conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();
                }
            }

            public User GetUserById(int userId)
            {
                using (var conn = DbConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT UserId, Name FROM Users WHERE UserId = @UserId", conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = reader.GetInt32(0),
                                UserName = reader.IsDBNull(1) ? null : reader.GetString(1)
                            };
                        }
                    }
                }
                return null;
            }
        }
    }
}

    

