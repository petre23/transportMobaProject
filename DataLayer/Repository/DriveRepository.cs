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
    public class DriveRepository: BaseRepository
    {
        public List<Drive> GetDrives()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetDrives", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var drives = new List<Drive>();
                    while (reader.Read())
                    {
                        var drive = new Drive()
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            AdblueLiters = Convert.ToInt32(reader["AdblueLiters"].ToString()),
                            AdblueValue = Convert.ToInt32(reader["AdblueValue"].ToString()),
                            CostsSpecification = reader["CostsSpecification"].ToString(),
                            Date = Convert.ToDateTime(reader["Date"].ToString()),
                            Destination = reader["Destination"].ToString(),
                            DieselValue = Convert.ToDecimal(reader["DieselValue"].ToString()),
                            Difference = Convert.ToInt32(reader["Difference"].ToString()),
                            DistanceDFDS = Convert.ToInt32(reader["DistanceDFDS"].ToString()),
                            DistanceGpl = Convert.ToInt32(reader["DistanceGpl"].ToString()),
                            DistanceGPS = Convert.ToInt32(reader["DistanceGPS"].ToString()),
                            EstimatedConsumption = Convert.ToInt32(reader["EstimatedConsumption"].ToString()),
                            FinalGPSKM = Convert.ToInt32(reader["FinalGPSKM"].ToString()),
                            FueledDieseKMLiters = Convert.ToInt32(reader["FueledDieseKMLiters"].ToString()),
                            FueledKM = Convert.ToInt32(reader["FueledKM"].ToString()),
                            GPSConsumption = Convert.ToInt32(reader["GPSConsumption"].ToString()),
                            GPSFinalConsumption = Convert.ToInt32(reader["GPSFinalConsumption"].ToString()),
                            GPSInitialConsumption = Convert.ToInt32(reader["GPSInitialConsumption"].ToString()),
                            InitialGPSKM = Convert.ToInt32(reader["InitialGPSKM"].ToString()),
                            LoadingPlace = reader["LoadingPlace"].ToString(),
                            PayedCosts = Convert.ToDecimal(reader["PayedCosts"].ToString()),
                            RealConsumption = Convert.ToInt32(reader["RealConsumption"].ToString()),
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
                            AdblueLiters = Convert.ToInt32(reader["AdblueLiters"].ToString()),
                            AdblueValue = Convert.ToInt32(reader["AdblueValue"].ToString()),
                            CostsSpecification = reader["CostsSpecification"].ToString(),
                            Date = Convert.ToDateTime(reader["Date"].ToString()),
                            Destination = reader["Destination"].ToString(),
                            DieselValue = Convert.ToDecimal(reader["DieselValue"].ToString()),
                            Difference = Convert.ToInt32(reader["Difference"].ToString()),
                            DistanceDFDS = Convert.ToInt32(reader["DistanceDFDS"].ToString()),
                            DistanceGpl = Convert.ToInt32(reader["DistanceGpl"].ToString()),
                            DistanceGPS = Convert.ToInt32(reader["DistanceGPS"].ToString()),
                            EstimatedConsumption = Convert.ToInt32(reader["EstimatedConsumption"].ToString()),
                            FinalGPSKM = Convert.ToInt32(reader["FinalGPSKM"].ToString()),
                            FueledDieseKMLiters = Convert.ToInt32(reader["FueledDieseKMLiters"].ToString()),
                            FueledKM = Convert.ToInt32(reader["FueledKM"].ToString()),
                            GPSConsumption = Convert.ToInt32(reader["GPSConsumption"].ToString()),
                            GPSFinalConsumption = Convert.ToInt32(reader["GPSFinalConsumption"].ToString()),
                            GPSInitialConsumption = Convert.ToInt32(reader["GPSInitialConsumption"].ToString()),
                            InitialGPSKM = Convert.ToInt32(reader["InitialGPSKM"].ToString()),
                            LoadingPlace = reader["LoadingPlace"].ToString(),
                            PayedCosts = Convert.ToDecimal(reader["PayedCosts"].ToString()),
                            RealConsumption = Convert.ToInt32(reader["RealConsumption"].ToString()),
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
    }
}
