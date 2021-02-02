using RXGOADMIN.Helpers;
using RXGOADMIN.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RXGO.Controllers
{
    public class AdminController : Controller
    {

        protected List<string> keywords = new List<string>();
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult MarketingExecutive(string id)
        //{
        //    HttpCookie rxgoadmin = Request.Cookies["rxgoAdmin"];
        //    string adminid = rxgoadmin.Values["Hid"];
        //    List<MarketingExecutive> ExecutiveList = new List<MarketingExecutive>();
        //    Property p = new Property();
        //    DataSet ds = new DataSet();
        //    p.OnTable = "FetchExecutive";
        //    if (id != null)
        //    {
        //        p.Condition1 = id;
        //    }

        //    if (adminid != null)
        //    {
        //        p.Condition2 = adminid;
        //    }

        //    ds = dl.FetchMarketingExecutive_sp(p);

        //    List<SelectListItem> CountryList = new List<SelectListItem>();
        //    CountryList.Add(new SelectListItem { Text = "Select Country", Value = "" });
        //    foreach (DataRow dr in ds.Tables[2].Rows)
        //    {
        //        CountryList.Add(new SelectListItem { Text = dr["CountryName"].ToString(), Value = dr["CountryId"].ToString() });
        //    }
        //    ViewBag.CountryList = new SelectList(CountryList, "Value", "Text");

        //    MarketingExecutive info = new RXGOADMIN.Models.MarketingExecutive();
        //    try
        //    {
        //        info = new RXGOADMIN.Models.MarketingExecutive()
        //        {
        //            ExecutiveId = ds.Tables[1].Rows[0]["ExecutiveId"].ToString(),
        //            ExecutiveName = ds.Tables[1].Rows[0]["ExecutiveName"].ToString(),
        //            ExecutivePhone = ds.Tables[1].Rows[0]["ExecutivePhone"].ToString(),
        //            ExecutiveEmail = enc.Decrypt(ds.Tables[1].Rows[0]["ExecutiveEmail"].ToString()),
        //            Password = enc.Decrypt(ds.Tables[1].Rows[0]["Password"].ToString()),
        //            ExecutiveAddress = ds.Tables[1].Rows[0]["ExecutiveAddress"].ToString(),
        //            ExecutiveAge = ds.Tables[1].Rows[0]["ExecutiveAge"].ToString(),
        //            CountryName = ds.Tables[1].Rows[0]["CountryName"].ToString(),
        //            StateName = ds.Tables[1].Rows[0]["StateName"].ToString(),
        //            CityName = ds.Tables[1].Rows[0]["CityName"].ToString(),
        //            CountryId = ds.Tables[1].Rows[0]["CountryId"].ToString(),
        //            StateId = ds.Tables[1].Rows[0]["StateId"].ToString(),
        //            CityId = ds.Tables[1].Rows[0]["CityId"].ToString()
        //        };

        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    foreach (DataRow item in ds.Tables[0].Rows)
        //    {
        //        MarketingExecutive m = new MarketingExecutive();

        //        m.ExecutiveId = item["ExecutiveId"].ToString();
        //        m.ExecutiveName = item["ExecutiveName"].ToString();
        //        m.ExecutivePhone = item["ExecutivePhone"].ToString();
        //        m.ExecutiveEmail = enc.Decrypt(item["ExecutiveEmail"].ToString());
        //        m.ExecutiveAddress = item["ExecutiveAddress"].ToString();
        //        m.ExecutiveAge= item["ExecutiveAge"].ToString();
        //        m.IsActive = item["IsActive"].ToString();
        //        ExecutiveList.Add(m);
        //    }
        //    ViewBag.ExecutiveList = ExecutiveList;
        //    return View(info);
        //}
        //[HttpPost]
        //public ActionResult MarketingExecutive(MarketingExecutive a)
        //{
        //    a.ExecutiveEmail = enc.Encrypt(a.ExecutiveEmail);
        //    a.Password = enc.Encrypt(a.Password);

        //    try
        //    {
        //        if (dl.InsertExecutive_Sp(a) > 0)
        //        {
        //            TempData["MSG"] = "Data Saved Successfully.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["MSG"] = "Something went wrong.";
        //        return Redirect("/Admin/MarketingExecutive");
        //    }
        //    TempData["MSG"] = "Data Saved Successfully.";
        //    return Redirect("/Admin/MarketingExecutive");
        //}
        //public JsonResult MarketingExecutiveStatus(string id, string status)
        //{
        //    Property a = new Property();
        //    DataSet ds = new DataSet();
        //    if (status == "True")
        //    {
        //        a.Condition1 = "False";
        //    }
        //    else
        //    {
        //        a.Condition1 = "True";
        //    }
        //    a.Condition2 = id;
        //    a.OnTable = "ChangeExecutiveStatus";
        //    ds = dl.FetchMarketingExecutive_sp(a);
        //    return Json(1, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult StateName(string id)
        {
            List<State> StateList = new List<State>();
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "FetchStateList";
            ds = dl.FetchMarketingExecutive_sp(a);

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                State m = new State();
                m.StateId = item["StateId"].ToString();
                m.StateName = item["StateName"].ToString();
                m.IsActive = item["IsActive"].ToString();
                StateList.Add(m);
            }
            return Json(StateList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CityName(string id)
        {
            List<City> CityList = new List<City>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.Condition1 = id;
            p.OnTable = "FetchCity";
            ds = dl.FetchMarketingExecutive_sp(p);

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                City m = new City();
                m.CityId = item["CityId"].ToString();
                m.CityName = item["CityName"].ToString();
                CityList.Add(m);
            }
            return Json(CityList, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult DeleteExecutive(string id)
        //{
        //    Property a = new Property();
        //    DataSet ds = new DataSet();
        //    a.Condition1 = id;
        //    a.OnTable = "DeleteExecutive";
        //    ds = dl.FetchMarketingExecutive_sp(a);
        //    return Json(1, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult MyProfile(string id)
        {
            List<AdminLogin> AdminLogin = new List<AdminLogin>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchAdmin";

            p.Condition1 = id;

            ds = dl.FetchAdminLogin(p);

            List<SelectListItem> CountryList = new List<SelectListItem>();
            CountryList.Add(new SelectListItem { Text = "Select Country", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                CountryList.Add(new SelectListItem { Text = dr["CountryName"].ToString(), Value = dr["CountryId"].ToString() });
            }
            ViewBag.CountryList = new SelectList(CountryList, "Value", "Text");

            AdminLogin info = new RXGOADMIN.Models.AdminLogin();

            try
            {
                info = new RXGOADMIN.Models.AdminLogin()
                {
                    HospitalId = ds.Tables[0].Rows[0]["HospitalId"].ToString(),
                    Email = enc.Decrypt(ds.Tables[0].Rows[0]["Email"].ToString()),
                    Password = enc.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString()),
                    Address = ds.Tables[0].Rows[0]["Address"].ToString(),
                    Phone = ds.Tables[0].Rows[0]["Phone"].ToString(),
                    HospitalName = ds.Tables[0].Rows[0]["HospitalName"].ToString(),
                    HospitalWebsiteUrl = ds.Tables[0].Rows[0]["HospitalWebsiteUrl"].ToString(),
                    CountryId = ds.Tables[0].Rows[0]["CountryId"].ToString(),
                    CountryName = ds.Tables[0].Rows[0]["CountryName"].ToString(),
                    StateId = ds.Tables[0].Rows[0]["StateId"].ToString(),
                    StateName = ds.Tables[0].Rows[0]["StateName"].ToString(),
                    CityId = ds.Tables[0].Rows[0]["CityId"].ToString(),
                    CityName = ds.Tables[0].Rows[0]["CityName"].ToString()
                };
            }
            catch (Exception ex)
            {

            }

            return View(info);
        }
        [HttpPost]
        public ActionResult MyProfile(AdminLogin login, string id)
        {
            login.Email = enc.Encrypt(login.Email);
            login.Password = enc.Encrypt(login.Password);

            try
            {
                if (dl.InsertHospital_Sp(login) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Admin/MyProfile/" + id);
            }
            //TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/Admin/MyProfile/" + id);
        }
        //#region User Type List
        //public ActionResult UserList()
        //{
        //    HttpCookie rxgoadmin = Request.Cookies["rxgoAdmin"];
        //    string adminid = rxgoadmin.Values["Hid"];
        //    List<UserTypes> UserList = new List<UserTypes>();
        //    Property p = new Property();
        //    DataSet ds = new DataSet();
        //    p.OnTable = "UserList";

        //    if (adminid != null)
        //    {
        //        p.Condition1 = adminid;
        //    }

        //    ds = dl.FetchUserList(p);

        //    foreach (DataRow item in ds.Tables[0].Rows)
        //    {
        //        UserTypes m = new UserTypes();

        //        m.UserTypeId = item["UserTypeId"].ToString();
        //        m.UserType = item["UserType"].ToString();
        //        m.HospitalId = item["HospitalId"].ToString();
        //        m.IsActive = item["IsActive"].ToString();
        //        UserList.Add(m);
        //    }
        //    ViewBag.UserList = UserList;
        //    return View();
        //}
        //#endregion

        #region Admin
        public ActionResult Admin()
        {
            List<UserTypes> CategoryList = new List<UserTypes>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchUserList";

            ds = dl.FetchUserList_sp(p);

            List<SelectListItem> Categoryinventory = new List<SelectListItem>();
            Categoryinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Categoryinventory.Add(new SelectListItem { Text = dr["UserType"].ToString(), Value = dr["UserTypeId"].ToString() });
            }
            ViewBag.Categoryinventory = new SelectList(Categoryinventory, "Value", "Text");

            //try
            //{
            //    foreach (DataRow item in ds.Tables[0].Rows)
            //    {
            //        UserTypes m = new UserTypes();

            //        m.UserTypeId = item["UserTypeId"].ToString();
            //        m.UserType = item["UserType"].ToString();
            //        m.AddedBy = item["AddedBy"].ToString();
            //        m.IsActive = item["IsActive"].ToString();
            //        CategoryList.Add(m);
            //    }
            //    ViewBag.CategoryList = CategoryList;
            //}
            //catch (Exception e)
            //{

            //}
            return View();
        }

        #endregion


        #region AddStaff
        public ActionResult staff(EmployeeDetails emp)
        {
            List<EmployeeDetails> EmpList = new List<EmployeeDetails>();

            string id = emp.UserTypeId;

            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchEmployee";

            if (id != null)
            {
                p.Condition3 = id;
            }

            ds = dl.FetchEmployee_sp(p);

            List<SelectListItem> CategoryList = new List<SelectListItem>();
            CategoryList.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                CategoryList.Add(new SelectListItem { Text = dr["UserType"].ToString(), Value = dr["UserTypeId"].ToString() });
            }
            ViewBag.CategoryList = new SelectList(CategoryList, "Value", "Text");


            try
            {
                foreach (DataRow item in ds.Tables[2].Rows)
                {
                    EmployeeDetails m = new EmployeeDetails();

                    m.EmployeeId = item["EmployeeId"].ToString();
                    m.FullName = item["FullName"].ToString();
                    m.UserTypeId = item["UserTypeId"].ToString();
                    m.UserType = item["UserType"].ToString();
                    m.Phone = item["Phone"].ToString();
                    //m.ProfilePic = item["ProfilePic"].ToString();

                    EmpList.Add(m);
                }
                ViewBag.EmpList = EmpList;
            }
            catch (Exception e)
            {

            }
            return View();
        }


        #endregion


        #region ApplyLeave
        public ActionResult LeaveRequest()
        {
            return View();
        }

        #endregion

        [HttpPost]
        public ActionResult searchrole(EmployeeDetails emp)
        {
            List<EmployeeDetails> EmpList = new List<EmployeeDetails>();

            string id = emp.UserTypeId;
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchEmployee";
            if (id != null)
            {
                p.Condition3 = id;
            }
            ds = dl.FetchEmployee_sp(p);

            //List<SelectListItem> CategoryList = new List<SelectListItem>();
            //CategoryList.Add(new SelectListItem { Text = "Select", Value = "" });
            //foreach (DataRow dr in ds.Tables[1].Rows)
            //{
            //    CategoryList.Add(new SelectListItem { Text = dr["UserType"].ToString(), Value = dr["UserTypeId"].ToString() });
            //}
            //ViewBag.CategoryList = new SelectList(CategoryList, "Text", "Value");


            try
            {
                foreach (DataRow item in ds.Tables[2].Rows)
                {
                    EmployeeDetails m = new EmployeeDetails();

                    m.EmployeeId = item["EmployeeId"].ToString();
                    m.FullName = item["FullName"].ToString();
                    m.UserTypeId = item["UserTypeId"].ToString();
                    //m.UserType = item["UserType"].ToString();
                    m.Phone = item["Phone"].ToString();
                    //m.ProfilePic = item["ProfilePic"].ToString();
             
                    EmpList.Add(m);
                }
                ViewBag.EmpList = EmpList;
            }
            catch (Exception e)
            {

            }

            return Redirect("/Admin/staff");
        }


        public ActionResult Debda()
        {
            return View();
        }

    }
}