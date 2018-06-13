using DataLayer.PersistanceLayer;
using System;

namespace BusinessLogicLayer.Helpers
{
    public class DriveHelper
    {
        public Drive AdaptDrive(Drive drive)
        {
            var adaptedDrive = drive;
            adaptedDrive.Difference = !string.IsNullOrEmpty(drive.DifferenceString) ? Convert.ToDecimal(drive.DifferenceString) : 0;
            adaptedDrive.DistanceDFDS = !string.IsNullOrEmpty(drive.DistanceDFDSString) ? Convert.ToDecimal(drive.DistanceDFDSString) : 0;
            adaptedDrive.DistanceGpl = !string.IsNullOrEmpty(drive.DistanceGplString) ? Convert.ToDecimal(drive.DistanceGplString) : 0;
            adaptedDrive.DistanceGPS = !string.IsNullOrEmpty(drive.DistanceGPSString) ? Convert.ToDecimal(drive.DistanceGPSString): 0;
            adaptedDrive.FinalGPSKM = !string.IsNullOrEmpty(drive.FinalGPSKMString) ? Convert.ToDecimal(drive.FinalGPSKMString): 0;
            adaptedDrive.InitialGPSKM = !string.IsNullOrEmpty(drive.InitialGPSKMString) ? Convert.ToDecimal(drive.InitialGPSKMString): 0;
            adaptedDrive.PayedCosts = !string.IsNullOrEmpty(drive.PayedCostsString) ? Convert.ToDecimal(drive.PayedCostsString): 0;
            adaptedDrive.SettlementCosts = !string.IsNullOrEmpty(drive.SettlementCostsString) ? Convert.ToDecimal(drive.SettlementCostsString): 0;
            adaptedDrive.TotalPayments = !string.IsNullOrEmpty(drive.TotalPaymentsString) ? Convert.ToDecimal(drive.TotalPaymentsString): 0;
            adaptedDrive.WeightInTons = !string.IsNullOrEmpty(drive.WeightInTonsString) ? Convert.ToDecimal(drive.WeightInTonsString): 0;
            adaptedDrive.WorkerCosts = !string.IsNullOrEmpty(drive.WorkerCostsString) ? Convert.ToDecimal(drive.WorkerCostsString): 0;

            return adaptedDrive;
        }
    }
}
