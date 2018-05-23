using DataLayer.PersistanceLayer;
using System;

namespace BusinessLogicLayer.Helpers
{
    public class DriveHelper
    {
        public Drive AdaptDrive(Drive drive)
        {
            var adaptedDrive = drive;
            adaptedDrive.AdblueLiters = !string.IsNullOrEmpty(drive.AdblueLitersString) ?  Convert.ToDecimal(drive.AdblueLitersString) : 0;
            adaptedDrive.AdblueValue = !string.IsNullOrEmpty(drive.AdblueValueString) ? Convert.ToDecimal(drive.AdblueValueString) : 0;
            adaptedDrive.DieselValue = !string.IsNullOrEmpty(drive.DieselValueString) ? Convert.ToDecimal(drive.DieselValueString) : 0;
            adaptedDrive.Difference = !string.IsNullOrEmpty(drive.DifferenceString) ? Convert.ToDecimal(drive.DifferenceString) : 0;
            adaptedDrive.DistanceDFDS = !string.IsNullOrEmpty(drive.DistanceDFDSString) ? Convert.ToDecimal(drive.DistanceDFDSString) : 0;
            adaptedDrive.DistanceGpl = !string.IsNullOrEmpty(drive.DistanceGplString) ? Convert.ToDecimal(drive.DistanceGplString) : 0;
            adaptedDrive.DistanceGPS = !string.IsNullOrEmpty(drive.DistanceGPSString) ? Convert.ToDecimal(drive.DistanceGPSString): 0;
            adaptedDrive.EstimatedConsumption = !string.IsNullOrEmpty(drive.EstimatedConsumptionString) ? Convert.ToDecimal(drive.EstimatedConsumptionString): 0;
            adaptedDrive.FinalGPSKM = !string.IsNullOrEmpty(drive.FinalGPSKMString) ? Convert.ToDecimal(drive.FinalGPSKMString): 0;
            adaptedDrive.FueledDieseKMLiters = !string.IsNullOrEmpty(drive.FueledDieseKMLitersString) ? Convert.ToDecimal(drive.FueledDieseKMLitersString): 0;
            adaptedDrive.FueledKM = !string.IsNullOrEmpty(drive.FueledKMString) ? Convert.ToDecimal(drive.FueledKMString): 0;
            adaptedDrive.GPSConsumption = !string.IsNullOrEmpty(drive.GPSConsumptionString) ? Convert.ToDecimal(drive.GPSConsumptionString): 0;
            adaptedDrive.GPSFinalConsumption = !string.IsNullOrEmpty(drive.GPSFinalConsumptionString) ? Convert.ToDecimal(drive.GPSFinalConsumptionString): 0;
            adaptedDrive.GPSInitialConsumption = !string.IsNullOrEmpty(drive.GPSInitialConsumptionString) ? Convert.ToDecimal(drive.GPSInitialConsumptionString): 0;
            adaptedDrive.InitialGPSKM = !string.IsNullOrEmpty(drive.InitialGPSKMString) ? Convert.ToDecimal(drive.InitialGPSKMString): 0;
            adaptedDrive.PayedCosts = !string.IsNullOrEmpty(drive.PayedCostsString) ? Convert.ToDecimal(drive.PayedCostsString): 0;
            adaptedDrive.RealConsumption = !string.IsNullOrEmpty(drive.RealConsumptionString) ? Convert.ToDecimal(drive.RealConsumptionString): 0;
            adaptedDrive.SettlementCosts = !string.IsNullOrEmpty(drive.SettlementCostsString) ? Convert.ToDecimal(drive.SettlementCostsString): 0;
            adaptedDrive.TotalPayments = !string.IsNullOrEmpty(drive.TotalPaymentsString) ? Convert.ToDecimal(drive.TotalPaymentsString): 0;
            adaptedDrive.WeightInTons = !string.IsNullOrEmpty(drive.WeightInTonsString) ? Convert.ToDecimal(drive.WeightInTonsString): 0;
            adaptedDrive.WorkerCosts = !string.IsNullOrEmpty(drive.WorkerCostsString) ? Convert.ToDecimal(drive.WorkerCostsString): 0;

            return adaptedDrive;
        }
    }
}
