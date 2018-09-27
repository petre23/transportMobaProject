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
                            Truck = !string.IsNullOrEmpty(reader["Truck"].ToString()) ? Guid.Parse(reader["Truck"].ToString()) : (Guid?)null,
                            FirstName = reader["FirstName"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            AdblueLiters = string.IsNullOrEmpty(reader["AdblueLiters"].ToString()) ? 0 : Convert.ToDecimal(reader["AdblueLiters"].ToString()),
                            AdblueValue = string.IsNullOrEmpty(reader["AdblueValue"].ToString()) ? 0 : Convert.ToDecimal(reader["AdblueValue"].ToString()),
                            DieselValue = string.IsNullOrEmpty(reader["DieselValue"].ToString()) ? 0 : Convert.ToDecimal(reader["DieselValue"].ToString()),
                            EstimatedConsumption = string.IsNullOrEmpty(reader["EstimatedConsumption"].ToString()) ? 0 : Convert.ToDecimal(reader["EstimatedConsumption"].ToString()),
                            FueledDieseKMLiters = string.IsNullOrEmpty(reader["FueledDieseKMLiters"].ToString()) ? 0 : Convert.ToDecimal(reader["FueledDieseKMLiters"].ToString()),
                            FueledKM = string.IsNullOrEmpty(reader["FueledKM"].ToString()) ? 0 : Convert.ToDecimal(reader["FueledKM"].ToString()),
                            GPSConsumption = string.IsNullOrEmpty(reader["GPSConsumption"].ToString()) ? 0 : Convert.ToDecimal(reader["GPSConsumption"].ToString()),
                            GPSFinalConsumption = string.IsNullOrEmpty(reader["GPSFinalConsumption"].ToString()) ? 0 : Convert.ToDecimal(reader["GPSFinalConsumption"].ToString()),
                            GPSInitialConsumption = string.IsNullOrEmpty(reader["GPSInitialConsumption"].ToString()) ? 0 : Convert.ToDecimal(reader["GPSInitialConsumption"].ToString()),
                            RealConsumption = string.IsNullOrEmpty(reader["RealConsumption"].ToString()) ? 0 : Convert.ToDecimal(reader["RealConsumption"].ToString()),
                            Date = Convert.ToDateTime(reader["Date"].ToString()),
                            DistanceGPS = string.IsNullOrEmpty(reader["DistanceGPS"].ToString()) ? 0 : Convert.ToDecimal(reader["DistanceGPS"].ToString()),
                            WorkerSelfFueled = string.IsNullOrEmpty(reader["WorkerSelfFueled"].ToString()) ? 0 : Convert.ToDecimal(reader["WorkerSelfFueled"].ToString()),
                            WorkerSelfFueledPounds = string.IsNullOrEmpty(reader["WorkerSelfFueledPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["WorkerSelfFueledPounds"].ToString()),
                            WorkerTKFuel = string.IsNullOrEmpty(reader["WorkerTKFuel"].ToString()) ? 0 : Convert.ToDecimal(reader["WorkerTKFuel"].ToString()),
                            WorkerTKFuelPounds = string.IsNullOrEmpty(reader["WorkerTKFuelPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["WorkerTKFuelPounds"].ToString()),
                            CompanyTKFuel = string.IsNullOrEmpty(reader["CompanyTKFuel"].ToString()) ? 0 : Convert.ToDecimal(reader["CompanyTKFuel"].ToString()),
                            CompanyTKFuelPounds = string.IsNullOrEmpty(reader["CompanyTKFuelPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["CompanyTKFuelPounds"].ToString()),
                            TruckRegistrationNumber = reader["TruckRegistrationNumber"].ToString(),
                            CreationDate = DateTime.Parse(reader["CreationDate"].ToString())
                        };
                        fuelInfoList.Add(fuelInfo);
                    }
                    con.Close();

                    return fuelInfoList.OrderByDescending(x=>x.CreationDate).ToList();
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
                    cmd.Parameters.AddWithValue("@Truck", fuel.Truck);
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
                    cmd.Parameters.AddWithValue("@DistanceGPS", fuel.DistanceGPS);
                    cmd.Parameters.AddWithValue("@WorkerSelfFueled", fuel.WorkerSelfFueled);
                    cmd.Parameters.AddWithValue("@WorkerSelfFueledPounds", fuel.WorkerSelfFueledPounds);
                    cmd.Parameters.AddWithValue("@CompanyTKFuel", fuel.CompanyTKFuel);
                    cmd.Parameters.AddWithValue("@CompanyTKFuelPounds", fuel.CompanyTKFuelPounds);
                    cmd.Parameters.AddWithValue("@WorkerTKFuel", fuel.WorkerTKFuel);
                    cmd.Parameters.AddWithValue("@WorkerTKFuelPounds", fuel.WorkerTKFuelPounds);
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
                            Truck = !string.IsNullOrEmpty(reader["Truck"].ToString()) ? Guid.Parse(reader["Truck"].ToString()) : (Guid?)null,
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
                            Date = Convert.ToDateTime(reader["Date"].ToString()),
                            DistanceGPS = string.IsNullOrEmpty(reader["DistanceGPS"].ToString()) ? 0 : Convert.ToDecimal(reader["DistanceGPS"].ToString()),
                            WorkerSelfFueled = string.IsNullOrEmpty(reader["WorkerSelfFueled"].ToString()) ? 0 : Convert.ToDecimal(reader["WorkerSelfFueled"].ToString()),
                            WorkerSelfFueledPounds = string.IsNullOrEmpty(reader["WorkerSelfFueledPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["WorkerSelfFueledPounds"].ToString()),
                            WorkerTKFuel = string.IsNullOrEmpty(reader["WorkerTKFuel"].ToString()) ? 0 : Convert.ToDecimal(reader["WorkerTKFuel"].ToString()),
                            WorkerTKFuelPounds = string.IsNullOrEmpty(reader["WorkerTKFuelPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["WorkerTKFuelPounds"].ToString()),
                            CompanyTKFuel = string.IsNullOrEmpty(reader["CompanyTKFuel"].ToString()) ? 0 : Convert.ToDecimal(reader["CompanyTKFuel"].ToString()),
                            CompanyTKFuelPounds = string.IsNullOrEmpty(reader["CompanyTKFuelPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["CompanyTKFuelPounds"].ToString()),
                            TruckRegistrationNumber = reader["TruckRegistrationNumber"].ToString()
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

        public decimal GetLastKmGPSForDriver(Guid workerId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetLastKmGPSForDriver", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WorkerId", workerId);
                    con.Open();

                    var reader = cmd.ExecuteReader();
                    decimal lastKmGPSForDriver = 0;
                    while (reader.Read())
                    {
                        lastKmGPSForDriver = Convert.ToDecimal(reader["LastKmGPSForDriver"].ToString());
                    }
                    con.Close();
                    return lastKmGPSForDriver;
                }
            }
        }

        public decimal? GetEstimatedConsumtionSumForDriverAndDate(Guid workerId, DateTime date)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetEstimatedConsumtionSumForDriverAndDate", con))
                {
                    decimal? totalEstimatedConsumtion = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DriverId", workerId);
                    cmd.Parameters.AddWithValue("@Date", date);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        totalEstimatedConsumtion = string.IsNullOrEmpty(reader["TotalEstimatedConsumption"].ToString()) ? (decimal?)null : Convert.ToDecimal(reader["TotalEstimatedConsumption"].ToString());
                    }
                    con.Close();

                    return totalEstimatedConsumtion;
                }
            }
        }
    }
}
