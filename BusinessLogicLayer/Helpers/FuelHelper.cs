using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Helpers
{
    public class FuelHelper
    {
        public Fuel AdaptFuel(Fuel fuel)
        {
            var adaptedFuel = fuel;
            adaptedFuel.AdblueLiters = !string.IsNullOrEmpty(fuel.AdblueLitersString) ? Convert.ToDecimal(fuel.AdblueLitersString) : 0;
            adaptedFuel.AdblueValue = !string.IsNullOrEmpty(fuel.AdblueValueString) ? Convert.ToDecimal(fuel.AdblueValueString) : 0;
            adaptedFuel.DieselValue = !string.IsNullOrEmpty(fuel.DieselValueString) ? Convert.ToDecimal(fuel.DieselValueString) : 0;
            adaptedFuel.EstimatedConsumption = !string.IsNullOrEmpty(fuel.EstimatedConsumptionString) ? Convert.ToDecimal(fuel.EstimatedConsumptionString) : 0;
            adaptedFuel.FueledDieseKMLiters = !string.IsNullOrEmpty(fuel.FueledDieseKMLitersString) ? Convert.ToDecimal(fuel.FueledDieseKMLitersString) : 0;
            adaptedFuel.FueledKM = !string.IsNullOrEmpty(fuel.FueledKMString) ? Convert.ToDecimal(fuel.FueledKMString) : 0;
            adaptedFuel.GPSConsumption = !string.IsNullOrEmpty(fuel.GPSConsumptionString) ? Convert.ToDecimal(fuel.GPSConsumptionString) : 0;
            adaptedFuel.GPSFinalConsumption = !string.IsNullOrEmpty(fuel.GPSFinalConsumptionString) ? Convert.ToDecimal(fuel.GPSFinalConsumptionString) : 0;
            adaptedFuel.GPSInitialConsumption = !string.IsNullOrEmpty(fuel.GPSInitialConsumptionString) ? Convert.ToDecimal(fuel.GPSInitialConsumptionString) : 0;
            adaptedFuel.RealConsumption = !string.IsNullOrEmpty(fuel.RealConsumptionString) ? Convert.ToDecimal(fuel.RealConsumptionString) : 0;
            adaptedFuel.DistanceGPS = !string.IsNullOrEmpty(fuel.DistanceGPSString) ? Convert.ToDecimal(fuel.DistanceGPSString) : 0;
            adaptedFuel.WorkerSelfFueled = !string.IsNullOrEmpty(fuel.WorkerSelfFueledString) ? Convert.ToDecimal(fuel.WorkerSelfFueledString) : 0;
            adaptedFuel.WorkerSelfFueledPounds = !string.IsNullOrEmpty(fuel.WorkerSelfFueledPoundsString) ? Convert.ToDecimal(fuel.WorkerSelfFueledPoundsString) : 0;
            adaptedFuel.CompanyTKFuel = !string.IsNullOrEmpty(fuel.CompanyTKFuelString) ? Convert.ToDecimal(fuel.CompanyTKFuelString) : 0;
            adaptedFuel.CompanyTKFuelPounds = !string.IsNullOrEmpty(fuel.CompanyTKFuelPoundsString) ? Convert.ToDecimal(fuel.CompanyTKFuelPoundsString) : 0;
            adaptedFuel.WorkerTKFuel = !string.IsNullOrEmpty(fuel.WorkerTKFuelString) ? Convert.ToDecimal(fuel.WorkerTKFuelString) : 0;
            adaptedFuel.WorkerTKFuelPounds = !string.IsNullOrEmpty(fuel.WorkerTKFuelPoundsString) ? Convert.ToDecimal(fuel.WorkerTKFuelPoundsString) : 0;

            return adaptedFuel;
        }
    }
}
