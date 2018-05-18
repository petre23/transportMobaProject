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
        List<Drive> GetDrives();

        [OperationContract]
        Guid SaveDrive(Drive drive);

        [OperationContract]
        Drive GetDrive(Guid idDrive);

        [OperationContract]
        User Login(User user);

        [OperationContract]
        void DeleteDrive(Guid driveId);
    }
}
