using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.PersistanceLayer
{
    [DataContract]
    public class Truck
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string RegistrationNumber { get; set; }
        [DataMember]
        public Guid Brand { get; set; }
        [DataMember]
        public DateTime? ManufacturingYear { get; set; }
        [DataMember]
        public string ManufacturingYearString { get; set; }
        [DataMember]
        public DateTime? ITPExpirationDate { get; set; }
        [DataMember]
        public string ITPExpirationDateString { get; set; }
        [DataMember]
        public DateTime? InsuranceExpirationDate { get; set; }
        [DataMember]
        public string InsuranceExpirationDateString { get; set; }
        [DataMember]
        public DateTime? TachographExpirationDate { get; set; }
        [DataMember]
        public string TachographExpirationDateString { get; set; }
        [DataMember]
        public DateTime? VignetteExpirationDate { get; set; }
        [DataMember]
        public string VignetteExpirationDateString { get; set; }
        [DataMember]
        public DateTime? ConformCopyExpirationDate { get; set; }
        [DataMember]
        public string ConformCopyExpirationDateString { get; set; }
        [DataMember]
        public string BrandName { get; set; }
        [DataMember]
        public int BrandDropDownValue { get; set; }
    }
}
