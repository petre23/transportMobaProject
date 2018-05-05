using DataLayer.PersistanceLayer;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DataAccessLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DataAccessLayer : IDataAccessLayer
    {
        WorkerRepository _angajatRepository;
        TruckRepository _truckRepository;
        DriveRepository _driveRepository;

        public DataAccessLayer()
        {
            _angajatRepository = new WorkerRepository();
            _truckRepository = new TruckRepository();
            _driveRepository = new DriveRepository();
        }

        public List<Worker> GetWorkers()
        {
            return _angajatRepository.GetWorkers();
        }

        public Guid SaveWorker(Worker worker)
        {
            return _angajatRepository.SaveWorker(worker);
        }

        public Worker GetWorker(Guid idWorker)
        {
            return _angajatRepository.GetWorker(idWorker);
        }

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

        public List<Drive> GetDrives()
        {
            return _driveRepository.GetDrives();
        }

        public Guid SaveDrive(Drive drive)
        {
            return _driveRepository.SaveDrive(drive);
        }

        public Drive GetDrive(Guid idDrive)
        {
            return _driveRepository.GetDrive(idDrive);
        }
    }
}
