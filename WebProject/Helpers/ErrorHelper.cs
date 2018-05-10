using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebProject.Helpers
{
    public class ErrorHelper
    {
        public string GetErrorMessage(Exception ex)
        {
            var s = new StackTrace(ex);
            var thisasm = Assembly.GetExecutingAssembly();
            var methodname = s.GetFrames().Select(f => f.GetMethod()).First(m => m.Module.Assembly == thisasm).Name;
            var errorMessage = string.Format("{0} in method '{1}'",ex.Message,methodname);
            return errorMessage;
        }
    }
}