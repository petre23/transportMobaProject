using DataAccessLayer;
using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebProject.App_Start;
using WebProject.Helpers;

namespace WebProject.Controllers
{
    public class FuelController : Controller
    {
        public IDataAccessLayer _dataAccessLayer = new DataAccessLayer.DataAccessLayer();
        public ErrorHelper _errorHelper = new ErrorHelper();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // GET: Fuel
        public ActionResult Index()
        {
            ViewBag.WorkersForDropDown = _dataAccessLayer.GetWorkersForDropDown();
            ViewBag.TrucksForDropDown = _dataAccessLayer.GetTrucksForDropDown();
            return View();
        }

        public ActionResult EditFuel()
        {
            ViewBag.WorkersForDropDown = _dataAccessLayer.GetWorkersForDropDown();
            ViewBag.TrucksForDropDown = _dataAccessLayer.GetTrucksForDropDown();
            return View();
        }

        public ActionResult GetFuelInfo()
        {
            try
            {
                var fuelData = _dataAccessLayer.GetFuelInfo();
                var grouping = fuelData.GroupBy(x=>x.WorkerName).Select(g => new { Worker = g.Key, FuelData = g.ToList() }).ToList();

                return Json(new { fuelData = grouping });
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in GetFuelInfo \n\r : {0} - {1}", ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }

        public ActionResult SaveFuel(Fuel fuel)
        {
            try
            {
                var fuelId = _dataAccessLayer.SaveFuel(fuel);

                return Json(new { fuelId });
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in SaveFuel with id {0} \n\r : {1} - {2}",fuel.Id, ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }

        public ActionResult GetFuelByid(Guid fuelId)
        {
            try
            {
                return Json(new { fuel = _dataAccessLayer.GetFuelById(fuelId), JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in GetFuelByid for fueld with id {0} \n\r : {1} - {2}",fuelId, ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }

        public ActionResult DeleteFuel(Guid fuelId)
        {
            try
            {
                _dataAccessLayer.DeleteFuel(fuelId);

                return Json(new { success = "true" });
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in DeleteFuel for fueld with id {0} \n\r : {1} - {2}", fuelId, ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }

        public ActionResult GetEstimatedConsumtionSumForDriverAndDate(Guid workerId, DateTime date)
        {
            try
            {
                return Json(new { totalEstimatedConsumtion = _dataAccessLayer.GetEstimatedConsumtionSumForDriverAndDate(workerId,date) });
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in GetEstimatedConsumtionSumForDriverAndDate \n\r : {0} - {1}", ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }

        public ActionResult ExportFuelDataForTruckByDateInterval(Guid truckId, DateTime startDate, DateTime endDate)
        {
            try
            {
                log.Info(string.Format("Utilizatorul {0} a descarcat un excel cu alimentari pentru masina {1} in intervalul orar {2} - {3}.", Session["Username"], truckId, startDate, endDate));

                var truck = _dataAccessLayer.GetTruck(truckId);
                var fileName = string.Format("Alimentari-{0}.xls", truck.RegistrationNumber);

                var fuelData = _dataAccessLayer.GetFuelInfo();
                var gv = AdaptGridViewForExport(fuelData.Where(x => x.Date <= endDate && x.Date >= startDate && x.Truck == truckId).ToList());

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                StringWriter objStringWriter = new StringWriter();
                HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
                gv.RenderControl(objHtmlTextWriter);
                Response.Output.Write(objStringWriter.ToString());
                Response.Flush();
                Response.End();

                ViewBag.TrucksForDropDown = _dataAccessLayer.GetTrucksForDropDown();
                ViewBag.WorkersForDropDown = _dataAccessLayer.GetWorkersForDropDown();
                return View("Index");
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in FuelController - ExportFuelDataForWorkerByDateInterval \n\r : {0} - {1}", ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new
                {
                    error = _errorHelper.GetErrorMessage(ex)
                });
            }
        }

        public ActionResult ExportFuelDataForWorkerByDateInterval(Guid workerId, DateTime startDate, DateTime endDate)
        {
            try
            {
                log.Info(string.Format("Utilizatorul {0} a descarcat un excel cu alimentari pentru soferul {1} in intervalul orar {2} - {3}.", Session["Username"], workerId, startDate, endDate));

                var worker = _dataAccessLayer.GetWorker(workerId);
                var fileName = string.Format("Alimentari-{0}.xls", worker.WorkerName);

                var fuelData = _dataAccessLayer.GetFuelInfo();
                var gv = AdaptGridViewForExport(fuelData.Where(x => x.Date <= endDate && x.Date >= startDate && x.Worker == workerId).ToList());

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename="+ fileName);
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                StringWriter objStringWriter = new StringWriter();
                HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
                gv.RenderControl(objHtmlTextWriter);
                Response.Output.Write(objStringWriter.ToString());
                Response.Flush();
                Response.End();

                ViewBag.TrucksForDropDown = _dataAccessLayer.GetTrucksForDropDown();
                ViewBag.WorkersForDropDown = _dataAccessLayer.GetWorkersForDropDown();
                return View("Index");
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in FuelController - ExportFuelDataForWorkerByDateInterval \n\r : {0} - {1}", ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new
                {
                    error = _errorHelper.GetErrorMessage(ex)
                });
            }
        }

        private GridView AdaptGridViewForExport(List<Fuel> drivesToBeExported)
        {
            var gv = new GridView();
            gv.DataSource = drivesToBeExported;
            gv.DataBind();
            if (drivesToBeExported.Any())
            {
                gv.HeaderRow.Cells[0].Visible = false;
                gv.HeaderRow.Cells[1].Visible = false;
                gv.HeaderRow.Cells[2].Visible = false;
                gv.HeaderRow.Cells[3].Visible = false;
                gv.HeaderRow.Cells[4].Visible = false;
                gv.HeaderRow.Cells[7].Visible = false;
                gv.HeaderRow.Cells[9].Visible = false;
                gv.HeaderRow.Cells[11].Visible = false;
                gv.HeaderRow.Cells[13].Visible = false;
                gv.HeaderRow.Cells[15].Visible = false;
                gv.HeaderRow.Cells[17].Visible = false;
                gv.HeaderRow.Cells[19].Visible = false;
                gv.HeaderRow.Cells[21].Visible = false;
                gv.HeaderRow.Cells[23].Visible = false;
                gv.HeaderRow.Cells[25].Visible = false;
                gv.HeaderRow.Cells[26].Visible = false;
                gv.HeaderRow.Cells[29].Visible = false;

                gv.HeaderRow.Cells[5].Text = Resources.Labels.NumeSofer;
                gv.HeaderRow.Cells[6].Text = Resources.Labels.ConsumGPSInitial;
                gv.HeaderRow.Cells[8].Text = Resources.Labels.ConsumGPSFinal;
                gv.HeaderRow.Cells[10].Text = Resources.Labels.ConsumGPS;
                gv.HeaderRow.Cells[12].Text = Resources.Labels.ConsumEstimat;
                gv.HeaderRow.Cells[14].Text = Resources.Labels.KMAlimentati;
                gv.HeaderRow.Cells[16].Text = Resources.Labels.AlimentareDieselEWlitrii;
                gv.HeaderRow.Cells[18].Text = Resources.Labels.ValoareDiesel;
                gv.HeaderRow.Cells[20].Text = Resources.Labels.ConsumReal;
                gv.HeaderRow.Cells[22].Text = Resources.Labels.AdblueLitri;
                gv.HeaderRow.Cells[24].Text = Resources.Labels.ValoareAdblue;
                gv.HeaderRow.Cells[27].Text = Resources.Labels.Data;
                gv.HeaderRow.Cells[28].Text = Resources.Labels.KMGps;
                gv.HeaderRow.Cells[30].Text = Resources.Labels.NumarInmatriculare;

                foreach (GridViewRow row in gv.Rows)
                {
                    row.Cells[0].Visible = false;
                    row.Cells[1].Visible = false;
                    row.Cells[2].Visible = false;
                    row.Cells[3].Visible = false;
                    row.Cells[4].Visible = false;
                    row.Cells[7].Visible = false;
                    row.Cells[9].Visible = false;
                    row.Cells[11].Visible = false;
                    row.Cells[13].Visible = false;
                    row.Cells[15].Visible = false;
                    row.Cells[17].Visible = false;
                    row.Cells[19].Visible = false;
                    row.Cells[21].Visible = false;
                    row.Cells[23].Visible = false;
                    row.Cells[25].Visible = false;
                    row.Cells[26].Visible = false;
                    row.Cells[29].Visible = false;
                }
            }
            return gv;
        }

        public ActionResult GetLastKmGPSForDriver(Guid workerId)
        {
            try
            {
                return Json(new { lastKmGPSForDriver = _dataAccessLayer.GetLastKmGPSForDriver(workerId) });
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error in FuelController - GetLastKmGPSForDriver \n\r : {0} - {1}", ex.Message, ex.StackTrace));
                Response.StatusCode = 500;
                return Json(new
                {
                    error = _errorHelper.GetErrorMessage(ex)
                });
            }
        }
    }
}