using DataAccessLayer;
using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebProject.Helpers;

namespace WebProject.Controllers
{
    public class TruckController : Controller
    {
        public IDataAccessLayer _dataAccessLayer = new DataAccessLayer.DataAccessLayer();
        public ErrorHelper _errorHelper = new ErrorHelper();
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
            try
            {
                return Json(new { trucks = _dataAccessLayer.GetTrucks() });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }

        public ActionResult SaveTruck(Truck truck)
        {
            try
            {
                return Json(new { truckId = _dataAccessLayer.SaveTruck(truck) });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }

        public ActionResult GetTruck(Guid idTruck)
        {
            try
            {
                return Json(new { truck = _dataAccessLayer.GetTruck(idTruck) });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
    }
}