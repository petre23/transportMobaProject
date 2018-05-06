using DataAccessLayer;
using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class TruckController : Controller
    {
        public IDataAccessLayer _dataAccessLayer = new DataAccessLayer.DataAccessLayer();
        // GET: Truck
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditTruck()
        {
            return View();
        }

        public ActionResult GetTrucks()
        {
            return Json(new { drivers = _dataAccessLayer.GetTrucks() });
        }

        public ActionResult SaveTruck(Truck truck)
        {
            return Json(new { drivers = _dataAccessLayer.SaveTruck(truck) });
        }

        public ActionResult GetTruck(Guid idTruck)
        {
            return Json(new { drivers = _dataAccessLayer.GetTruck(idTruck) });
        }
    }
}