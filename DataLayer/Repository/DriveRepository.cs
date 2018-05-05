using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class DriveRepository
    {
        public List<Drive> GetDrives()
        {
            return new List<Drive>();
        }

        public Guid SaveDrive(Drive drive)
        {
            return Guid.Empty;
        }

        public Drive GetDrive(Guid idDrive)
        {
            return new Drive();
        }
    }
}
