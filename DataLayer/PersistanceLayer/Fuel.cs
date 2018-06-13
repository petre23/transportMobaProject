using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.PersistanceLayer
{
    [DataContract]
    public class Fuel
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Guid Worker { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string WorkerName { get { return string.Format("{0} {1}", FirstName, Surname); } }
        [DataMember]
        public decimal GPSInitialConsumption { get; set; }
        [DataMember]
        public string GPSInitialConsumptionString { get; set; }
        [DataMember]
        public decimal? GPSFinalConsumption { get; set; }
        [DataMember]
        public string GPSFinalConsumptionString { get; set; }
        [DataMember]
        public decimal? GPSConsumption { get; set; }
        [DataMember]
        public string GPSConsumptionString { get; set; }
        [DataMember]
        public decimal EstimatedConsumption { get; set; }
        [DataMember]
        public string EstimatedConsumptionString { get; set; }
        [DataMember]
        public decimal? FueledKM { get; set; }
        [DataMember]
        public string FueledKMString { get; set; }
        [DataMember]
        public decimal? FueledDieseKMLiters { get; set; }
        [DataMember]
        public string FueledDieseKMLitersString { get; set; }
        [DataMember]
        public decimal? DieselValue { get; set; }
        [DataMember]
        public string DieselValueString { get; set; }
        [DataMember]
        public decimal? RealConsumption { get; set; }
        [DataMember]
        public string RealConsumptionString { get; set; }
        [DataMember]
        public decimal? AdblueLiters { get; set; }
        [DataMember]
        public string AdblueLitersString { get; set; }
        [DataMember]
        public decimal? AdblueValue { get; set; }
        [DataMember]
        public string AdblueValueString { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string DateString { get { return Date.ToString("dd/MM/yyyy"); } }
    }
}
