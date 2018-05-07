using DataLayer.PersistanceLayer;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Logic
{
    public class WorkerBL
    {
        WorkerRepository _workerRepository = new WorkerRepository();
        public List<Worker> GetWorkers()
        {
            return _workerRepository.GetWorkers();
        }

        public Guid SaveWorker(Worker worker)
        {
            return _workerRepository.SaveWorker(worker);
        }

        public Worker GetWorker(Guid idWorker)
        {
            return _workerRepository.GetWorker(idWorker);
        }
    }
}
