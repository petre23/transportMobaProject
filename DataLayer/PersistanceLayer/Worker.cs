using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.PersistanceLayer
{
    [DataContract]
    public class Worker
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public DateTime BirthDay { get; set; }
        [DataMember]
        public string BirthDayString { get; }
        [DataMember]
        public string IdentityDocument { get; set; }
        [DataMember]
        public DateTime CertificateExpirationDate { get; set; }
        [DataMember]
        public string CertificateExpirationDateString
        {
            get
            {
                return CertificateExpirationDate.ToString("dd/MM/yyyy");
            }
        }
        [DataMember]
        public DateTime DrivingLicenseExpirationDate { get; set; }
        [DataMember]
        public string DrivingLicenseExpirationDateString
        {
            get
            {
                return DrivingLicenseExpirationDate.ToString("dd/MM/yyyy");
            }
        }
        [DataMember]
        public DateTime EmploymentDate { get; set; }
        [DataMember]
        public string EmploymentDateString
        {
            get
            {
                return EmploymentDate.ToString("dd/MM/yyyy");
            }
        }
        [DataMember]
        public DateTime MedicalTestsExpirationDate { get; set; }
        [DataMember]
        public string MedicalTestsExpirationDateString
        {
            get
            {
                return MedicalTestsExpirationDate.ToString("dd/MM/yyyy");
            }
        }
        [DataMember]
        public DateTime TachographCardExpirationDate { get; set; }
        [DataMember]
        public string TachographCardExpirationDateString
        {
            get
            {
                return TachographCardExpirationDate.ToString("dd/MM/yyyy");
            }
        }
        [DataMember]
        public Guid Employer { get; set; }
        [DataMember]
        public Guid Truck { get; set; }
        [DataMember]
        public string EmployerName { get; set; }
        [DataMember]
        public int EmployerDropDownValue { get; set; }
        [DataMember]
        public string WorkerName { get { return string.Format("{0} {1}", FirstName, Surname); } }
    }
}
