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
    public class OperationController : Controller
    {
        // GET: Radiology
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        public ActionResult Index()
        {
            return View();
        }


        #region TPA
        public ActionResult TPA()
        {
            List<TPA> CategoryList = new List<TPA>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchTPA";

            ds = dl.FetchTPA_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    TPA m = new TPA();

                    m.TPAId = item["TPAId"].ToString();
                    m.TPAName = item["TPAName"].ToString();
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
        public ActionResult TPA(TPA c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertTPA_Sp(c) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Operation/TPA");
            }
            TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/Operation/TPA");
        }


        public JsonResult DeleteTPA(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteTPA";
            ds = dl.FetchTPA_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TPAStatus(string id, string status)
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
            a.OnTable = "ChangeTPAStatus";
            ds = dl.FetchTPA_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditTPA(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchTPA";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchTPA_sp(p);

            TPA info = new RXGOADMIN.Models.TPA();
            try
            {
                info = new RXGOADMIN.Models.TPA()
                {
                    TPAId = ds.Tables[1].Rows[0]["TPAId"].ToString(),
                    TPAName = ds.Tables[1].Rows[0]["TPAName"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }

        #endregion

        #region Charge Category
        public ActionResult ChargeCategory()
        {
            List<TPAChargeCategory> CategoryList = new List<TPAChargeCategory>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchChargeCategory";

            ds = dl.FetchChargeCat_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    TPAChargeCategory m = new TPAChargeCategory();

                    m.CategoryId = item["CategoryId"].ToString();
                    m.ChargeName = item["ChargeName"].ToString();
                    m.Code = item["Code"].ToString();
                    m.StandardCharge = item["StandardCharge"].ToString();
                    m.AppliedCharge = item["AppliedCharge"].ToString();
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
        public ActionResult ChargeCategory(TPAChargeCategory c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertChargeCat_Sp(c) > 0)
                {
                    TempData["MSG"] = "Charge Category Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Operation/ChargeCategory");
            }
            TempData["MSG"] = "Charge Category Added Successfully.";
            return Redirect("/Operation/ChargeCategory");
        }
        public JsonResult DeleteChargeCategory(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteChargeCategory";
            ds = dl.FetchChargeCat_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChangeCategoryStatus(string id, string status)
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
            a.OnTable = "ChangeChargeStatus";
            ds = dl.FetchChargeCat_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditChargeCategory(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchChargeCategory";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchChargeCat_sp(p);

            TPAChargeCategory info = new RXGOADMIN.Models.TPAChargeCategory();
            try
            {
                info = new RXGOADMIN.Models.TPAChargeCategory()
                {
                    CategoryId = ds.Tables[1].Rows[0]["CategoryId"].ToString(),
                    ChargeName = ds.Tables[1].Rows[0]["ChargeName"].ToString(),
                    Code = ds.Tables[1].Rows[0]["Code"].ToString(),
                    StandardCharge = ds.Tables[1].Rows[0]["StandardCharge"].ToString(),
                    AppliedCharge = ds.Tables[1].Rows[0]["AppliedCharge"].ToString()
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