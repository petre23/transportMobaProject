using DataAccessLayer;
using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class WorkerController : Controller
    {
        public IDataAccessLayer _dataAccessLayer = new DataAccessLayer.DataAccessLayer();
        // GET: Truck
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditWorker()
        {
            return View();
        }

        public ActionResult GetWorkers()
        {
            return Json(new { drivers = _dataAccessLayer.GetWorkers() });
        }

        public ActionResult SaveWorker(Worker worker)
        {
            return Json(new { drivers = _dataAccessLayer.SaveWorker(worker) });
        }

        public ActionResult GetWorker(Guid idWorker)
        {
            return Json(new { drivers = _dataAccessLayer.GetWorker(idWorker) });
        }
    }
}