﻿using DataLayer.PersistanceLayer;
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

        public Guid SaveTruck(Truck idTruck)
        {
            return Guid.Empty;
        }

        public Truck GetTruck(Guid idTruck)
        {
            return new Truck();
        }
    }
}
