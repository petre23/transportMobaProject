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
        public List<Drive> GetDrives(int pageSize = 0,int pageNumber = 50,string searchText = null)
        {
            var totalDrivesCount = GetDrivesTotalCount();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetDrives", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);
                    cmd.Parameters.AddWithValue("@SearchText", searchText);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var drives = new List<Drive>();
                    while (reader.Read())
                    {
                        var drive = new Drive();
                        drive.Id = Guid.Parse(reader["Id"].ToString());
                        drive.CostsSpecification = reader["CostsSpecification"].ToString();
                        drive.Date = Convert.ToDateTime(reader["Date"].ToString());
                        drive.Destination = reader["Destination"].ToString();
                        drive.Difference = Convert.ToDecimal(reader["Difference"].ToString());
                        drive.DistanceDFDS = Convert.ToDecimal(reader["DistanceDFDS"].ToString());
                        drive.DistanceGpl = Convert.ToDecimal(reader["DistanceGpl"].ToString());
                        drive.DistanceGPS = Convert.ToDecimal(reader["DistanceGPS"].ToString());
                        drive.FinalGPSKM = Convert.ToDecimal(reader["FinalGPSKM"].ToString());
                        drive.InitialGPSKM = Convert.ToDecimal(reader["InitialGPSKM"].ToString());
                        drive.LoadingPlace = reader["LoadingPlace"].ToString();
                        drive.PayedCosts = Convert.ToDecimal(reader["PayedCosts"].ToString());
                        drive.PayedCostsPounds = string.IsNullOrEmpty(reader["PayedCostsPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["PayedCostsPounds"].ToString());
                        drive.Reason = reader["Reason"].ToString();
                        drive.SettlementCosts = Convert.ToDecimal(reader["SettlementCosts"].ToString());
                        drive.SettlementCostsPounds = string.IsNullOrEmpty(reader["SettlementCostsPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["SettlementCostsPounds"].ToString());
                        drive.TotalPayments = Convert.ToDecimal(reader["TotalPayments"].ToString());
                        drive.TotalPaymentsPounds = string.IsNullOrEmpty(reader["TotalPaymentsPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["TotalPaymentsPounds"].ToString());
                        drive.Truck = !string.IsNullOrEmpty(reader["Truck"].ToString()) ? Guid.Parse(reader["Truck"].ToString()) : (Guid?)null;
                        drive.Vlaplan = reader["Vlaplan"].ToString();
                        drive.Vlaref = reader["Vlaref"].ToString();
                        drive.WeightInTons = Convert.ToDecimal(reader["WeightInTons"].ToString());
                        drive.Worker = !string.IsNullOrEmpty(reader["Worker"].ToString()) ? Guid.Parse(reader["Worker"].ToString()) : (Guid?)null;
                        drive.WorkerCosts = Convert.ToDecimal(reader["WorkerCosts"].ToString());
                        drive.WorkerCostsPounds = string.IsNullOrEmpty(reader["WorkerCostsPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["WorkerCostsPounds"].ToString());
                        drive.FirstName = reader["FirstName"].ToString();
                        drive.Surname = reader["Surname"].ToString();
                        drive.TruckRegistrationNumber = reader["RegistrationNumber"].ToString();
                        drive.LastUpdateByUserName = reader["LastUpdateByUserName"].ToString();
                        drive.Trailer = reader["Trailer"].ToString();
                        drive.DriveStatus = !string.IsNullOrEmpty(reader["DriveStatus"].ToString()) ? Guid.Parse(reader["DriveStatus"].ToString()) : (Guid?)null;
                        drive.DriveStatusName = reader["DriveStatusName"].ToString();
                        drive.TotalRows = totalDrivesCount;

                        drives.Add(drive);
                    }
                    con.Close();

                    return drives;
                }
            }
        }

        public List<Drive> GetDrivesForWorkerByDateInterval(Guid workerId,DateTime startDate,DateTime endDate)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetDrivesForWorkerByDateInterval", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WorkerId", workerId);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var drives = new List<Drive>();
                    while (reader.Read())
                    {
                        var drive = new Drive()
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            CostsSpecification = reader["CostsSpecification"].ToString(),
                            Date = Convert.ToDateTime(reader["Date"].ToString()),
                            Destination = reader["Destination"].ToString(),
                            Difference = Convert.ToDecimal(reader["Difference"].ToString()),
                            DistanceDFDS = Convert.ToDecimal(reader["DistanceDFDS"].ToString()),
                            DistanceGpl = Convert.ToDecimal(reader["DistanceGpl"].ToString()),
                            DistanceGPS = Convert.ToDecimal(reader["DistanceGPS"].ToString()),
                            FinalGPSKM = Convert.ToDecimal(reader["FinalGPSKM"].ToString()),
                            InitialGPSKM = Convert.ToDecimal(reader["InitialGPSKM"].ToString()),
                            LoadingPlace = reader["LoadingPlace"].ToString(),
                            PayedCosts = Convert.ToDecimal(reader["PayedCosts"].ToString()),
                            PayedCostsPounds = string.IsNullOrEmpty(reader["PayedCostsPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["PayedCostsPounds"].ToString()),
                            Reason = reader["Reason"].ToString(),
                            SettlementCosts = Convert.ToDecimal(reader["SettlementCosts"].ToString()),
                            SettlementCostsPounds = string.IsNullOrEmpty(reader["SettlementCostsPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["SettlementCostsPounds"].ToString()),
                            TotalPayments = Convert.ToDecimal(reader["TotalPayments"].ToString()),
                            TotalPaymentsPounds = string.IsNullOrEmpty(reader["TotalPaymentsPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["TotalPaymentsPounds"].ToString()),
                            Truck = Guid.Parse(reader["Truck"].ToString()),
                            Vlaplan = reader["Vlaplan"].ToString(),
                            Vlaref = reader["Vlaref"].ToString(),
                            WeightInTons = Convert.ToDecimal(reader["WeightInTons"].ToString()),
                            Worker = Guid.Parse(reader["Worker"].ToString()),
                            WorkerCosts = Convert.ToDecimal(reader["WorkerCosts"].ToString()),
                            WorkerCostsPounds = string.IsNullOrEmpty(reader["WorkerCostsPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["WorkerCostsPounds"].ToString()),
                            FirstName = reader["FirstName"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            TruckRegistrationNumber = reader["RegistrationNumber"].ToString(),
                            Trailer = reader["Trailer"].ToString(),
                            DriveStatus = !string.IsNullOrEmpty(reader["DriveStatus"].ToString()) ? Guid.Parse(reader["DriveStatus"].ToString()) : (Guid?)null,
                            DriveStatusName = reader["DriveStatusName"].ToString()
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
                    cmd.Parameters.AddWithValue("@Date", drive.Date);
                    cmd.Parameters.AddWithValue("@Destination", drive.Destination);
                    cmd.Parameters.AddWithValue("@Difference", drive.Difference);
                    cmd.Parameters.AddWithValue("@DistanceDFDS", drive.DistanceDFDS);
                    cmd.Parameters.AddWithValue("@DistanceGpl", drive.DistanceGpl);
                    cmd.Parameters.AddWithValue("@DistanceGPS", drive.DistanceGPS);
                    cmd.Parameters.AddWithValue("@FinalGPSKM", drive.FinalGPSKM);
                    cmd.Parameters.AddWithValue("@InitialGPSKM", drive.InitialGPSKM);
                    cmd.Parameters.AddWithValue("@LoadingPlace", drive.LoadingPlace);
                    cmd.Parameters.AddWithValue("@PayedCosts", drive.PayedCosts);
                    cmd.Parameters.AddWithValue("@Reason", drive.Reason);
                    cmd.Parameters.AddWithValue("@SettlementCosts", drive.SettlementCosts);
                    cmd.Parameters.AddWithValue("@TotalPayments", drive.TotalPayments);
                    cmd.Parameters.AddWithValue("@Truck", drive.Truck);
                    cmd.Parameters.AddWithValue("@Vlaplan", drive.Vlaplan);
                    cmd.Parameters.AddWithValue("@Vlaref", drive.Vlaref);
                    cmd.Parameters.AddWithValue("@WeightInTons", drive.WeightInTons);
                    cmd.Parameters.AddWithValue("@Worker", drive.Worker);
                    cmd.Parameters.AddWithValue("@WorkerCosts", drive.WorkerCosts);
                    cmd.Parameters.AddWithValue("@CostsSpecification", drive.CostsSpecification);
                    cmd.Parameters.AddWithValue("@PayedCostsPounds", drive.PayedCostsPounds);
                    cmd.Parameters.AddWithValue("@SettlementCostsPounds", drive.SettlementCostsPounds);
                    cmd.Parameters.AddWithValue("@TotalPaymentsPounds", drive.TotalPaymentsPounds);
                    cmd.Parameters.AddWithValue("@WorkerCostsPounds", drive.WorkerCostsPounds);
                    cmd.Parameters.AddWithValue("@Trailer", drive.Trailer);
                    cmd.Parameters.AddWithValue("@DriveStatus", drive.DriveStatus);
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
                            CostsSpecification = reader["CostsSpecification"].ToString(),
                            Date = Convert.ToDateTime(reader["Date"].ToString()),
                            Destination = reader["Destination"].ToString(),
                            Difference = Convert.ToDecimal(reader["Difference"].ToString()),
                            DistanceDFDS = Convert.ToDecimal(reader["DistanceDFDS"].ToString()),
                            DistanceGpl = Convert.ToDecimal(reader["DistanceGpl"].ToString()),
                            DistanceGPS = Convert.ToDecimal(reader["DistanceGPS"].ToString()),
                            FinalGPSKM = Convert.ToDecimal(reader["FinalGPSKM"].ToString()),
                            InitialGPSKM = Convert.ToDecimal(reader["InitialGPSKM"].ToString()),
                            LoadingPlace = reader["LoadingPlace"].ToString(),
                            PayedCosts = Convert.ToDecimal(reader["PayedCosts"].ToString()),
                            PayedCostsPounds = string.IsNullOrEmpty(reader["PayedCostsPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["PayedCostsPounds"].ToString()),
                            Reason = reader["Reason"].ToString(),
                            SettlementCosts = Convert.ToDecimal(reader["SettlementCosts"].ToString()),
                            SettlementCostsPounds = string.IsNullOrEmpty(reader["SettlementCostsPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["SettlementCostsPounds"].ToString()),
                            TotalPayments = Convert.ToDecimal(reader["TotalPayments"].ToString()),
                            TotalPaymentsPounds = string.IsNullOrEmpty(reader["TotalPaymentsPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["TotalPaymentsPounds"].ToString()),
                            Truck = Guid.Parse(reader["Truck"].ToString()),
                            Vlaplan = reader["Vlaplan"].ToString(),
                            Vlaref = reader["Vlaref"].ToString(),
                            WeightInTons = Convert.ToDecimal(reader["WeightInTons"].ToString()),
                            Worker = Guid.Parse(reader["Worker"].ToString()),
                            WorkerCosts = Convert.ToDecimal(reader["WorkerCosts"].ToString()),
                            WorkerCostsPounds = string.IsNullOrEmpty(reader["WorkerCostsPounds"].ToString()) ? 0 : Convert.ToDecimal(reader["WorkerCostsPounds"].ToString()),
                            FirstName = reader["FirstName"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            TruckRegistrationNumber = reader["RegistrationNumber"].ToString(),
                            Trailer = reader["Trailer"].ToString(),
                            DriveStatus = !string.IsNullOrEmpty(reader["DriveStatus"].ToString()) ? Guid.Parse(reader["DriveStatus"].ToString()) : (Guid?)null,
                            DriveStatusName = reader["DriveStatusName"].ToString()
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

        public List<DriveStatus> GetDriveStatuses()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                var driveStatuses = new List<DriveStatus>();
                using (SqlCommand cmd = new SqlCommand("GetDriveStatuses", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var driveStatus = new DriveStatus()
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            Status = reader["Status"].ToString()
                        };
                        driveStatuses.Add(driveStatus);
                    }
                    con.Close();
                }
                return driveStatuses;
            }
        }
    }
}
