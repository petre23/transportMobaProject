﻿using BusinessLogicLayer.Helpers;
using DataLayer.PersistanceLayer;
using DataLayer.Repository;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Logic
{
    public class DriveBL
    {
        DriveRepository _driveRepository = new DriveRepository();
        public List<Drive> GetDrives(int pageSize = 0,int pageNumber = 50, FilterDrivesModel filterDrivesModel = null)
        {
            return _driveRepository.GetDrives(pageSize,pageNumber, filterDrivesModel);
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

        public List<Drive> GetDrivesForWorkerByDateInterval(Guid workerId,DateTime startDate,DateTime endDate)
        {
            return _driveRepository.GetDrivesForWorkerByDateInterval(workerId, startDate, endDate);
        }

        public List<DriveStatus> GetDriveStatuses()
        {
            return _driveRepository.GetDriveStatuses();
        }

        public List<DriveType> GetDriveTypes()
        {
            return _driveRepository.GetDriveTypes();
        }
    }
}
