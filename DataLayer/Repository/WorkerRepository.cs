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
    public class WorkerRepository: BaseRepository
    {
        EmployerRepository _employerRepository = new EmployerRepository();

        public List<Worker> GetWorkers()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetWorkers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var workers = new List<Worker>();
                    while (reader.Read())
                    {
                        var worker = new Worker()
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            Employer = Guid.Parse(reader["Employer"].ToString()),
                            EmployerDropDownValue = Convert.ToInt32(reader["EmployerDropDownValue"]),
                            EmployerName = reader["EmployerName"].ToString(),
                            EmploymentDate = Convert.ToDateTime(reader["EmploymentDate"].ToString()),
                            BirthDay = Convert.ToDateTime(reader["BirthDay"].ToString()),
                            CertificateExpirationDate = Convert.ToDateTime(reader["CertificateExpirationDate"].ToString()),
                            DrivingLicenseExpirationDate = Convert.ToDateTime(reader["DrivingLicenseExpirationDate"].ToString()),
                            MedicalTestsExpirationDate = Convert.ToDateTime(reader["MedicalTestsExpirationDate"].ToString()),
                            TachographCardExpirationDate = Convert.ToDateTime(reader["TachographCardExpirationDate"].ToString()),
                            FirstName = reader["FirstName"].ToString(),
                            CNP = reader["CNP"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            Truck = Guid.Parse(reader["Truck"].ToString()),
                            TruckRegistrationNumber = reader["TruckRegistrationNumber"].ToString(),
                            IdentityDocument = reader["IdentityDocument"].ToString()
                        };
                        workers.Add(worker);
                    }
                    con.Close();

                    return workers;
                }
            }
        }

        public Guid SaveWorker(Worker worker)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveWorker", con))
                {
                    var employers = _employerRepository.GetEmployers();
                    worker.Employer = employers.FirstOrDefault(x => x.Value == worker.EmployerDropDownValue).Id;

                    cmd.CommandType = CommandType.StoredProcedure;
                    var isNew = worker.Id == Guid.Empty;
                    worker.Id = isNew ? Guid.NewGuid() : worker.Id;
                    cmd.Parameters.AddWithValue("@IsNew", isNew);
                    cmd.Parameters.AddWithValue("@Id", worker.Id);
                    cmd.Parameters.AddWithValue("@Employer", worker.Employer);
                    cmd.Parameters.AddWithValue("@Truck", worker.Truck);
                    cmd.Parameters.AddWithValue("@BirthDay", worker.BirthDay);
                    cmd.Parameters.AddWithValue("@CertificateExpirationDate", worker.CertificateExpirationDate);
                    cmd.Parameters.AddWithValue("@DrivingLicenseExpirationDate", worker.DrivingLicenseExpirationDate);
                    cmd.Parameters.AddWithValue("@EmploymentDate", worker.EmploymentDate);
                    cmd.Parameters.AddWithValue("@MedicalTestsExpirationDate", worker.MedicalTestsExpirationDate);
                    cmd.Parameters.AddWithValue("@TachographCardExpirationDate", worker.TachographCardExpirationDate);
                    cmd.Parameters.AddWithValue("@IdentityDocument", worker.IdentityDocument);
                    cmd.Parameters.AddWithValue("@FirstName", worker.FirstName);
                    cmd.Parameters.AddWithValue("@Surname", worker.Surname);
                    cmd.Parameters.AddWithValue("@CNP", worker.CNP);
                    con.Open();
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();

                    return worker.Id;
                }
            }
        }

        public Worker GetWorker(Guid idWorker)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetWorker", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WorkerId", idWorker);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var workers = new List<Worker>();
                    while (reader.Read())
                    {
                        var worker = new Worker()
                        {
                            Id = Guid.Parse(reader["Id"].ToString()),
                            Employer = Guid.Parse(reader["Employer"].ToString()),
                            EmployerDropDownValue = Convert.ToInt32(reader["EmployerDropDownValue"]),
                            EmployerName = reader["EmployerName"].ToString(),
                            EmploymentDate = Convert.ToDateTime(reader["EmploymentDate"].ToString()),
                            BirthDay = Convert.ToDateTime(reader["BirthDay"].ToString()),
                            CertificateExpirationDate = Convert.ToDateTime(reader["CertificateExpirationDate"].ToString()),
                            DrivingLicenseExpirationDate = Convert.ToDateTime(reader["DrivingLicenseExpirationDate"].ToString()),
                            MedicalTestsExpirationDate = Convert.ToDateTime(reader["MedicalTestsExpirationDate"].ToString()),
                            TachographCardExpirationDate = Convert.ToDateTime(reader["TachographCardExpirationDate"].ToString()),
                            FirstName = reader["FirstName"].ToString(),
                            CNP = reader["CNP"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            Truck = Guid.Parse(reader["Truck"].ToString()),
                            TruckRegistrationNumber = reader["TruckRegistrationNumber"].ToString(),
                            IdentityDocument = reader["IdentityDocument"].ToString()
                        };
                        workers.Add(worker);
                    }
                    con.Close();

                    return workers.Any() ? workers.FirstOrDefault() : null;
                }
            }
        }

        public void DeleteWorker(Guid workerId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteWorker", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WorkerId", workerId);
                    con.Open();
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
