using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Helpers;

namespace WebProject.Controllers
{
    public class LoginController : Controller
    {
        DataAccessLayer.DataAccessLayer _dataAccessLayer = new DataAccessLayer.DataAccessLayer();
        public ErrorHelper _errorHelper = new ErrorHelper();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(User user)
        {
            try
            {
                var correctUser = _dataAccessLayer.Login(user);
                if (correctUser != null)
                {
                    Session["UserId"] = correctUser.Id.ToString();
                    Session["Username"] = correctUser.Username;
                    Session["HasAdminRole"] = correctUser.HasAdminRole;
                }
                return Json(new { userName = correctUser != null ? correctUser.Username : string.Empty });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return View("~/Views/Login/Index.cshtml");
        }
    }
}