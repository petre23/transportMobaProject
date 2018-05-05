using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using DataLayer.PersistanceLayer;

namespace WebProject.Controllers
{
    public class DriveController : Controller
    {
        public IDataAccessLayer _dataAccessLayer = new DataAccessLayer.DataAccessLayer();
        // GET: Drive
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDrives()
        {
            return Json(new { drivers = _dataAccessLayer.GetDrives() });
        }

        public ActionResult SaveDrive(Drive drive)
        {
            return Json(new { drivers = _dataAccessLayer.SaveDrive(drive) });
        }

        public ActionResult GetDriver(Guid idDrive)
        {
            return Json(new { drivers = _dataAccessLayer.GetDrive(idDrive) });
        }
    }
}