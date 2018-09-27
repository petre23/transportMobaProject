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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // GET: Truck

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditWorker()
        {
            ViewBag.TrucksForDropDown = _dataAccessLayer.GetTrucksForDropDown();
            return View();
        }

        public ActionResult GetWorkers()
        {
            try
            {
                return Json(new { workers = _dataAccessLayer.GetWorkers(), JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in GetWorkers \n\r : {0} - {1}", ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }

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
                log.Error(string.Format("Error in SaveWorker with id: {0} \n\r : {1} - {2}",worker.Id, ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }

        public ActionResult GetWorker(Guid idWorker)
        {
            try
            {
                return Json(new { worker = _dataAccessLayer.GetWorker(idWorker), JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in GetWorker with id: {0} \n\r : {1} - {2}", idWorker, ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }

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
                log.Error(string.Format("Error in DeleteWorker with id: {0} \n\r : {1} - {2}", workerId, ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
    }
}