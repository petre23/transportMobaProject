﻿using System;
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
        public DateTime? BirthDay { get; set; }
        [DataMember]
        public string BirthDayString
        {
            get
            {
                return BirthDay.HasValue ? BirthDay.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        [DataMember]
        public string IdentityDocument { get; set; }
        [DataMember]
        public string CNP { get; set; }
        [DataMember]
        public DateTime? CertificateExpirationDate { get; set; }
        [DataMember]
        public string CertificateExpirationDateString
        {
            get
            {
                return CertificateExpirationDate.HasValue ? CertificateExpirationDate.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        [DataMember]
        public DateTime? DrivingLicenseExpirationDate { get; set; }
        [DataMember]
        public string DrivingLicenseExpirationDateString
        {
            get
            {
                return DrivingLicenseExpirationDate.HasValue ? DrivingLicenseExpirationDate.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        [DataMember]
        public DateTime? EmploymentDate { get; set; }
        [DataMember]
        public string EmploymentDateString
        {
            get
            {
                return EmploymentDate.HasValue ? EmploymentDate.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        [DataMember]
        public DateTime? MedicalTestsExpirationDate { get; set; }
        [DataMember]
        public string MedicalTestsExpirationDateString
        {
            get
            {
                return MedicalTestsExpirationDate.HasValue ? MedicalTestsExpirationDate.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        [DataMember]
        public DateTime? TachographCardExpirationDate { get; set; }
        [DataMember]
        public string TachographCardExpirationDateString
        {
            get
            {
                return TachographCardExpirationDate.HasValue ? TachographCardExpirationDate.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        [DataMember]
        public Guid Employer { get; set; }
        [DataMember]
        public Guid? Truck { get; set; }
        [DataMember]
        public string TruckRegistrationNumber { get; set; }
        [DataMember]
        public string EmployerName { get; set; }
        [DataMember]
        public int EmployerDropDownValue { get; set; }
        [DataMember]
        public string WorkerName { get { return string.Format("{0} {1}", FirstName, Surname); } }
    }
}
