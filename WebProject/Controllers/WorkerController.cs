﻿using DataAccessLayer;
using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Helpers;

namespace WebProject.Controllers
{
    public class WorkerController : Controller
    {
        public IDataAccessLayer _dataAccessLayer = new DataAccessLayer.DataAccessLayer();
        public ErrorHelper _errorHelper = new ErrorHelper();
        // GET: Truck
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditWorker()
        {
            return View();
        }

        public ActionResult GetWorkers()
        {
            try
            {
                return Json(new { drivers = _dataAccessLayer.GetWorkers() });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }

        public ActionResult SaveWorker(Worker worker)
        {
            try
            {
                return Json(new { drivers = _dataAccessLayer.SaveWorker(worker) });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }

        public ActionResult GetWorker(Guid idWorker)
        {
            try
            {
                return Json(new { drivers = _dataAccessLayer.GetWorker(idWorker) });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
    }
}