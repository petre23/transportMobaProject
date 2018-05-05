using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class WorkerRepository
    {
        public List<Worker> GetWorkers()
        {
            return new List<Worker>();
        }

        public Guid SaveWorker(Worker worker)
        {
            return Guid.Empty;
        }

        public Worker GetWorker(Guid idWorker)
        {
            return new Worker();
        }
    }
}
