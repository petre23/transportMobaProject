using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using DataLayer.PersistanceLayer;
using WebProject.Helpers;

namespace WebProject.Controllers
{
    public class DriveController : Controller
    {
        public IDataAccessLayer _dataAccessLayer = new DataAccessLayer.DataAccessLayer();
        public ErrorHelper _errorHelper = new ErrorHelper();
        // GET: Drive
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditDrive()
        {
            return View();
        }

        public ActionResult GetDrives()
        {
            try
            {
                return Json(new { drivers = _dataAccessLayer.GetDrives() });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new
                {
                    error = _errorHelper.GetErrorMessage(ex)
                });
            }
        }

        public ActionResult SaveDrive(Drive drive)
        {
            try
            {
                return Json(new { drivers = _dataAccessLayer.SaveDrive(drive) });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }

        public ActionResult GetDriver(Guid idDrive)
        {
            try
            {
                return Json(new { drivers = _dataAccessLayer.GetDrive(idDrive) });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
    }
}