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
        public string ManufacturingYearString
        {
            get
            {
                return ManufacturingYear.HasValue ? ManufacturingYear.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        [DataMember]
        public DateTime? ITPExpirationDate { get; set; }
        [DataMember]
        public string ITPExpirationDateString
        {
            get
            {
                return ITPExpirationDate.HasValue ? ITPExpirationDate.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        [DataMember]
        public DateTime? InsuranceExpirationDate { get; set; }
        [DataMember]
        public string InsuranceExpirationDateString
        {
            get
            {
                return InsuranceExpirationDate.HasValue ? InsuranceExpirationDate.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        [DataMember]
        public DateTime? TachographExpirationDate { get; set; }
        [DataMember]
        public string TachographExpirationDateString
        {
            get
            {
                return TachographExpirationDate.HasValue ? TachographExpirationDate.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        [DataMember]
        public DateTime? VignetteExpirationDateUK { get; set; }
        [DataMember]
        public string VignetteExpirationDateUKString
        {
            get
            {
                return VignetteExpirationDateUK.HasValue ? VignetteExpirationDateUK.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        [DataMember]
        public DateTime? VignetteExpirationDateNL { get; set; }
        [DataMember]
        public string VignetteExpirationDateNLString
        {
            get
            {
                return VignetteExpirationDateNL.HasValue ? VignetteExpirationDateNL.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        [DataMember]
        public DateTime? ConformCopyExpirationDate { get; set; }
        [DataMember]
        public string ConformCopyExpirationDateString
        {
            get
            {
                return ConformCopyExpirationDate.HasValue ? ConformCopyExpirationDate.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        [DataMember]
        public DateTime? VignetteExpirationDateRO { get; set; }
        [DataMember]
        public string VignetteExpirationDateROString
        {
            get
            {
                return VignetteExpirationDateRO.HasValue ? VignetteExpirationDateRO.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }

        [DataMember]
        public string BrandName { get; set; }
        [DataMember]
        public int BrandDropDownValue { get; set; }
    }
}
