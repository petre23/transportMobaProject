using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class LoginController : Controller
    {
        DataAccessLayer.DataAccessLayer _dataAccessLayer = new DataAccessLayer.DataAccessLayer();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(User user)
        {
            var correctUser = _dataAccessLayer.Login(user);
            if (correctUser != null)
            {
                Session["UserId"] = correctUser.Id.ToString();
                Session["Username"] = correctUser.Username;
                Session["HasAdminRole"] = correctUser.HasAdminRole;
            }
            return Json(new { userName = correctUser != null ? correctUser.Username: string.Empty });
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return View("~/Views/Login/Index.cshtml");
        }
    }
}