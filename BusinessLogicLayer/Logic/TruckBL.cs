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
        BrandRepository _brandRepository = new BrandRepository();

        public List<Truck> GetTrucks()
        {
            return _truckRepository.GetTrucks();
        }

        public Guid SaveTruck(Truck truck)
        {
            var brands = _brandRepository.GetBrands();

            if (!string.IsNullOrEmpty(truck.BrandName) && !VerifyIfBrandExists(truck.BrandName, brands))
            {
                truck.Brand = _brandRepository.SaveBrand(new Brand() { Name = truck.BrandName });
            }
            else
            {
                truck.Brand = GetBrandByName(truck.BrandName, brands);
            }

            return _truckRepository.SaveTruck(truck);
        }

        private bool VerifyIfBrandExists(string brandName,List<Brand> brands)
        {
            return brands.Any(x => x.Name == brandName);
        }

        private Guid GetBrandByName(string brandName, List<Brand> brands)
        {
            return brands.FirstOrDefault(x => x.Name == brandName).Id;
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
