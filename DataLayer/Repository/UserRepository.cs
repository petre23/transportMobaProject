using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class UserRepository: BaseRepository
    {
        public User Login(User user)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Login", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var users = new List<User>();
                    while (reader.Read())
                    {
                        var userInfo = new User()
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            SurName = reader["SurName"].ToString(),
                            HasAdminRole = Convert.ToBoolean(reader["HasAdminRole"])
                        };
                        users.Add(userInfo);
                    }
                    con.Close();

                    return users.Any() ? users.FirstOrDefault() : null;
                }
            }
        }

        public List<User> GetUsers()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetUsers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var users = new List<User>();
                    while (reader.Read())
                    {
                        var userInfo = new User()
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            SurName = reader["SurName"].ToString(),
                            HasAdminRole = Convert.ToBoolean(reader["HasAdminRole"])
                        };
                        users.Add(userInfo);
                    }
                    con.Close();

                    return users;
                }
            }
        }

        public User GetUser(Guid userId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var users = new List<User>();
                    while (reader.Read())
                    {
                        var userInfo = new User()
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            SurName = reader["SurName"].ToString(),
                            HasAdminRole = Convert.ToBoolean(reader["HasAdminRole"])
                        };
                        users.Add(userInfo);
                    }
                    con.Close();

                    return users.Any() ? users.FirstOrDefault() : null;
                }
            }
        }

        public Guid SaveUser(User user)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    var isNew = user.Id == Guid.Empty;
                    user.Id = isNew ? Guid.NewGuid() : user.Id;

                    cmd.Parameters.AddWithValue("@IsNew", isNew);
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@UserName", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@SurName", user.SurName);
                    cmd.Parameters.AddWithValue("@HasAdminRole", user.HasAdminRole);

                    con.Open();
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();

                    return user.Id;
                }
            }
        }

        public void DeleteUser(Guid userId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    con.Open();
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
