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
        public ErrorHelper _errorHelper = new ErrorHelper();
        [AuthorizationAttribute]
        public ActionResult Index()
        {
            return View();
        }
        [AuthorizationAttribute]
        public ActionResult EditUser()
        {
            return View();
        }
        [AuthorizationAttribute]
        public ActionResult GetUsers()
        {
            try
            {
                return Json(new { users = _dataAccessLayer.GetUsers(), JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [AuthorizationAttribute]
        public ActionResult GetUser(Guid userId)
        {
            try
            {
                return Json(new { user = _dataAccessLayer.GetUser(userId), JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [AuthorizationAttribute]
        public ActionResult SaveUser(User user)
        {
            try
            {
                var userId = _dataAccessLayer.SaveUser(user);
                return Json(new { userId });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [AuthorizationAttribute]
        public ActionResult DeleteUser(Guid userId)
        {
            try
            {
                _dataAccessLayer.DeleteUser(userId);
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