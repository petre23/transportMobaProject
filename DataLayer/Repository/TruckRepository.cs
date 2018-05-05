using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class TruckRepository
    {
        public List<Truck> GetTrucks()
        {
            return new List<Truck>();
        }

        public Guid SaveTruck(Truck idTruck)
        {
            return Guid.Empty;
        }

        public Truck GetTruck(Guid idTruck)
        {
            return new Truck();
        }
    }
}
