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
                            HasAdminRole = Convert.ToBoolean(reader["HasAdminRole"])
                        };
                        users.Add(userInfo);
                    }
                    con.Close();

                    return users.Any() ? users.FirstOrDefault() : null;
                }
            }
        }
    }
}
