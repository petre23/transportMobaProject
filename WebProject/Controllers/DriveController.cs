using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using DataLayer.PersistanceLayer;
using WebProject.App_Start;
using WebProject.Helpers;

namespace WebProject.Controllers
{
    public class DriveController : Controller
    {
        public IDataAccessLayer _dataAccessLayer = new DataAccessLayer.DataAccessLayer();
        public ErrorHelper _errorHelper = new ErrorHelper();
        // GET: Drive
        [AuthorizationAttribute]
        public ActionResult Index()
        {
            ViewBag.WorkersForDropDown = _dataAccessLayer.GetWorkersForDropDown();
            return View();
        }
        [AuthorizationAttribute]
        public ActionResult EditDrive()
        {
            ViewBag.WorkersForDropDown = _dataAccessLayer.GetWorkersForDropDown();
            ViewBag.TrucksForDropDown = _dataAccessLayer.GetTrucksForDropDown();
            ViewBag.DriveStatusesForDropDown = _dataAccessLayer.GetDriveStatuses();
            return View();
        }
        [AuthorizationAttribute]
        public ActionResult GetDrives(string pageIndex, string pageSize,string searchText)
        {
            try
            {
                return Json(new { drives = _dataAccessLayer.GetDrives(Convert.ToInt32(pageSize), Convert.ToInt32(pageIndex) - 1, searchText), JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new
                {
                    error = _errorHelper.GetErrorMessage(ex)
                });
            }
        }
        [AuthorizationAttribute]
        public ActionResult SaveDrive(Drive drive)
        {
            try
            {
                drive.LastUpdateByUser = Guid.Parse(Session["UserId"].ToString());
                return Json(new { driveId = _dataAccessLayer.SaveDrive(drive) });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [AuthorizationAttribute]
        public ActionResult GetDrive(Guid idDrive)
        {
            try
            {
                return Json(new { drive = _dataAccessLayer.GetDrive(idDrive), JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }
        [AuthorizationAttribute]
        public ActionResult DeleteDrive(Guid driveId)
        {
            try
            {
                _dataAccessLayer.DeleteDrive(driveId);
                return Json(new { success = "true" });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }

        [AuthorizationAttribute]
        public ActionResult ExportToExcel()
        {
            try
            {
                var gv = AdaptGridViewForExport(_dataAccessLayer.GetDrives(99999, 0));

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=Drives.xls");
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                StringWriter objStringWriter = new StringWriter();
                HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
                gv.RenderControl(objHtmlTextWriter);
                Response.Output.Write(objStringWriter.ToString());
                Response.Flush();
                Response.End();

                ViewBag.WorkersForDropDown = _dataAccessLayer.GetWorkersForDropDown();
                return View("Index");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = _errorHelper.GetErrorMessage(ex) });
            }
        }

        [AuthorizationAttribute]
        public ActionResult GetDrivesForWorkerByDateInterval(Guid workerId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var gv = AdaptGridViewForExport(_dataAccessLayer.GetDrivesForWorkerByDateInterval(workerId, startDate,endDate));

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=Sofer.xls");
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                StringWriter objStringWriter = new StringWriter();
                HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
                gv.RenderControl(objHtmlTextWriter);
                Response.Output.Write(objStringWriter.ToString());
                Response.Flush();
                Response.End();

                ViewBag.WorkersForDropDown = _dataAccessLayer.GetWorkersForDropDown();
                return View("Index");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new
                {
                    error = _errorHelper.GetErrorMessage(ex)
                });
            }
        }

        private GridView AdaptGridViewForExport(List<Drive> drivesToBeExported)
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
                gv.HeaderRow.Cells[12].Visible = false;
                gv.HeaderRow.Cells[14].Visible = false;
                gv.HeaderRow.Cells[16].Visible = false;
                gv.HeaderRow.Cells[18].Visible = false;
                gv.HeaderRow.Cells[20].Visible = false;
                gv.HeaderRow.Cells[22].Visible = false;
                gv.HeaderRow.Cells[25].Visible = false;
                gv.HeaderRow.Cells[27].Visible = false;
                gv.HeaderRow.Cells[29].Visible = false;
                gv.HeaderRow.Cells[32].Visible = false;
                gv.HeaderRow.Cells[34].Visible = false;
                gv.HeaderRow.Cells[36].Visible = false;
                gv.HeaderRow.Cells[38].Visible = false;
                gv.HeaderRow.Cells[40].Visible = false;
                gv.HeaderRow.Cells[42].Visible = false;
                gv.HeaderRow.Cells[43].Visible = false;
                gv.HeaderRow.Cells[44].Visible = false;
                gv.HeaderRow.Cells[45].Visible = false;
                gv.HeaderRow.Cells[46].Visible = false;
                gv.HeaderRow.Cells[48].Visible = false;
                gv.HeaderRow.Cells[50].Visible = false;
                gv.HeaderRow.Cells[4].Text = Resources.Labels.Sofer;
                gv.HeaderRow.Cells[5].Text = Resources.Labels.NumarInmatriculare;
                gv.HeaderRow.Cells[6].Text = Resources.Labels.Data;
                gv.HeaderRow.Cells[7].Text = Resources.Labels.Vlaplan;
                gv.HeaderRow.Cells[8].Text = Resources.Labels.Vlarref;
                gv.HeaderRow.Cells[9].Text = Resources.Labels.LocIncarcare;
                gv.HeaderRow.Cells[10].Text = Resources.Labels.LocDescarcare;
                gv.HeaderRow.Cells[11].Text = Resources.Labels.KMGpsInitiali;
                gv.HeaderRow.Cells[13].Text = Resources.Labels.KMGpsFinal;
                gv.HeaderRow.Cells[15].Text = Resources.Labels.KMGps;
                gv.HeaderRow.Cells[17].Text = Resources.Labels.KMGgl;
                gv.HeaderRow.Cells[19].Text = Resources.Labels.KMDFSD;
                gv.HeaderRow.Cells[21].Text = Resources.Labels.Diferenta;
                gv.HeaderRow.Cells[23].Text = Resources.Labels.Motiv;
                gv.HeaderRow.Cells[24].Text = Resources.Labels.Tonaj;
                gv.HeaderRow.Cells[26].Text = Resources.Labels.CheltuieliSofer + " euro";
                gv.HeaderRow.Cells[28].Text = Resources.Labels.CheltuieliSofer + " lire";
                gv.HeaderRow.Cells[30].Text = Resources.Labels.SpecificatieCheltuieli;
                gv.HeaderRow.Cells[31].Text = Resources.Labels.CheltuieliPlatite + " euro";
                gv.HeaderRow.Cells[33].Text = Resources.Labels.CheltuieliPlatite + " lire";
                gv.HeaderRow.Cells[35].Text = Resources.Labels.CheltuieliDeDecontat + " euro";
                gv.HeaderRow.Cells[37].Text = Resources.Labels.CheltuieliDeDecontat + " lire";
                gv.HeaderRow.Cells[39].Text = Resources.Labels.TotalPlati + " euro";
                gv.HeaderRow.Cells[41].Text = Resources.Labels.TotalPlati + " lire";
                gv.HeaderRow.Cells[47].Text = Resources.Labels.Remorca;
                gv.HeaderRow.Cells[49].Text = Resources.Labels.StareCursa;

                foreach (GridViewRow row in gv.Rows)
                {
                    row.Cells[0].Visible = false;
                    row.Cells[1].Visible = false;
                    row.Cells[2].Visible = false;
                    row.Cells[3].Visible = false;
                    row.Cells[12].Visible = false;
                    row.Cells[14].Visible = false;
                    row.Cells[16].Visible = false;
                    row.Cells[18].Visible = false;
                    row.Cells[20].Visible = false;
                    row.Cells[22].Visible = false;
                    row.Cells[25].Visible = false;
                    row.Cells[27].Visible = false;
                    row.Cells[29].Visible = false;
                    row.Cells[32].Visible = false;
                    row.Cells[34].Visible = false;
                    row.Cells[36].Visible = false;
                    row.Cells[38].Visible = false;
                    row.Cells[40].Visible = false;
                    row.Cells[42].Visible = false;
                    row.Cells[43].Visible = false;
                    row.Cells[44].Visible = false;
                    row.Cells[45].Visible = false;
                    row.Cells[46].Visible = false;
                    row.Cells[48].Visible = false;
                    row.Cells[50].Visible = false;
                }
            }
            return gv;
        }
    }
}