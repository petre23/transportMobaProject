using System.Web;
using System.Web.Mvc;

namespace WebProject.App_Start
{
    public class AuthorizationAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return true;
            //return httpContext.Session != null && httpContext.Session["UserId"] != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //if (HttpContext.Current.Session == null || HttpContext.Current.Session["UserId"] == null)
            //{
            //    filterContext.Result = new RedirectResult("~/Login/Index");
            //}
        }
    }
}