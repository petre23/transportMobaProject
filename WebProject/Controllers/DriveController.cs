using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using DataLayer.PersistanceLayer;
using WebProject.App_Start;
using WebProject.Helpers;

namespace WebProject.Controllers
{
    public class DriveController : Controller
    {
        public IDataAccessLayer _dataAccessLayer = new DataAccessLayer.DataAccessLayer();
        public ErrorHelper _errorHelper = new ErrorHelper();
        // GET: Drive
        [AuthorizationAttribute]
        public ActionResult Index()
        {
            return View();
        }
        [AuthorizationAttribute]
        public ActionResult EditDrive()
        {
            ViewBag.WorkersForDropDown = _dataAccessLayer.GetWorkersForDropDown();
            ViewBag.TrucksForDropDown = _dataAccessLayer.GetTrucksForDropDown();
            return View();
        }
        [AuthorizationAttribute]
        public ActionResult GetDrives(string pageIndex, string pageSize)
        {
            try
            {
                return Json(new { drives = _dataAccessLayer.GetDrives(Convert.ToInt32(pageIndex) - 1, Convert.ToInt32(pageSize)) });
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
        [AuthorizationAttribute]
        public ActionResult SaveDrive(Drive drive)
        {
            try
            {
                drive.LastUpdateByUser = Guid.Parse(Session["UserId"].ToString());
                return Json(new { driveId = _dataAccessLayer.SaveDrive(drive) });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [AuthorizationAttribute]
        public ActionResult GetDrive(Guid idDrive)
        {
            try
            {
                return Json(new { drive = _dataAccessLayer.GetDrive(idDrive) });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [AuthorizationAttribute]
        public ActionResult DeleteDrive(Guid driveId)
        {
            try
            {
                _dataAccessLayer.DeleteDrive(driveId);
                return Json(new { success = "true" });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
    }
}