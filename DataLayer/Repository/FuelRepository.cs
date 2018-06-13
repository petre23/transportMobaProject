using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace DataLayer.Repository
{
    public class FuelRepository:BaseRepository
    {
        public List<Fuel> GetFuelInfo()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetFuelInfo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var fuelInfoList = new List<Fuel>();
                    while (reader.Read())
                    {
                        var fuelInfo = new Fuel()
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            Worker = Guid.Parse(reader["Worker"].ToString()),
                            FirstName = reader["FirstName"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            AdblueLiters = Convert.ToDecimal(reader["AdblueLiters"].ToString()),
                            AdblueValue = Convert.ToDecimal(reader["AdblueValue"].ToString()),
                            DieselValue = Convert.ToDecimal(reader["DieselValue"].ToString()),
                            EstimatedConsumption = Convert.ToDecimal(reader["EstimatedConsumption"].ToString()),
                            FueledDieseKMLiters = Convert.ToDecimal(reader["FueledDieseKMLiters"].ToString()),
                            FueledKM = Convert.ToDecimal(reader["FueledKM"].ToString()),
                            GPSConsumption = Convert.ToDecimal(reader["GPSConsumption"].ToString()),
                            GPSFinalConsumption = Convert.ToDecimal(reader["GPSFinalConsumption"].ToString()),
                            GPSInitialConsumption = Convert.ToDecimal(reader["GPSInitialConsumption"].ToString()),
                            RealConsumption = Convert.ToDecimal(reader["RealConsumption"].ToString()),
                            Date = Convert.ToDateTime(reader["Date"].ToString())
                        };
                        fuelInfoList.Add(fuelInfo);
                    }
                    con.Close();

                    return fuelInfoList;
                }
            }
        }

        public Guid SaveFuel(Fuel fuel)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveFuel", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var isNew = fuel.Id == Guid.Empty;
                    fuel.Id = isNew ? Guid.NewGuid() : fuel.Id;
                    cmd.Parameters.AddWithValue("@IsNew", isNew);
                    cmd.Parameters.AddWithValue("@Id", fuel.Id);
                    cmd.Parameters.AddWithValue("@Worker", fuel.Worker);
                    cmd.Parameters.AddWithValue("@AdblueLiters", fuel.AdblueLiters);
                    cmd.Parameters.AddWithValue("@AdblueValue", fuel.AdblueValue);
                    cmd.Parameters.AddWithValue("@DieselValue", fuel.DieselValue);
                    cmd.Parameters.AddWithValue("@EstimatedConsumption", fuel.EstimatedConsumption);
                    cmd.Parameters.AddWithValue("@FueledDieseKMLiters", fuel.FueledDieseKMLiters);
                    cmd.Parameters.AddWithValue("@FueledKM", fuel.FueledKM);
                    cmd.Parameters.AddWithValue("@GPSConsumption", fuel.GPSConsumption);
                    cmd.Parameters.AddWithValue("@GPSFinalConsumption", fuel.GPSFinalConsumption);
                    cmd.Parameters.AddWithValue("@GPSInitialConsumption", fuel.GPSInitialConsumption);
                    cmd.Parameters.AddWithValue("@RealConsumption", fuel.RealConsumption);
                    cmd.Parameters.AddWithValue("@Date", fuel.Date);
                    con.Open();
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();

                    return fuel.Id;
                }
            }
        }

        public Fuel GetFuelInfoById(Guid idFuel)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetFuelInfoById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FuelId", idFuel);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var fueledInfoList = new List<Fuel>();
                    while (reader.Read())
                    {
                        var fuleInfo = new Fuel()
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            Worker = Guid.Parse(reader["Worker"].ToString()),
                            FirstName = reader["FirstName"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            AdblueLiters = Convert.ToDecimal(reader["AdblueLiters"].ToString()),
                            AdblueValue = Convert.ToDecimal(reader["AdblueValue"].ToString()),
                            DieselValue = Convert.ToDecimal(reader["DieselValue"].ToString()),
                            EstimatedConsumption = Convert.ToDecimal(reader["EstimatedConsumption"].ToString()),
                            FueledDieseKMLiters = Convert.ToDecimal(reader["FueledDieseKMLiters"].ToString()),
                            FueledKM = Convert.ToDecimal(reader["FueledKM"].ToString()),
                            GPSConsumption = Convert.ToDecimal(reader["GPSConsumption"].ToString()),
                            GPSFinalConsumption = Convert.ToDecimal(reader["GPSFinalConsumption"].ToString()),
                            GPSInitialConsumption = Convert.ToDecimal(reader["GPSInitialConsumption"].ToString()),
                            RealConsumption = Convert.ToDecimal(reader["RealConsumption"].ToString()),
                            Date = Convert.ToDateTime(reader["Date"].ToString())
                        };
                        fueledInfoList.Add(fuleInfo);
                    }
                    con.Close();

                    return fueledInfoList.Any() ? fueledInfoList.FirstOrDefault() : null;
                }
            }
        }

        public void DeleteFuel(Guid fuelId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteFuel", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FuelId", fuelId);
                    con.Open();
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
