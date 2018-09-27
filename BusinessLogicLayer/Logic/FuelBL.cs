using BusinessLogicLayer.Helpers;
using DataLayer.PersistanceLayer;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Logic
{
    public class FuelBL
    {
        FuelRepository _fuelRepository = new FuelRepository();

        public List<Fuel> GetFuelInfo()
        {
            return _fuelRepository.GetFuelInfo();
        }

        public Fuel GetFuelInfoById(Guid fuelId)
        {
            return _fuelRepository.GetFuelInfoById(fuelId);
        }

        public Guid SaveFuelInfo(Fuel fuel)
        {
            var adaptedFuel = new FuelHelper().AdaptFuel(fuel);
            return _fuelRepository.SaveFuel(adaptedFuel);
        }

        public void DeleteFuel(Guid fuelId)
        {
            _fuelRepository.DeleteFuel(fuelId);
        }

        public decimal? GetEstimatedConsumtionSumForDriverAndDate(Guid workerId, DateTime date)
        {
            return _fuelRepository.GetEstimatedConsumtionSumForDriverAndDate(workerId, date);
        }

        public decimal GetLastKmGPSForDriver(Guid workerId)
        {
            return _fuelRepository.GetLastKmGPSForDriver(workerId);
        }
    }
}
