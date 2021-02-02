using RXGOADMIN.Helpers;
using RXGOADMIN.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RXGO.Controllers
{
    public class AdminLoginController : Controller
    {
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(AdminLogin a)
        {
            Property p = new Property();
            DataSet ds = new DataSet();

            //byte[] e = ASCIIEncoding.ASCII.GetBytes(a.Email);
            //string EncryptedEmail = Convert.ToBase64String(e);

            //byte[] b = ASCIIEncoding.ASCII.GetBytes(a.Password);
            //string EncryptedPassword = Convert.ToBase64String(b);

            p.Condition1 = enc.Encrypt(a.Email);
            p.Condition2 = enc.Encrypt(a.Password);
            p.OnTable = "FetchAdminLoginUser";
            ds = dl.FetchAdminLogin(p);
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
                    String Type = ds.Tables[0].Rows[0]["UserType"].ToString();
                    String Status = ds.Tables[0].Rows[0]["IsActive"].ToString();

                    if (Type == "ADMIN" && Status == "True")
                    {
                        rxgoAdminCookie = new HttpCookie("rxgoAdmin");
                        rxgoAdminCookie["Hid"] = ds.Tables[0].Rows[0]["HospitalId"].ToString();
                        rxgoAdminCookie["Utyp"] = ds.Tables[0].Rows[0]["UserType"].ToString();
                        rxgoAdminCookie["UName"] = ds.Tables[0].Rows[0]["HospitalName"].ToString();
                        rxgoAdminCookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(rxgoAdminCookie);
                        return RedirectToAction("Index", "Admin");
                    }


                    else
                    {
                        TempData["MSGlogin"] = "Email-id / Password is incorrect";
                    }
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

            return RedirectToAction("Index", "AdminLogin");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];

            if (rxgoAdminCookie != null)
            {
                rxgoAdminCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(rxgoAdminCookie);
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            return Redirect("/AdminLogin");
        }
    }
}