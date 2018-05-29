using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DataAccessLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDataAccessLayer
    {
        [OperationContract]
        List<Worker> GetWorkers();

        [OperationContract]
        Guid SaveWorker(Worker worker);

        [OperationContract]
        Worker GetWorker(Guid idWorker);

        [OperationContract]
        void DeleteWorker(Guid workerId);

        [OperationContract]
        List<Worker> GetWorkersForDropDown();

        [OperationContract]
        List<Truck> GetTrucks();

        [OperationContract]
        Guid SaveTruck(Truck truck);

        [OperationContract]
        Truck GetTruck(Guid idTruck);

        [OperationContract]
        void DeleteTruck(Guid truckId);

        [OperationContract]
        List<Truck> GetTrucksForDropDown();

        [OperationContract]
        List<Drive> GetDrives(int pageSize = 0,int pageNumber = 50);

        [OperationContract]
        Guid SaveDrive(Drive drive);

        [OperationContract]
        Drive GetDrive(Guid idDrive);

        [OperationContract]
        void DeleteDrive(Guid driveId);

        [OperationContract]
        List<Notification> GetNotifications();

        [OperationContract]
        User Login(User user);

        [OperationContract]
        User GetUser(Guid userId);

        [OperationContract]
        List<User> GetUsers();

        [OperationContract]
        Guid SaveUser(User user);

        [OperationContract]
        void DeleteUser(Guid userId);
    }
}
