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
    public class DriveBL
    {
        DriveRepository _driveRepository = new DriveRepository();
        public List<Drive> GetDrives(int pageSize = 0,int pageNumber = 50)
        {
            return _driveRepository.GetDrives(pageSize,pageNumber);
        }

        public Guid SaveDrive(Drive drive)
        {
            var adaptedDrive = new DriveHelper().AdaptDrive(drive);
            return _driveRepository.SaveDrive(adaptedDrive);
        }

        public Drive GetDrive(Guid idDrive)
        {
            return _driveRepository.GetDrive(idDrive);
        }

        public void DeleteDrive(Guid driveId)
        {
            _driveRepository.DeleteDrive(driveId);
        }
    }
}
