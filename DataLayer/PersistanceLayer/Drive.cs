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
        public decimal InitialGPSKM { get; set; }
        [DataMember]
        public string InitialGPSKMString { get; set; }
        [DataMember]
        public decimal FinalGPSKM { get; set; }
        [DataMember]
        public string FinalGPSKMString { get; set; }
        [DataMember]
        public decimal DistanceGPS { get; set; }
        [DataMember]
        public string DistanceGPSString { get; set; }
        [DataMember]
        public decimal DistanceGpl { get; set; }
        [DataMember]
        public string DistanceGplString { get; set; }
        [DataMember]
        public decimal DistanceDFDS { get; set; }
        [DataMember]
        public string DistanceDFDSString { get; set; }
        [DataMember]
        public decimal Difference { get; set; }
        [DataMember]
        public string DifferenceString { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public decimal WeightInTons { get; set; }
        [DataMember]
        public string WeightInTonsString { get; set; }
        [DataMember]
        public decimal WorkerCosts { get; set; }
        [DataMember]
        public string WorkerCostsString { get; set; }
        [DataMember]
        public string CostsSpecification { get; set; }
        [DataMember]
        public decimal PayedCosts { get; set; }
        [DataMember]
        public string PayedCostsString { get; set; }
        [DataMember]
        public decimal SettlementCosts { get; set; }
        [DataMember]
        public string SettlementCostsString { get; set; }
        [DataMember]
        public decimal TotalPayments { get; set; }
        [DataMember]
        public string TotalPaymentsString { get; set; }
        [DataMember]
        public decimal GPSInitialConsumption { get; set; }
        [DataMember]
        public string GPSInitialConsumptionString { get; set; }
        [DataMember]
        public decimal GPSFinalConsumption { get; set; }
        [DataMember]
        public string GPSFinalConsumptionString { get; set; }
        [DataMember]
        public decimal GPSConsumption { get; set; }
        [DataMember]
        public string GPSConsumptionString { get; set; }
        [DataMember]
        public decimal EstimatedConsumption { get; set; }
        [DataMember]
        public string EstimatedConsumptionString { get; set; }
        [DataMember]
        public decimal FueledKM { get; set; }
        [DataMember]
        public string FueledKMString { get; set; }
        [DataMember]
        public decimal FueledDieseKMLiters { get; set; }
        [DataMember]
        public string FueledDieseKMLitersString { get; set; }
        [DataMember]
        public decimal DieselValue { get; set; }
        [DataMember]
        public string DieselValueString { get; set; }
        [DataMember]
        public decimal RealConsumption { get; set; }
        [DataMember]
        public string RealConsumptionString { get; set; }
        [DataMember]
        public decimal AdblueLiters { get; set; }
        [DataMember]
        public string AdblueLitersString { get; set; }
        [DataMember]
        public decimal AdblueValue { get; set; }
        [DataMember]
        public string AdblueValueString { get; set; }
        [DataMember]
        public Guid LastUpdateByUser { get; set; }
        [DataMember]
        public string LastUpdateByUserName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string WorkerName { get { return string.Format("{0} {1}", FirstName, Surname); } }
        [DataMember]
        public string TruckRegistrationNumber { get; set; }

        [DataMember]
        public int TotalRows { get; set; }
    }
}
