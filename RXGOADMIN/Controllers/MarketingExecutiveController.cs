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
    public class MarketingExecutiveController : Controller
    {
        // GET: MarketingExecutive
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MarketingExecutive(string id)
        {
            HttpCookie rxgoadmin = Request.Cookies["rxgoAdmin"];
            string adminid = rxgoadmin.Values["Hid"];
            List<MarketingExecutive> ExecutiveList = new List<MarketingExecutive>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchExecutive";
            if (id != null)
            {
                p.Condition1 = id;
            }

            if (adminid != null)
            {
                p.Condition2 = adminid;
            }

            ds = dl.FetchMarketingExecutive_sp(p);

            List<SelectListItem> CountryList = new List<SelectListItem>();
            CountryList.Add(new SelectListItem { Text = "Select Country", Value = "" });
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                CountryList.Add(new SelectListItem { Text = dr["CountryName"].ToString(), Value = dr["CountryId"].ToString() });
            }
            ViewBag.CountryList = new SelectList(CountryList, "Value", "Text");

            MarketingExecutive info = new RXGOADMIN.Models.MarketingExecutive();
            try
            {
                info = new RXGOADMIN.Models.MarketingExecutive()
                {
                    ExecutiveId = ds.Tables[1].Rows[0]["ExecutiveId"].ToString(),
                    ExecutiveName = ds.Tables[1].Rows[0]["ExecutiveName"].ToString(),
                    ExecutivePhone = ds.Tables[1].Rows[0]["ExecutivePhone"].ToString(),
                    ExecutiveEmail = enc.Decrypt(ds.Tables[1].Rows[0]["ExecutiveEmail"].ToString()),
                    Password = enc.Decrypt(ds.Tables[1].Rows[0]["Password"].ToString()),
                    ExecutiveAddress = ds.Tables[1].Rows[0]["ExecutiveAddress"].ToString(),
                    ExecutiveAge = ds.Tables[1].Rows[0]["ExecutiveAge"].ToString(),
                    CountryName = ds.Tables[1].Rows[0]["CountryName"].ToString(),
                    StateName = ds.Tables[1].Rows[0]["StateName"].ToString(),
                    CityName = ds.Tables[1].Rows[0]["CityName"].ToString(),
                    CountryId = ds.Tables[1].Rows[0]["CountryId"].ToString(),
                    StateId = ds.Tables[1].Rows[0]["StateId"].ToString(),
                    CityId = ds.Tables[1].Rows[0]["CityId"].ToString()
                };

            }
            catch (Exception ex)
            {
            }

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                MarketingExecutive m = new MarketingExecutive();

                m.ExecutiveId = item["ExecutiveId"].ToString();
                m.ExecutiveName = item["ExecutiveName"].ToString();
                m.ExecutivePhone = item["ExecutivePhone"].ToString();
                m.ExecutiveEmail = enc.Decrypt(item["ExecutiveEmail"].ToString());
                m.ExecutiveAddress = item["ExecutiveAddress"].ToString();
                m.ExecutiveAge = item["ExecutiveAge"].ToString();
                m.IsActive = item["IsActive"].ToString();
                ExecutiveList.Add(m);
            }
            ViewBag.ExecutiveList = ExecutiveList;
            return View(info);
        }
        [HttpPost]
        public ActionResult MarketingExecutive(MarketingExecutive a)
        {
            a.ExecutiveEmail = enc.Encrypt(a.ExecutiveEmail);
            a.Password = enc.Encrypt(a.Password);

            try
            {
                if (dl.InsertExecutive_Sp(a) > 0)
                {
                    TempData["MSG"] = "Marketing Executive Added Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/MarketingExecutive/MarketingExecutive");
            }
            TempData["MSG"] = "Marketing Executive Added Successfully.";
            return Redirect("/MarketingExecutive/MarketingExecutive");
        }
        public JsonResult MarketingExecutiveStatus(string id, string status)
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
            a.OnTable = "ChangeExecutiveStatus";
            ds = dl.FetchMarketingExecutive_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteExecutive(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteExecutive";
            ds = dl.FetchMarketingExecutive_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditMarketingExecutive(string id)
        {
            HttpCookie rxgoadmin = Request.Cookies["rxgoAdmin"];
            string adminid = rxgoadmin.Values["Hid"];
            List<MarketingExecutive> ExecutiveList = new List<MarketingExecutive>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchExecutive";
            if (id != null)
            {
                p.Condition1 = id;
            }

            if (adminid != null)
            {
                p.Condition2 = adminid;
            }

            ds = dl.FetchMarketingExecutive_sp(p);

            List<SelectListItem> CountryList = new List<SelectListItem>();
            CountryList.Add(new SelectListItem { Text = "Select Country", Value = "" });
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                CountryList.Add(new SelectListItem { Text = dr["CountryName"].ToString(), Value = dr["CountryId"].ToString() });
            }
            ViewBag.CountryList = new SelectList(CountryList, "Value", "Text");

            MarketingExecutive info = new RXGOADMIN.Models.MarketingExecutive();
            try
            {
                info = new RXGOADMIN.Models.MarketingExecutive()
                {
                    ExecutiveId = ds.Tables[1].Rows[0]["ExecutiveId"].ToString(),
                    ExecutiveName = ds.Tables[1].Rows[0]["ExecutiveName"].ToString(),
                    ExecutivePhone = ds.Tables[1].Rows[0]["ExecutivePhone"].ToString(),
                    ExecutiveEmail = enc.Decrypt(ds.Tables[1].Rows[0]["ExecutiveEmail"].ToString()),
                    Password = enc.Decrypt(ds.Tables[1].Rows[0]["Password"].ToString()),
                    ExecutiveAddress = ds.Tables[1].Rows[0]["ExecutiveAddress"].ToString(),
                    ExecutiveAge = ds.Tables[1].Rows[0]["ExecutiveAge"].ToString(),
                    CountryName = ds.Tables[1].Rows[0]["CountryName"].ToString(),
                    StateName = ds.Tables[1].Rows[0]["StateName"].ToString(),
                    CityName = ds.Tables[1].Rows[0]["CityName"].ToString(),
                    CountryId = ds.Tables[1].Rows[0]["CountryId"].ToString(),
                    StateId = ds.Tables[1].Rows[0]["StateId"].ToString(),
                    CityId = ds.Tables[1].Rows[0]["CityId"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }
    }
}