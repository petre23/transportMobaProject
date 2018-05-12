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
    public class TruckRepository: BaseRepository
    {
        BrandRepository _brandRepository = new BrandRepository();

        public List<Truck> GetTrucks()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetTrucks", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var trucks = new List<Truck>();
                    while (reader.Read())
                    {
                        var truck = new Truck()
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            Brand = Guid.Parse(reader["Brand"].ToString()),
                            BrandDropDownValue = Convert.ToInt32(reader["BrandDropDownValue"]),
                            BrandName = reader["BrandName"].ToString(),
                            ConformCopyExpirationDate = Convert.ToDateTime(reader["ConformCopyExpirationDate"].ToString()),
                            InsuranceExpirationDate = Convert.ToDateTime(reader["InsuranceExpirationDate"].ToString()),
                            ITPExpirationDate = Convert.ToDateTime(reader["ITPExpirationDate"].ToString()),
                            ManufacturingYear = Convert.ToDateTime(reader["ManufacturingYear"].ToString()),
                            RegistrationNumber = reader["RegistrationNumber"].ToString(),
                            TachographExpirationDate = Convert.ToDateTime(reader["TachographExpirationDate"].ToString()),
                            VignetteExpirationDate = Convert.ToDateTime(reader["VignetteExpirationDate"].ToString())
                        };
                        trucks.Add(truck);
                    }
                    con.Close();

                    return trucks;
                }
            }
        }

        public Guid SaveTruck(Truck truck)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveTruck", con))
                {
                    var brands = _brandRepository.GetBrands();
                    truck.Brand = brands.FirstOrDefault(x => x.Value == truck.BrandDropDownValue).Id;

                    cmd.CommandType = CommandType.StoredProcedure;
                    var isNew = truck.Id == Guid.Empty;
                    truck.Id = isNew ? new Guid() : truck.Id;
                    cmd.Parameters.AddWithValue("@IsNew", isNew);
                    cmd.Parameters.AddWithValue("@Id", truck.Id);
                    cmd.Parameters.AddWithValue("@Brand", truck.Brand);
                    cmd.Parameters.AddWithValue("@ConformCopyExpirationDate", truck.ConformCopyExpirationDate);
                    cmd.Parameters.AddWithValue("@InsuranceExpirationDate", truck.InsuranceExpirationDate);
                    cmd.Parameters.AddWithValue("@ITPExpirationDate", truck.ITPExpirationDate);
                    cmd.Parameters.AddWithValue("@ManufacturingYear", truck.ManufacturingYear);
                    cmd.Parameters.AddWithValue("@RegistrationNumber", truck.RegistrationNumber);
                    cmd.Parameters.AddWithValue("@TachographExpirationDate", truck.TachographExpirationDate);
                    cmd.Parameters.AddWithValue("@VignetteExpirationDate", truck.VignetteExpirationDate);
                    con.Open();
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();

                    return truck.Id;
                }
            }
        }

        public Truck GetTruck(Guid idTruck)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetTruck", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TruckId",idTruck);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var trucks = new List<Truck>();
                    while (reader.Read())
                    {
                        var truck = new Truck()
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            Brand = Guid.Parse(reader["Brand"].ToString()),
                            BrandDropDownValue = Convert.ToInt32(reader["BrandDropDownValue"]),
                            BrandName = reader["BrandName"].ToString(),
                            ConformCopyExpirationDate = Convert.ToDateTime(reader["ConformCopyExpirationDate"].ToString()),
                            InsuranceExpirationDate = Convert.ToDateTime(reader["InsuranceExpirationDate"].ToString()),
                            ITPExpirationDate = Convert.ToDateTime(reader["ITPExpirationDate"].ToString()),
                            ManufacturingYear = Convert.ToDateTime(reader["ManufacturingYear"].ToString()),
                            RegistrationNumber = reader["RegistrationNumber"].ToString(),
                            TachographExpirationDate = Convert.ToDateTime(reader["TachographExpirationDate"].ToString()),
                            VignetteExpirationDate = Convert.ToDateTime(reader["VignetteExpirationDate"].ToString())
                        };
                        trucks.Add(truck);
                    }
                    con.Close();

                    return trucks.Any() ? trucks.FirstOrDefault() : null;
                }
            }
        }
    }
}
