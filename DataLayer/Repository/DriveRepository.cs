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
    public class DriveRepository: BaseRepository
    {
        public List<Drive> GetDrives(int pageNumber = 0,int pageSize = 50)
        {
            var totalDrivesCount = GetDrivesTotalCount();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetDrives", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var drives = new List<Drive>();
                    while (reader.Read())
                    {
                        var drive = new Drive()
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            AdblueLiters = Convert.ToDecimal(reader["AdblueLiters"].ToString()),
                            AdblueValue = Convert.ToDecimal(reader["AdblueValue"].ToString()),
                            CostsSpecification = reader["CostsSpecification"].ToString(),
                            Date = Convert.ToDateTime(reader["Date"].ToString()),
                            Destination = reader["Destination"].ToString(),
                            DieselValue = Convert.ToDecimal(reader["DieselValue"].ToString()),
                            Difference = Convert.ToDecimal(reader["Difference"].ToString()),
                            DistanceDFDS = Convert.ToDecimal(reader["DistanceDFDS"].ToString()),
                            DistanceGpl = Convert.ToDecimal(reader["DistanceGpl"].ToString()),
                            DistanceGPS = Convert.ToDecimal(reader["DistanceGPS"].ToString()),
                            EstimatedConsumption = Convert.ToDecimal(reader["EstimatedConsumption"].ToString()),
                            FinalGPSKM = Convert.ToDecimal(reader["FinalGPSKM"].ToString()),
                            FueledDieseKMLiters = Convert.ToDecimal(reader["FueledDieseKMLiters"].ToString()),
                            FueledKM = Convert.ToDecimal(reader["FueledKM"].ToString()),
                            GPSConsumption = Convert.ToDecimal(reader["GPSConsumption"].ToString()),
                            GPSFinalConsumption = Convert.ToDecimal(reader["GPSFinalConsumption"].ToString()),
                            GPSInitialConsumption = Convert.ToDecimal(reader["GPSInitialConsumption"].ToString()),
                            InitialGPSKM = Convert.ToDecimal(reader["InitialGPSKM"].ToString()),
                            LoadingPlace = reader["LoadingPlace"].ToString(),
                            PayedCosts = Convert.ToDecimal(reader["PayedCosts"].ToString()),
                            RealConsumption = Convert.ToDecimal(reader["RealConsumption"].ToString()),
                            Reason = reader["Reason"].ToString(),
                            SettlementCosts = Convert.ToDecimal(reader["SettlementCosts"].ToString()),
                            TotalPayments = Convert.ToDecimal(reader["TotalPayments"].ToString()),
                            Truck = Guid.Parse(reader["Truck"].ToString()),
                            Vlaplan = reader["Vlaplan"].ToString(),
                            Vlaref = reader["Vlaref"].ToString(),
                            WeightInTons = Convert.ToDecimal(reader["WeightInTons"].ToString()),
                            Worker = Guid.Parse(reader["Worker"].ToString()),
                            WorkerCosts = Convert.ToDecimal(reader["WorkerCosts"].ToString()),
                            FirstName = reader["FirstName"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            TruckRegistrationNumber = reader["RegistrationNumber"].ToString(),
                            LastUpdateByUserName = reader["LastUpdateByUserName"].ToString(),
                            TotalRows = totalDrivesCount
                        };
                        drives.Add(drive);
                    }
                    con.Close();

                    return drives;
                }
            }
        }

        public Guid SaveDrive(Drive drive)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveDrive", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var isNew = drive.Id == Guid.Empty;
                    drive.Id = isNew ? Guid.NewGuid() : drive.Id;
                    cmd.Parameters.AddWithValue("@IsNew", isNew);
                    cmd.Parameters.AddWithValue("@Id", drive.Id);
                    cmd.Parameters.AddWithValue("@LastUpdateByUser", drive.LastUpdateByUser);
                    cmd.Parameters.AddWithValue("@AdblueLiters", drive.AdblueLiters);
                    cmd.Parameters.AddWithValue("@AdblueValue", drive.AdblueValue);
                    cmd.Parameters.AddWithValue("@CostsSpecification", drive.CostsSpecification);
                    cmd.Parameters.AddWithValue("@Date", drive.Date);
                    cmd.Parameters.AddWithValue("@Destination", drive.Destination);
                    cmd.Parameters.AddWithValue("@DieselValue", drive.DieselValue);
                    cmd.Parameters.AddWithValue("@Difference", drive.Difference);
                    cmd.Parameters.AddWithValue("@DistanceDFDS", drive.DistanceDFDS);
                    cmd.Parameters.AddWithValue("@DistanceGpl", drive.DistanceGpl);
                    cmd.Parameters.AddWithValue("@DistanceGPS", drive.DistanceGPS);
                    cmd.Parameters.AddWithValue("@EstimatedConsumption", drive.EstimatedConsumption);
                    cmd.Parameters.AddWithValue("@FinalGPSKM", drive.FinalGPSKM);
                    cmd.Parameters.AddWithValue("@FueledDieseKMLiters", drive.FueledDieseKMLiters);
                    cmd.Parameters.AddWithValue("@FueledKM", drive.FueledKM);
                    cmd.Parameters.AddWithValue("@GPSConsumption", drive.GPSConsumption);
                    cmd.Parameters.AddWithValue("@GPSFinalConsumption", drive.GPSFinalConsumption);
                    cmd.Parameters.AddWithValue("@GPSInitialConsumption", drive.GPSInitialConsumption);
                    cmd.Parameters.AddWithValue("@InitialGPSKM", drive.InitialGPSKM);
                    cmd.Parameters.AddWithValue("@LoadingPlace", drive.LoadingPlace);
                    cmd.Parameters.AddWithValue("@PayedCosts", drive.PayedCosts);
                    cmd.Parameters.AddWithValue("@RealConsumption", drive.RealConsumption);
                    cmd.Parameters.AddWithValue("@Reason", drive.Reason);
                    cmd.Parameters.AddWithValue("@SettlementCosts", drive.SettlementCosts);
                    cmd.Parameters.AddWithValue("@TotalPayments", drive.TotalPayments);
                    cmd.Parameters.AddWithValue("@Truck", drive.Truck);
                    cmd.Parameters.AddWithValue("@Vlaplan", drive.Vlaplan);
                    cmd.Parameters.AddWithValue("@Vlaref", drive.Vlaref);
                    cmd.Parameters.AddWithValue("@WeightInTons", drive.WeightInTons);
                    cmd.Parameters.AddWithValue("@Worker", drive.Worker);
                    cmd.Parameters.AddWithValue("@WorkerCosts", drive.WorkerCosts);
                    con.Open();
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();

                    return drive.Id;
                }
            }
        }

        public Drive GetDrive(Guid idDrive)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetDrive", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DriveId",idDrive);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var drives = new List<Drive>();
                    while (reader.Read())
                    {
                        var drive = new Drive()
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            AdblueLiters = Convert.ToDecimal(reader["AdblueLiters"].ToString()),
                            AdblueValue = Convert.ToDecimal(reader["AdblueValue"].ToString()),
                            CostsSpecification = reader["CostsSpecification"].ToString(),
                            Date = Convert.ToDateTime(reader["Date"].ToString()),
                            Destination = reader["Destination"].ToString(),
                            DieselValue = Convert.ToDecimal(reader["DieselValue"].ToString()),
                            Difference = Convert.ToDecimal(reader["Difference"].ToString()),
                            DistanceDFDS = Convert.ToDecimal(reader["DistanceDFDS"].ToString()),
                            DistanceGpl = Convert.ToDecimal(reader["DistanceGpl"].ToString()),
                            DistanceGPS = Convert.ToDecimal(reader["DistanceGPS"].ToString()),
                            EstimatedConsumption = Convert.ToDecimal(reader["EstimatedConsumption"].ToString()),
                            FinalGPSKM = Convert.ToDecimal(reader["FinalGPSKM"].ToString()),
                            FueledDieseKMLiters = Convert.ToDecimal(reader["FueledDieseKMLiters"].ToString()),
                            FueledKM = Convert.ToDecimal(reader["FueledKM"].ToString()),
                            GPSConsumption = Convert.ToDecimal(reader["GPSConsumption"].ToString()),
                            GPSFinalConsumption = Convert.ToDecimal(reader["GPSFinalConsumption"].ToString()),
                            GPSInitialConsumption = Convert.ToDecimal(reader["GPSInitialConsumption"].ToString()),
                            InitialGPSKM = Convert.ToDecimal(reader["InitialGPSKM"].ToString()),
                            LoadingPlace = reader["LoadingPlace"].ToString(),
                            PayedCosts = Convert.ToDecimal(reader["PayedCosts"].ToString()),
                            RealConsumption = Convert.ToDecimal(reader["RealConsumption"].ToString()),
                            Reason = reader["Reason"].ToString(),
                            SettlementCosts = Convert.ToDecimal(reader["SettlementCosts"].ToString()),
                            TotalPayments = Convert.ToDecimal(reader["TotalPayments"].ToString()),
                            Truck = Guid.Parse(reader["Truck"].ToString()),
                            Vlaplan = reader["Vlaplan"].ToString(),
                            Vlaref = reader["Vlaref"].ToString(),
                            WeightInTons = Convert.ToDecimal(reader["WeightInTons"].ToString()),
                            Worker = Guid.Parse(reader["Worker"].ToString()),
                            WorkerCosts = Convert.ToDecimal(reader["WorkerCosts"].ToString()),
                            FirstName = reader["FirstName"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            TruckRegistrationNumber = reader["RegistrationNumber"].ToString(),
                        };
                        drives.Add(drive);
                    }
                    con.Close();

                    return drives.Any() ? drives.FirstOrDefault() : null;
                }
            }
        }

        public void DeleteDrive(Guid driveId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteDrive", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DriveId", driveId);
                    con.Open();
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public int GetDrivesTotalCount()
        {
            var totalDrivesCount = 0;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetDrivesTotalCount", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        totalDrivesCount = Convert.ToInt32(reader["TotalDrivesCount"].ToString());
                    }
                    con.Close();
                }
            }

            return totalDrivesCount;
        }
    }
}
