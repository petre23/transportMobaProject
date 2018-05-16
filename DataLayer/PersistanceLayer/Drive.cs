using System;
using System.Runtime.Serialization;

namespace DataLayer.PersistanceLayer
{
    [DataContract]
    public class Drive
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Guid Worker { get; set; }
        [DataMember]
        public Guid Truck { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string DateString { get { return Date.ToString("dd/MM/yyyy"); } }
        [DataMember]
        public string Vlaplan { get; set; }
        [DataMember]
        public string Vlaref { get; set; }
        [DataMember]
        public string LoadingPlace { get; set; }
        [DataMember]
        public string Destination { get; set; }
        [DataMember]
        public int InitialGPSKM { get; set; }
        [DataMember]
        public int FinalGPSKM { get; set; }
        [DataMember]
        public int DistanceGPS { get; set; }
        [DataMember]
        public int DistanceGpl { get; set; }
        [DataMember]
        public int DistanceDFDS { get; set; }
        [DataMember]
        public int Difference { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public decimal WeightInTons { get; set; }
        [DataMember]
        public decimal WorkerCosts { get; set; }
        [DataMember]
        public string CostsSpecification { get; set; }
        [DataMember]
        public decimal PayedCosts { get; set; }
        [DataMember]
        public decimal SettlementCosts { get; set; }
        [DataMember]
        public decimal TotalPayments { get; set; }
        [DataMember]
        public int GPSInitialConsumption { get; set; }
        [DataMember]
        public int GPSFinalConsumption { get; set; }
        [DataMember]
        public int GPSConsumption { get; set; }
        [DataMember]
        public int EstimatedConsumption { get; set; }
        [DataMember]
        public int FueledKM { get; set; }
        [DataMember]
        public int FueledDieseKMLiters { get; set; }
        [DataMember]
        public decimal DieselValue { get; set; }
        [DataMember]
        public int RealConsumption { get; set; }
        [DataMember]
        public int AdblueLiters { get; set; }
        [DataMember]
        public int AdblueValue { get; set; }

        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string WorkerName { get { return string.Format("{0} {1}", FirstName, Surname); } }
        [DataMember]
        public string TruckRegistrationNumber { get; set; }
    }
}
