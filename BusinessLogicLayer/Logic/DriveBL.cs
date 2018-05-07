﻿using DataLayer.PersistanceLayer;
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
