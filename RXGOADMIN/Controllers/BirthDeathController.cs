using RXGOADMIN.Helpers;
using RXGOADMIN.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RXGOADMIN.Controllers
{
    public class BirthDeathController : Controller
    {
        // GET: Finance
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        public ActionResult Index()
        {
            return View();
        }


        #region BirthRecord
        public ActionResult BirthRecord()
        {
            List<BirthRecord> CategoryList = new List<BirthRecord>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchBirthRecord";

            ds = dl.FetchBirthRecord_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    BirthRecord m = new BirthRecord();

                    m.FieldId = item["FieldId"].ToString();
                    m.FieldName = item["FieldName"].ToString();
                    m.AddedBy = item["AddedBy"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    CategoryList.Add(m);
                }
                ViewBag.CategoryList = CategoryList;
            }
            catch (Exception e)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult BirthRecord(BirthRecord c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertBirthRecord_Sp(c) > 0)
                {
                    TempData["MSG"] = "Birth Record Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/BirthDeath/BirthRecord");
            }
            TempData["MSG"] = "Birth Record Added Successfully.";
            return Redirect("/BirthDeath/BirthRecord");
        }


        public JsonResult DeleteBirthRecord(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteBirthRecord";
            ds = dl.FetchBirthRecord_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BirthRecordStatus(string id, string status)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            if (status == "True")
            {
                a.Condition1 = "False";
            }
            else
            {
                a.Condition1 = "True";
            }
            a.Condition2 = id;
            a.OnTable = "ChangeBirthRecordStatus";
            ds = dl.FetchBirthRecord_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditBirthRecord(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchBirthRecord";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchBirthRecord_sp(p);

            BirthRecord info = new RXGOADMIN.Models.BirthRecord();
            try
            {
                info = new RXGOADMIN.Models.BirthRecord()
                {
                    FieldId = ds.Tables[1].Rows[0]["FieldId"].ToString(),
                    FieldName = ds.Tables[1].Rows[0]["FieldName"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }

        #endregion

        #region DeathRecord
        public ActionResult DeathRecord()
        {
            List<DeathRecord> CategoryList = new List<DeathRecord>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchDeathRecord";

            ds = dl.FetchDeathRecord_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    DeathRecord m = new DeathRecord();

                    m.FieldId = item["FieldId"].ToString();
                    m.Name = item["Name"].ToString();
                    m.AddedBy = item["AddedBy"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    CategoryList.Add(m);
                }
                ViewBag.CategoryList = CategoryList;
            }
            catch (Exception e)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult DeathRecord(DeathRecord c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertDeathRecord_Sp(c) > 0)
                {
                    TempData["MSG"] = "Death Record Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/BirthDeath/DeathRecord");
            }
            TempData["MSG"] = "Death Record Added Successfully.";
            return Redirect("/BirthDeath/DeathRecord");
        }


        public JsonResult DeleteDeathRecord(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteDeathRecord";
            ds = dl.FetchDeathRecord_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeathRecordStatus(string id, string status)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            if (status == "True")
            {
                a.Condition1 = "False";
            }
            else
            {
                a.Condition1 = "True";
            }
            a.Condition2 = id;
            a.OnTable = "ChangeDeathRecordStatus";
            ds = dl.FetchDeathRecord_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditDeathRecord(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchDeathRecord";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchDeathRecord_sp(p);

            DeathRecord info = new RXGOADMIN.Models.DeathRecord();
            try
            {
                info = new RXGOADMIN.Models.DeathRecord()
                {
                    FieldId = ds.Tables[1].Rows[0]["FieldId"].ToString(),
                    Name = ds.Tables[1].Rows[0]["Name"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }

        #endregion

    }
}