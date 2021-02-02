using RXGOADMIN.Helpers;
using RXGOADMIN.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RXGOADMIN.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        public ActionResult Index()
        {
            HttpCookie rxgoadmin = Request.Cookies["rxgoAdmin"];
            string adminid = rxgoadmin.Values["Hid"];
            //List<UserTypes> TypeList = new List<UserTypes>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "UserList";

            if (adminid != null)
            {
                p.Condition1 = adminid;
            }

            ds = dl.FetchUserList_sp(p);

            List<SelectListItem> TypeList = new List<SelectListItem>();
            TypeList.Add(new SelectListItem { Text = "Select User Type", Value = "" });
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TypeList.Add(new SelectListItem { Text = dr["UserType"].ToString(), Value = dr["UserTypeId"].ToString() });
            }
            ViewBag.TypeList = new SelectList(TypeList, "Value", "Text");

            //foreach (DataRow item in ds.Tables[0].Rows)
            //{
            //    UserTypes m = new UserTypes();

            //    m.UserTypeId = item["UserTypeId"].ToString();
            //    m.UserType = item["UserType"].ToString();
            //    m.HospitalId = item["HospitalId"].ToString();
            //    m.IsActive = item["IsActive"].ToString();
            //    TypeList.Add(m);
            //}
            //ViewBag.TypeList = TypeList;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Index(EmployeeDetails e)
        {
            HttpCookie rxgoadmin = Request.Cookies["rxgoAdmin"];
            string adminid = rxgoadmin.Values["Hid"];
           
            try
            {
                Random r = new Random();
                var x = r.Next(0, 1000000);
                string s = x.ToString("000000");

                e.Password = s;
                //e.HospitalId = adminid;
                //e.VoterId = Session["Voterid"].ToString();
                //e.PanId = Session["Panid"].ToString();
                //e.AadharId = Session["AadharId"].ToString();
                e.ProfilePic = Session["ProfilePic"].ToString();

                if (dl.InsertEmployee_Sp(e) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully.";
                    //if (dl.InsertEmployee_Sp(e) > 0)
                    //{
                    //    TempData["MSG"] = "Data Saved Successfully.";
                    //}
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Json(new { data = "error" }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index", "Employee");
            }
            int response = 1;
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ShowEmployee()
        {
            HttpCookie rxgoadmin = Request.Cookies["rxgoAdmin"];
            string adminid = rxgoadmin.Values["Hid"];

            List<EmployeeDetails> EmployeeList = new List<EmployeeDetails>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchEmployee";

            if (adminid != null)
            {
                p.Condition1 = adminid;
            }

            ds = dl.FetchEmployee_sp(p);

            List<SelectListItem> TypeList = new List<SelectListItem>();
            TypeList.Add(new SelectListItem { Text = "Select User Type", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                TypeList.Add(new SelectListItem { Text = dr["UserType"].ToString(), Value = dr["UserTypeId"].ToString() });
            }
            ViewBag.TypeList = new SelectList(TypeList, "Value", "Text");
            
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                EmployeeDetails m = new EmployeeDetails();

                m.EmployeeId = item["EmployeeId"].ToString();
                m.FullName = item["FullName"].ToString();
                m.EmailId = item["EmailId"].ToString();
                m.Phone = item["Phone"].ToString();
                //m.Age = item["Age"].ToString();
                m.IsActive = item["IsActive"].ToString();
                EmployeeList.Add(m);
            }
            ViewBag.EmployeeList = EmployeeList;
            return View();
        }
        public JsonResult DeleteEmployee(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteEmployee";
            ds = dl.FetchEmployee_sp(a);
            TempData["MSG"] = "Data Deleted Successfully.";
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EmployeeStatus(string id, string status)
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
            a.OnTable = "ChangeEmployeeStatus";
            ds = dl.FetchEmployee_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult AddVoter(EmployeeDetails employeeDetail)
        //{
        //    var profile = Request.Files;

        //    string imgname = string.Empty;
        //    string ImageName = string.Empty;

        //    //Following code will check that image is there 
        //    //If it will Upload or else it will use Default Image

        //    string filePath = Server.MapPath("~/DataImages/" + ImageName);
        //    if (System.IO.File.Exists(filePath))
        //    {
        //        System.IO.File.Delete(filePath);
        //    }

        //    if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
        //    {
        //        var logo = System.Web.HttpContext.Current.Request.Files["file"];
        //        if (logo.ContentLength > 0)
        //        {
        //            var profileName = Path.GetFileName(logo.FileName);
        //            var ext = Path.GetExtension(logo.FileName);

        //            ImageName = profileName;
        //            var comPath = Server.MapPath("/DataImages/") + ImageName;

        //            logo.SaveAs(comPath);
        //            //employeeDetail.VoterId = comPath;
        //            Session["Voterid"] = "~/DataImages/" + profileName;
        //        }

        //    }
        //    //else
        //    //    employeeDetail.VoterId = Server.MapPath("/DataImages/") + "votercard.jpg";

        //    //int response = 1;
        //    //return Json(response, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult AddPanid(EmployeeDetails employeeDetail)
        //{
        //    var profile = Request.Files;

        //    string imgname = string.Empty;
        //    string ImageName = string.Empty;

        //    //Following code will check that image is there 
        //    //If it will Upload or else it will use Default Image

        //    if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
        //    {
        //        var logo = System.Web.HttpContext.Current.Request.Files["file"];
        //        if (logo.ContentLength > 0)
        //        {
        //            var profileName = Path.GetFileName(logo.FileName);
        //            var ext = Path.GetExtension(logo.FileName);

        //            ImageName = profileName;
        //            var comPath = Server.MapPath("/DataImages/") + ImageName;

        //            logo.SaveAs(comPath);
        //            employeeDetail.VoterId = comPath;
        //            Session["Panid"] = "~/DataImages/" + profileName;
        //        }

        //    }
        //    else
        //        employeeDetail.VoterId = Server.MapPath("/DataImages/") + "pancard.jpg";

        //    int response = 1;
        //    return Json(response, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult AddAadharId(EmployeeDetails employeeDetail)
        //{
        //    var profile = Request.Files;

        //    string imgname = string.Empty;
        //    string ImageName = string.Empty;

        //    //Following code will check that image is there 
        //    //If it will Upload or else it will use Default Image

        //    if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
        //    {
        //        var logo = System.Web.HttpContext.Current.Request.Files["file"];
        //        if (logo.ContentLength > 0)
        //        {
        //            var profileName = Path.GetFileName(logo.FileName);
        //            var ext = Path.GetExtension(logo.FileName);

        //            ImageName = profileName;
        //            var comPath = Server.MapPath("/DataImages/") + ImageName;

        //            logo.SaveAs(comPath);
        //            employeeDetail.VoterId = comPath;
        //            Session["AadharId"] = "~/DataImages/" + profileName;
        //        }

        //    }
        //    else
        //        employeeDetail.VoterId = Server.MapPath("/DataImages/") + "aadharid.jpg";

        //    int response = 1;
        //    return Json(response, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult ProfilePic(EmployeeDetails employeeDetail)
        //{
        //    var profile = Request.Files;

        //    string imgname = string.Empty;
        //    string ImageName = string.Empty;

        //    //Following code will check that image is there 
        //    //If it will Upload or else it will use Default Image

        //    if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
        //    {
        //        var logo = System.Web.HttpContext.Current.Request.Files["file"];
        //        if (logo.ContentLength > 0)
        //        {
        //            var profileName = Path.GetFileName(logo.FileName);
        //            var ext = Path.GetExtension(logo.FileName);

        //            ImageName = profileName;
        //            var comPath = Server.MapPath("/DataImages/") + ImageName;

        //            logo.SaveAs(comPath);
        //            //employeeDetail.VoterId = comPath;
        //            Session["ProfilePic"] = "~/DataImages/" + profileName;
        //        }

        //    }
        //    else
        //        //employeeDetail.VoterId = Server.MapPath("/DataImages/") + "profilepic.jpg";

        //    //int response = 1;
        //    //return Json(response, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult EditEmployee(string id)
        {
            //HttpCookie rxgoadmin = Request.Cookies["rxgoAdmin"];
            //string adminid = rxgoadmin.Values["Hid"];

            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchEmployee";

            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchEmployee_sp(p);

            EmployeeDetails info = new RXGOADMIN.Models.EmployeeDetails();
            try
            {
                info = new RXGOADMIN.Models.EmployeeDetails()
                {
                    EmployeeId=ds.Tables[2].Rows[0]["EmployeeId"].ToString(),
                    FullName = ds.Tables[2].Rows[0]["FullName"].ToString(),
                    EmailId = ds.Tables[2].Rows[0]["EmailId"].ToString(),
                    Phone = ds.Tables[2].Rows[0]["Phone"].ToString(),
                    //Age = ds.Tables[2].Rows[0]["Age"].ToString(),
                    Password= ds.Tables[2].Rows[0]["Password"].ToString(),
                    UserTypeId= ds.Tables[2].Rows[0]["UserTypeId"].ToString(),
                    //HospitalId= ds.Tables[2].Rows[0]["HospitalId"].ToString(),
                    //PayrollId=ds.Tables[3].Rows[0]["PayrollId"].ToString(),
                    Salary = Convert.ToDecimal(ds.Tables[3].Rows[0]["Salary"].ToString()),
                    //Pf = Convert.ToDecimal(ds.Tables[3].Rows[0]["Pf"].ToString()),
                    //MedicalIncentives = Convert.ToDecimal(ds.Tables[3].Rows[0]["MedicalIncentives"].ToString()),
                    //ServiceTax = Convert.ToDecimal(ds.Tables[3].Rows[0]["ServiceTax"].ToString()),
                    //Hra = Convert.ToDecimal(ds.Tables[3].Rows[0]["Hra"].ToString()),
                    //DocumentId=ds.Tables[4].Rows[0]["DocumentId"].ToString(),
                    //VoterId = ds.Tables[4].Rows[0]["VoterId"].ToString(),
                    //PanId = ds.Tables[4].Rows[0]["PanId"].ToString(),
                    //AadharId = ds.Tables[4].Rows[0]["AadharId"].ToString(),
                    ProfilePic = ds.Tables[4].Rows[0]["ProfilePic"].ToString(),
                    UserType = ds.Tables[5].Rows[0]["UserType"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return View(info);
            //return Json(info, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult UpdateEmployee(EmployeeDetails e)
        //{
        //    //HttpCookie rxgoadmin = Request.Cookies["rxgoAdmin"];
        //    //string adminid = rxgoadmin.Values["Hid"];

        //    try
        //    {
        //        if (!string.IsNullOrEmpty(Session["Voterid"] as string))
        //        {
        //            e.VoterId = Session["Voterid"].ToString();
        //        }
        //        else
        //        {
        //            e.VoterId = e.VoterId;
        //        }
        //        if (!string.IsNullOrEmpty(Session["Panid"] as string))
        //        {
        //            e.PanId = Session["Panid"].ToString();
        //        }
        //        else
        //        {
        //            e.PanId = e.PanId;
        //        }
        //        if (!string.IsNullOrEmpty(Session["AadharId"] as string))
        //        {
        //            e.AadharId = Session["AadharId"].ToString();
        //        }
        //        else
        //        {
        //            e.AadharId = e.AadharId;
        //        }
        //        if (!string.IsNullOrEmpty(Session["ProfilePic"] as string))
        //        {
        //            e.ProfilePic = Session["ProfilePic"].ToString();
        //        }
        //        else
        //        {
        //            e.ProfilePic = e.ProfilePic;
        //        }
        //        if (dl.UpdateEmployee_Sp(e) > 0)
        //        {
        //            TempData["MSG"] = "Data Saved Successfully.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["MSG"] = "Something went wrong.";
        //        return Json(new { data = "error" }, JsonRequestBehavior.AllowGet);
        //    }
        //    int response = 1;
        //    return Json(response, JsonRequestBehavior.AllowGet);
        //}
    }
}