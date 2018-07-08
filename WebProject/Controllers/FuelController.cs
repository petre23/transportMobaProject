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
    public class FuelController : Controller
    {
        public IDataAccessLayer _dataAccessLayer = new DataAccessLayer.DataAccessLayer();
        public ErrorHelper _errorHelper = new ErrorHelper();
        // GET: Fuel
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizationAttribute]
        public ActionResult EditFuel()
        {
            ViewBag.WorkersForDropDown = _dataAccessLayer.GetWorkersForDropDown();
            return View();
        }
        [AuthorizationAttribute]
        public ActionResult GetFuelInfo()
        {
            try
            {
                return Json(new { fuelData = _dataAccessLayer.GetFuelInfo(), JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [AuthorizationAttribute]
        public ActionResult SaveFuel(Fuel fuel)
        {
            try
            {
                var fuelId = _dataAccessLayer.SaveFuel(fuel);

                return Json(new { fuelId });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [AuthorizationAttribute]
        public ActionResult GetFuelByid(Guid fuelId)
        {
            try
            {
                return Json(new { fuel = _dataAccessLayer.GetFuelById(fuelId), JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [AuthorizationAttribute]
        public ActionResult DeleteFuel(Guid fuelId)
        {
            try
            {
                _dataAccessLayer.DeleteFuel(fuelId);

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