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
    public class TPAManageController : Controller
    {
        // GET: TPAManage
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult TPAManage()
        {
            List<TPAManage> CategoryList = new List<TPAManage>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchTPA";

            ds = dl.FetchTPAManage_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    TPAManage m = new TPAManage();

                    m.TPAId = item["TPAId"].ToString();
                    m.TPAName = item["TPAName"].ToString();
                    m.Code = item["Code"].ToString();
                    m.Phone = item["Phone"].ToString();
                    m.Address = item["Address"].ToString();
                    m.ContactPersonName = item["ContactPersonName"].ToString();
                    m.ContactPersonPhone = item["ContactPersonPhone"].ToString();
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
        public ActionResult TPAManage(TPAManage c)
        {
            try
            {
                if (dl.InsertTPAManage_Sp(c) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/TPAManage/TPAManage");
            }
            TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/TPAManage/TPAManage");
        }


        public JsonResult DeleteTPA(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteTPA";
            ds = dl.FetchTPAManage_sp(a);
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
            ds = dl.FetchTPAManage_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditTPAManage(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchTPA";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchTPAManage_sp(p);

            TPAManage info = new RXGOADMIN.Models.TPAManage();
            try
            {
                info = new RXGOADMIN.Models.TPAManage()
                {
                    TPAId = ds.Tables[0].Rows[0]["TPAId"].ToString(),
                    TPAName = ds.Tables[0].Rows[0]["TPAName"].ToString(),
                    Code = ds.Tables[0].Rows[0]["Code"].ToString(),
                    Phone = ds.Tables[0].Rows[0]["Phone"].ToString(),
                    Address = ds.Tables[0].Rows[0]["Address"].ToString(),
                    ContactPersonName = ds.Tables[0].Rows[0]["ContactPersonName"].ToString(),
                    ContactPersonPhone = ds.Tables[0].Rows[0]["ContactPersonPhone"].ToString(),
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }

    
    }
}