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
    public class DriveCostsRepository: BaseRepository
    {
        public List<DriveCosts> GetCostsForDrive(Guid driveId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetDriveCostsByDriveId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DriveId", driveId);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var driveCosts = new List<DriveCosts>();
                    while (reader.Read())
                    {
                        var driveCost = new DriveCosts()
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            CostEuro = Convert.ToDecimal(reader["CostEuro"].ToString()),
                            CostPounds = Convert.ToDecimal(reader["CostPounds"].ToString()),
                            Drive = Guid.Parse(reader["Drive"].ToString())
                        };
                        driveCosts.Add(driveCost);
                    }
                    con.Close();

                    return driveCosts;
                }
            }
        }

        public void SaveDriveCosts(List<DriveCosts> driveCosts)
        {
            if (driveCosts != null && driveCosts.Any())
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SaveDriveCosts", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DriveId", driveCosts.FirstOrDefault().Drive);
                        cmd.Parameters.AddWithValue("@DriveCostsType", ConvertListToTable(driveCosts));

                        con.Open();
                        var reader = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }

        private DataTable ConvertListToTable(List<DriveCosts> driveCosts)
        {
            var dataTable = new DataTable("DriveCostsType");
            dataTable.Columns.Add("Id", typeof(Guid));
            dataTable.Columns.Add("CostEuro", typeof(decimal));
            dataTable.Columns.Add("CostPounds", typeof(decimal));
            dataTable.Columns.Add("Drive", typeof(Guid));

            foreach (var cost in driveCosts)
            {
                dataTable.Rows.Add(cost.Id, cost.CostEuro, cost.CostPounds, cost.Drive);
            }

            return dataTable;
        }
    }
}
