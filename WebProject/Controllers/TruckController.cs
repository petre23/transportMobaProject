using DataAccessLayer;
using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebProject.App_Start;
using WebProject.Helpers;

namespace WebProject.Controllers
{
    public class TruckController : Controller
    {
        public IDataAccessLayer _dataAccessLayer = new DataAccessLayer.DataAccessLayer();
        public ErrorHelper _errorHelper = new ErrorHelper();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // GET: Truck
        [AuthorizationAttribute]
        public ActionResult Index()
        {
            return View();
        }
        [AuthorizationAttribute]
        public ActionResult EditTruck()
        {
            ViewBag.BrandsForDropDown = _dataAccessLayer.GetBrands();
            return View();
        }
        [AuthorizationAttribute]
        public ActionResult GetTrucks()
        {
            try
            {
                return Json(new { trucks = _dataAccessLayer.GetTrucks(), JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in GetTrucks \n\r : {0} - {1}", ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [AuthorizationAttribute]
        public ActionResult SaveTruck(Truck truck)
        {
            try
            {
                var truckId = _dataAccessLayer.SaveTruck(truck);
                var notifications = _dataAccessLayer.GetNotifications();
                Session["NotificationNumber"] = notifications.Any() ? notifications.Count : 0;
                Session["Notifications"] = notifications.Any() ? notifications : new List<Notification>();

                return Json(new { truckId });
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in SaveTruck for truckId: {0} \n\r : {1} - {2}",truck.Id, ex.Message,ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [AuthorizationAttribute]
        public ActionResult GetTruck(Guid idTruck)
        {
            try
            {
                return Json(new { truck = _dataAccessLayer.GetTruck(idTruck), JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in GetTruck for truckId: {0} \n\r : {1} - {2}", idTruck, ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [AuthorizationAttribute]
        public ActionResult DeleteTruck(Guid truckId)
        {
            try
            {
                _dataAccessLayer.DeleteTruck(truckId);

                var notifications = _dataAccessLayer.GetNotifications();
                Session["NotificationNumber"] = notifications.Any() ? notifications.Count : 0;
                Session["Notifications"] = notifications.Any() ? notifications : new List<Notification>();

                return Json(new { success = "true" });
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in DeleteTruck for truckId: {0} \n\r : {1} - {2}", truckId, ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [AuthorizationAttribute]
        public ActionResult GetTrucksForDropDown()
        {
            try
            {
                return Json(new { trucksForDropDown = _dataAccessLayer.GetTrucksForDropDown(), JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in GetTrucksForDropDown \n\r : {0} - {1}", ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
    }
}