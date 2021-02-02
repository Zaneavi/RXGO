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
    public class EmployeeLoginController : Controller
    {
        // GET: EmployeeLogin
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(EmployeeDetails a)
        {
            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchEmployeeLogin";
            p.Condition1 = a.EmailId;
            p.Condition2 = a.Password;

            ds = dl.FetchEmployee_sp(p);
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    HttpCookie rxgoEmployeeCookie = Request.Cookies["rxgoEmployee"];
                    rxgoEmployeeCookie = new HttpCookie("rxgoEmployee");
                    rxgoEmployeeCookie["Eid"] = ds.Tables[0].Rows[0]["EmployeeId"].ToString();
                    rxgoEmployeeCookie["Utyp"] = ds.Tables[0].Rows[0]["UserTypeId"].ToString();
                    rxgoEmployeeCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(rxgoEmployeeCookie);
                    return RedirectToAction("Index", "Employees");
                }
                else
                {
                    TempData["MSGlogin"] = "Email-id / Password is incorrect";
                }
            }
            catch (Exception ex)
            {
                TempData["MSGlogin"] = "Email-id / Password is incorrect or account not active!";
            }

            TempData["MSG"] = "Email-id / Password is incorrect or account not active!";

            return RedirectToAction("Index", "EmployeeLogin");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            HttpCookie rxgoEmployeeCookie = Request.Cookies["rxgoEmployee"];

            if (rxgoEmployeeCookie != null)
            {
                rxgoEmployeeCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(rxgoEmployeeCookie);
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            return Redirect("/EmployeeLogin");
        }
    }
}