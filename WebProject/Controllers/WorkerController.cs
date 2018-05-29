using DataAccessLayer;
using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.App_Start;
using WebProject.Helpers;

namespace WebProject.Controllers
{
    public class WorkerController : Controller
    {
        public IDataAccessLayer _dataAccessLayer = new DataAccessLayer.DataAccessLayer();
        public ErrorHelper _errorHelper = new ErrorHelper();
        // GET: Truck
        [AuthorizationAttribute]
        public ActionResult Index()
        {
            return View();
        }
        [AuthorizationAttribute]
        public ActionResult EditWorker()
        {
            ViewBag.TrucksForDropDown = _dataAccessLayer.GetTrucksForDropDown();
            return View();
        }
        [AuthorizationAttribute]
        public ActionResult GetWorkers()
        {
            try
            {
                return Json(new { workers = _dataAccessLayer.GetWorkers() });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [AuthorizationAttribute]
        public ActionResult SaveWorker(Worker worker)
        {
            try
            {
                var workerId = _dataAccessLayer.SaveWorker(worker);

                var notifications = _dataAccessLayer.GetNotifications();
                Session["NotificationNumber"] = notifications.Any() ? notifications.Count : 0;
                Session["Notifications"] = notifications.Any() ? notifications : new List<Notification>();

                return Json(new { workerId });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [AuthorizationAttribute]
        public ActionResult GetWorker(Guid idWorker)
        {
            try
            {
                return Json(new { worker = _dataAccessLayer.GetWorker(idWorker) });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [AuthorizationAttribute]
        public ActionResult DeleteWorker(Guid workerId)
        {
            try
            {
                _dataAccessLayer.DeleteWorker(workerId);

                var notifications = _dataAccessLayer.GetNotifications();
                Session["NotificationNumber"] = notifications.Any() ? notifications.Count : 0;
                Session["Notifications"] = notifications.Any() ? notifications : new List<Notification>();

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