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
    public class SetupController : Controller
    {
        // GET: Setup
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        public ActionResult Index()
        {
            return View();
        }


        #region Symphead
        public ActionResult Symphead()
        {
            List<Symphead> CategoryList = new List<Symphead>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchSymphead";

            ds = dl.FetchSymphead_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Symphead m = new Symphead();

                    m.SympId = item["SympId"].ToString();
                    m.Symptomshead = item["Symptomshead"].ToString();
                    m.SymptomsType = item["SymptomsType"].ToString();
                    m.SympDescription = item["SympDescription"].ToString();
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
        public ActionResult Symphead(Symphead c)
        {
            try
            {
                if (dl.InsertSymphead_Sp(c) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Setup/Symphead");
            }
            TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/Setup/Symphead");
        }


        public JsonResult DeleteSymphead(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteSymphead";
            ds = dl.FetchSymphead_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SympheadStatus(string id, string status)
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
            a.OnTable = "ChangeSympheadStatus";
            ds = dl.FetchSymphead_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditSymphead(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchSymphead";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchSymphead_sp(p);

            Symphead info = new RXGOADMIN.Models.Symphead();
            try
            {
                info = new RXGOADMIN.Models.Symphead()
                {
                    SympId = ds.Tables[1].Rows[0]["SympId"].ToString(),
                    Symptomshead = ds.Tables[1].Rows[0]["Symptomshead"].ToString(),
                    SymptomsType = ds.Tables[1].Rows[0]["SymptomsType"].ToString(),
                    SympDescription = ds.Tables[1].Rows[0]["SympDescription"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }

        #endregion

        #region SympType
        public ActionResult SympType()
        {
            List<SympType> CategoryList = new List<SympType>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchSympType";

            ds = dl.FetchSympType_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    SympType m = new SympType();

                    m.SympTypeId = item["SympTypeId"].ToString();
                    m.SymptomsType = item["SymptomsType"].ToString();
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
        public ActionResult SympType(SympType c)
        {
            try
            {
                if (dl.InsertSympType_Sp(c) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Setup/SympType");
            }
            TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/Setup/SympType");
        }


        public JsonResult DeleteSympType(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteSympType";
            ds = dl.FetchSympType_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SympTypeStatus(string id, string status)
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
            a.OnTable = "ChangeSympTypeStatus";
            ds = dl.FetchSympType_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditSympType(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchSympType";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchSympType_sp(p);

            SympType info = new RXGOADMIN.Models.SympType();
            try
            {
                info = new RXGOADMIN.Models.SympType()
                {
                    SympTypeId = ds.Tables[1].Rows[0]["SympTypeId"].ToString(),
                    SymptomsType = ds.Tables[1].Rows[0]["SymptomsType"].ToString()
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