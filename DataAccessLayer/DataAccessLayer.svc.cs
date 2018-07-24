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
        NotificationBL _notificationLogic;
        FuelBL _fuelLogic;
        BrandsBL _brandLogic;

        public DataAccessLayer()
        {
            _workerLogic = new WorkerBL();
            _truckLogic = new TruckBL();
            _driveLogic = new DriveBL();
            _userLogic = new UserBL();
            _notificationLogic = new NotificationBL();
            _fuelLogic = new FuelBL();
            _brandLogic = new BrandsBL();
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

        public List<Drive> GetDrives(int pageSize = 0, int pageNumber = 50, string searchText = null)
        {
            return _driveLogic.GetDrives(pageSize,pageNumber, searchText);
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

        public List<Notification> GetNotifications()
        {
            return _notificationLogic.GetNotifications();
        }

        public User GetUser(Guid userId)
        {
            return _userLogic.GetUser(userId);
        }

        public List<User> GetUsers()
        {
            return _userLogic.GetUsers();
        }

        public Guid SaveUser(User user)
        {
            return _userLogic.SaveUser(user);
        }

        public void DeleteUser(Guid userId)
        {
            _userLogic.DeleteUser(userId);
        }

        public Fuel GetFuelById(Guid fuelId)
        {
            return _fuelLogic.GetFuelInfoById(fuelId);
        }

        public List<Fuel> GetFuelInfo()
        {
            return _fuelLogic.GetFuelInfo();
        }

        public Guid SaveFuel(Fuel fuel)
        {
            return _fuelLogic.SaveFuelInfo(fuel);
        }

        public void DeleteFuel(Guid fuelId)
        {
            _fuelLogic.DeleteFuel(fuelId);
        }

        public List<Drive> GetDrivesForWorkerByDateInterval(Guid workerId, DateTime startDate, DateTime endDate)
        {
            return _driveLogic.GetDrivesForWorkerByDateInterval(workerId, startDate, endDate);
        }

        public List<DriveStatus> GetDriveStatuses()
        {
            return _driveLogic.GetDriveStatuses();
        }

        public List<Brand> GetBrands()
        {
            return _brandLogic.GetBrands();
        }

        public Guid SaveBrand(Brand brand)
        {
            return _brandLogic.SaveBrand(brand);
        }

        public decimal? GetEstimatedConsumtionSumForDriverAndDate(Guid workerId, DateTime date)
        {
            return _fuelLogic.GetEstimatedConsumtionSumForDriverAndDate(workerId, date);
        }
    }
}
