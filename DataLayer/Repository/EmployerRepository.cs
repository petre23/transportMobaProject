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
    public class EmployerRepository: BaseRepository
    {
        public List<Employer> GetEmployers()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetEmployers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var employers = new List<Employer>();
                    while (reader.Read())
                    {
                        var employer = new Employer()
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            Value = Convert.ToInt32(reader["Value"].ToString()),
                            Name = reader["Name"].ToString()
                        };
                        employers.Add(employer);
                    }
                    con.Close();

                    return employers;
                }
            }
        }
    }
}
