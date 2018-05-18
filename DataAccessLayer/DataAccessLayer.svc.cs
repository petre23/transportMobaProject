using DataLayer.PersistanceLayer;
using BusinessLogicLayer.Logic;
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
        WorkerBL _workerLogic;
        TruckBL _truckLogic;
        DriveBL _driveLogic;
        UserBL _userLogic;

        public DataAccessLayer()
        {
            _workerLogic = new WorkerBL();
            _truckLogic = new TruckBL();
            _driveLogic = new DriveBL();
            _userLogic = new UserBL();
        }

        public List<Worker> GetWorkers()
        {
            return _workerLogic.GetWorkers();
        }

        public Guid SaveWorker(Worker worker)
        {
            return _workerLogic.SaveWorker(worker);
        }

        public Worker GetWorker(Guid idWorker)
        {
            return _workerLogic.GetWorker(idWorker);
        }

        public void DeleteWorker(Guid workerId)
        {
            _workerLogic.DeleteWorker(workerId);
        }

        public List<Worker> GetWorkersForDropDown()
        {
            return _workerLogic.GetWorkersForDropDown();
        }

        public List<Truck> GetTrucks()
        {
            return _truckLogic.GetTrucks();
        }

        public Guid SaveTruck(Truck truck)
        {
            return _truckLogic.SaveTruck(truck);
        }

        public Truck GetTruck(Guid idTruck)
        {
            return _truckLogic.GetTruck(idTruck);
        }

        public void DeleteTruck(Guid truckId)
        {
            _truckLogic.DeleteTruck(truckId);
        }

        public List<Truck> GetTrucksForDropDown()
        {
            return _truckLogic.GetTrucksForDropDown();
        }

        public List<Drive> GetDrives()
        {
            return _driveLogic.GetDrives();
        }

        public Guid SaveDrive(Drive drive)
        {
            return _driveLogic.SaveDrive(drive);
        }

        public Drive GetDrive(Guid idDrive)
        {
            return _driveLogic.GetDrive(idDrive);
        }

        public void DeleteDrive(Guid driveId)
        {
            _driveLogic.DeleteDrive(driveId);
        }

        public User Login(User user)
        {
            return _userLogic.Login(user);
        }
    }
}
