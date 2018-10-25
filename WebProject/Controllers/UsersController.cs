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
    public class UsersController : Controller
    {
        DataAccessLayer.DataAccessLayer _dataAccessLayer = new DataAccessLayer.DataAccessLayer();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ErrorHelper _errorHelper = new ErrorHelper();
        [Authorization]
        public ActionResult Index()
        {
            return View();
        }
        [Authorization]
        public ActionResult EditUser()
        {
            return View();
        }
        [Authorization]
        public ActionResult GetUsers()
        {
            try
            {
                return Json(new { users = _dataAccessLayer.GetUsers(), JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in GetUsers \n\r : {0}", ex.Message));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [Authorization]
        public ActionResult GetUser(Guid userId)
        {
            try
            {
                return Json(new { user = _dataAccessLayer.GetUser(userId), JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in GetUser with id {0} \n\r : {1} - {2}",userId, ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [Authorization]
        public ActionResult SaveUser(User user)
        {
            try
            {
                var userId = _dataAccessLayer.SaveUser(user);
                return Json(new { userId });
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in SaveUser with id {0} \n\r : {1} - {2}", user.Id, ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [Authorization]
        public ActionResult DeleteUser(Guid userId)
        {
            try
            {
                _dataAccessLayer.DeleteUser(userId);
                return Json(new { success = "true" });
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in DeleteUser with id {0} \n\r : {1} - {2}", userId, ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
    }
}