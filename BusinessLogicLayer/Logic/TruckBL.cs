using DataLayer.PersistanceLayer;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Logic
{
    public class TruckBL
    {
        TruckRepository _truckRepository = new TruckRepository();
        public List<Truck> GetTrucks()
        {
            return _truckRepository.GetTrucks();
        }

        public Guid SaveTruck(Truck truck)
        {
            return _truckRepository.SaveTruck(truck);
        }

        public Truck GetTruck(Guid idTruck)
        {
            return _truckRepository.GetTruck(idTruck);
        }

        public void DeleteTruck(Guid truckId)
        {
            _truckRepository.DeleteTruck(truckId);
        }

        public List<Truck> GetTrucksForDropDown()
        {
            return _truckRepository.GetTrucksForDropDown();
        }
    }
}
