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
    public class BrandRepository:BaseRepository
    {
        public List<Brand> GetBrands()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetBrands", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var brands = new List<Brand>();
                    while (reader.Read())
                    {
                        var brand = new Brand()
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            Value = Convert.ToInt32(reader["Value"].ToString()),
                            Name = reader["Name"].ToString()
                        };
                        brands.Add(brand);
                    }
                    con.Close();

                    return brands;
                }
            }
        }
    }
}
