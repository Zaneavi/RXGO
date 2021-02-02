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
    public class PathologyController : Controller
    {
        // GET: Pathology
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        public ActionResult Index()
        {
            return View();
        }

        #region Category
        public ActionResult Category()
        {
            List<Category> CategoryList = new List<Category>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPathologyCategory";

            ds = dl.FetchPathologyCategory_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Category m = new Category();

                    m.CategoryId = item["CategoryId"].ToString();
                    m.CategoryName = item["CategoryName"].ToString();
                    m.HospitalId = item["HospitalId"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    CategoryList.Add(m);
                }
                ViewBag.CategoryList = CategoryList;
            }
            catch(Exception e)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult Category(Category c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string hospitalid = rxgoAdminCookie.Values["Hid"];
            c.HospitalId = hospitalid;
            try
            {
                if (dl.InsertPathologyCategory_Sp(c) > 0)
                {
                    TempData["MSG"] = "Category Added Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Pathology/Category");
            }
            TempData["MSG"] = "Category Added Successfully.";
            return Redirect("/Pathology/Category");
        }
        public JsonResult DeleteCategory(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteCategory";
            ds = dl.FetchPathologyCategory_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PathologyCategoryStatus(string id, string status)
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
            a.OnTable = "ChangePathologyStatus";
            ds = dl.FetchPathologyCategory_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditCategory(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPathologyCategory";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchPathologyCategory_sp(p);

            Category info = new RXGOADMIN.Models.Category();
            try
            {
                info = new RXGOADMIN.Models.Category()
                {
                    CategoryId = ds.Tables[1].Rows[0]["CategoryId"].ToString(),
                    CategoryName = ds.Tables[1].Rows[0]["CategoryName"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }
        #endregion


        #region SubCategory
        public ActionResult SubCategory()
        {
            List<SubCategory> SubCategoryList = new List<SubCategory>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPathologySubCategory";

            ds = dl.FetchPathologySubCategory_sp(p);

            List<SelectListItem> CategoryList = new List<SelectListItem>();
            CategoryList.Add(new SelectListItem { Text = "Select Category", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                CategoryList.Add(new SelectListItem { Text = dr["CategoryName"].ToString(), Value = dr["CategoryId"].ToString() });
            }
            ViewBag.CategoryList = new SelectList(CategoryList, "Value", "Text");

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    SubCategory m = new SubCategory();

                    m.SubCategoryId = item["SubCategoryId"].ToString();
                    m.CategoryId = item["CategoryId"].ToString();
                    m.SubCategoryName = item["SubCategoryName"].ToString();
                    m.CategoryName = item["CategoryName"].ToString();
                    m.HospitalId = item["HospitalId"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    SubCategoryList.Add(m);
                }
                ViewBag.SubCategoryList = SubCategoryList;
            }
            catch (Exception e)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult SubCategory(SubCategory s)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string hospitalid = rxgoAdminCookie.Values["Hid"];
            s.HospitalId = hospitalid;
            try
            {
                if (dl.InsertPathologySubCategory_Sp(s) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Pathology/SubCategory");
            }
            TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/Pathology/SubCategory");
        }
        public JsonResult DeleteSubCategory(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteSubCategory";
            ds = dl.FetchPathologySubCategory_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PathologySubcategoryStatus(string id, string status)
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
            a.OnTable = "ChangePathologyStatus";
            ds = dl.FetchPathologySubCategory_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region PathologyTest
        public ActionResult PathologyTest()
        {
            List<Pathology> PathologyList = new List<Pathology>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPathologyTest";

            ds = dl.FetchPathologyTest_sp(p);

            List<SelectListItem> CategoryList = new List<SelectListItem>();
            CategoryList.Add(new SelectListItem { Text = "Select Category", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                CategoryList.Add(new SelectListItem { Text = dr["CategoryName"].ToString(), Value = dr["CategoryId"].ToString() });
            }
            ViewBag.CategoryList = new SelectList(CategoryList, "Value", "Text");


            List<SelectListItem> PatientList = new List<SelectListItem>();
            PatientList.Add(new SelectListItem { Text = "Select Patient", Value = "" });
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                PatientList.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["PatientId"].ToString() });
            }
            ViewBag.PatientList = new SelectList(PatientList, "Value", "Text");


            List<SelectListItem> DoctorList = new List<SelectListItem>();
            DoctorList.Add(new SelectListItem { Text = "Select Doctor", Value = "" });
            foreach (DataRow dr in ds.Tables[3].Rows)
            {
                DoctorList.Add(new SelectListItem { Text = dr["FullName"].ToString(), Value = dr["EmployeeId"].ToString() });
            }
            ViewBag.DoctorList = new SelectList(DoctorList, "Value", "Text");

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Pathology m = new Pathology();

                    m.PathologyId = item["PathologyId"].ToString();
                    m.TestName = item["TestName"].ToString();
                    m.ShortName = item["ShortName"].ToString();
                    m.TestType = item["TestType"].ToString();
                    m.SubCategoryId = item["SubCategoryId"].ToString();
                    m.CategoryId = item["CategoryId"].ToString();
                    m.CategoryName = item["CategoryName"].ToString();
                    m.SubCategoryName = item["SubCategoryName"].ToString();
                    m.Method = item["Method"].ToString();
                    m.ReportDays = item["ReportDays"].ToString();
                    m.Charge = item["Charge"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    PathologyList.Add(m);
                }
                ViewBag.PathologyList = PathologyList;
            }
            catch (Exception e)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult PathologyTest(Pathology p)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string addedid = rxgoAdminCookie.Values["Hid"];
            p.AddedBy = addedid;
            try
            {
                if (dl.InsertPathologyTest_Sp(p) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Pathology/PathologyTest");
            }
            TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/Pathology/PathologyTest");
        }



        [HttpPost]
        public ActionResult PatientTestReport(PathologyTestReport p, List<HttpPostedFileBase> Attachment)
        {
            string fileLocation = "";
            string ItemUploadFolderPath = "~/DataImages/";

            try
            {
                try
                {
                    if (Attachment.Count > 0)
                    {
                        foreach (HttpPostedFileBase file in Attachment)
                        {
                            try
                            {
                                if (file.ContentLength == 0)
                                    continue;

                                if (file.ContentLength > 0)
                                {
                                    fileLocation = HelperFunctions.renameUploadFile(file, ItemUploadFolderPath);
                                    if (fileLocation == "")
                                    {
                                        fileLocation = "";
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }

                            if (fileLocation == "" || fileLocation == null)
                            {
                                p.Attachment = p.Attachment;
                            }
                            else
                            {
                                p.Attachment = fileLocation;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            {
            }





            try
            {
                if (dl.InsertPathologyTestReport_Sp(p) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Pathology/PathologyTest");
            }
            TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/Pathology/PathologyTest");
        }




        public JsonResult DeletePathology(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeletePathology";
            ds = dl.FetchPathologyTest_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SubCategory1(string id)
        {
            List<SubCategory> SubCategoryList = new List<SubCategory>();
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "FetchSubCategory";
            ds = dl.FetchPathologyTest_sp(a);

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                SubCategory m = new SubCategory();
                m.SubCategoryId = item["SubCategoryId"].ToString();
                m.SubCategoryName = item["SubCategoryName"].ToString();
                SubCategoryList.Add(m);
            }
            return Json(SubCategoryList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PathologyTestStatus(string id, string status)
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
            a.OnTable = "ChangePathologyStatus";
            ds = dl.FetchPathologyTest_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        

        #endregion

        #region Unit

        public ActionResult Unit()
        {
            List<PathologyUnit> CategoryList = new List<PathologyUnit>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchUnit";

            ds = dl.FetchPathologyUnit_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    PathologyUnit m = new PathologyUnit();

                    m.UnitId = item["UnitId"].ToString();
                    m.UnitName = item["UnitName"].ToString();
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
        public ActionResult Unit(PathologyUnit c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertPathologyUnit_Sp(c) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Pathology/Unit");
            }
            TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/Pathology/Unit");
        }
        public JsonResult DeleteUnit(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteUnit";
            ds = dl.FetchPathologyUnit_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PathologyUnitStatus(string id, string status)
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
            a.OnTable = "ChangeUnitStatus";
            ds = dl.FetchPathologyUnit_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditUnit(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchUnit";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchPathologyUnit_sp(p);

            PathologyUnit info = new RXGOADMIN.Models.PathologyUnit();
            try
            {
                info = new RXGOADMIN.Models.PathologyUnit()
                {
                    UnitId = ds.Tables[1].Rows[0]["UnitId"].ToString(),
                    UnitName = ds.Tables[1].Rows[0]["UnitName"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }

        #endregion

        #region Parameter

        public ActionResult Parameter()
        {
            List<PathologyParameter> CategoryList = new List<PathologyParameter>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPathologyParameter";

            ds = dl.FetchPathologyParameter_sp(p);

            List<SelectListItem> Categoryinventory = new List<SelectListItem>();
            Categoryinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Categoryinventory.Add(new SelectListItem { Text = dr["UnitName"].ToString(), Value = dr["UnitId"].ToString() });
            }
            ViewBag.Categoryinventory = new SelectList(Categoryinventory, "Value", "Text");


            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    PathologyParameter m = new PathologyParameter();

                    m.PId = item["PId"].ToString();
                    m.PName = item["PName"].ToString();
                    m.RefRange = item["RefRange"].ToString();
                    m.Description = item["Description"].ToString();
                    m.UnitId = item["UnitId"].ToString();
                    m.UnitName = item["UnitName"].ToString();
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
        public ActionResult Parameter(PathologyParameter c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertPathologyParameter_Sp(c) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Bed/PathologyParameter");
            }
            TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/Bed/PathologyParameter");
        }


        public JsonResult DeletePathologyParameter(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeletePathologyParameter";
            ds = dl.FetchPathologyParameter_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PathologyParameterStatus(string id, string status)
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
            a.OnTable = "ChangePathologyParameterStatus";
            ds = dl.FetchPathologyParameter_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditParameter(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPathologyParameter";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchPathologyParameter_sp(p);


            List<SelectListItem> Categoryinventory = new List<SelectListItem>();
            Categoryinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Categoryinventory.Add(new SelectListItem { Text = dr["UnitName"].ToString(), Value = dr["UnitId"].ToString() });
            }
            ViewBag.Categoryinventory = new SelectList(Categoryinventory, "Value", "Text");



            PathologyParameter info = new RXGOADMIN.Models.PathologyParameter();
            try
            {
                info = new RXGOADMIN.Models.PathologyParameter()
                {
                    PId = ds.Tables[2].Rows[0]["PId"].ToString(),
                    PName = ds.Tables[2].Rows[0]["PName"].ToString(),
                    RefRange = ds.Tables[2].Rows[0]["RefRange"].ToString(),
                    Description = ds.Tables[2].Rows[0]["Description"].ToString(),
                    UnitId = ds.Tables[2].Rows[0]["UnitId"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }

        #endregion

        #region testreports
        public ActionResult TestReport()
        {
            List<PathologyTestReport> CategoryList = new List<PathologyTestReport>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPathologyReport";

            ds = dl.FetchPathologyReport_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    PathologyTestReport m = new PathologyTestReport();

                    m.BillId = item["BillId"].ToString();
                    m.PatientId = item["PatientId"].ToString();
                    m.Name = item["Name"].ToString();
                    m.EmployeeId = item["EmployeeId"].ToString();
                    m.FullName = item["FullName"].ToString();
                    m.ReportingDate = item["ReportingDate"].ToString();
                    m.Description = item["Description"].ToString();
                    m.Attachment = item["Attachment"].ToString();
                    m.AppliedCharge = item["AppliedCharge"].ToString();
                    CategoryList.Add(m);
                }
                ViewBag.CategoryList = CategoryList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }


        public JsonResult DeleteTestReport(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteTestReport";
            ds = dl.FetchPathologyReport_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        #endregion



    }
}