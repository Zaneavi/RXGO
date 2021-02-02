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
    public class RadiologyController : Controller
    {
        // GET: Radiology
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        public ActionResult Index()
        {
            return View();
        }


        #region Category
        public ActionResult Category()
        {
            List<RadiologyCategory> CategoryList = new List<RadiologyCategory>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchRadiologyCategory";

            ds = dl.FetchRadiologyCategory_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    RadiologyCategory m = new RadiologyCategory();

                    m.CategoryId = item["CategoryId"].ToString();
                    m.CategoryName = item["CategoryName"].ToString();
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
        public ActionResult Category(RadiologyCategory c)
        {
            try
            {
                if (dl.InsertRadiologyCategory_Sp(c) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Radiology/Category");
            }
            TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/Radiology/Category");
        }


        public JsonResult DeleteCategory(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteCategory";
            ds = dl.FetchRadiologyCategory_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RadiologyCategoryStatus(string id, string status)
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
            a.OnTable = "ChangeRadiologyStatus";
            ds = dl.FetchRadiologyCategory_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditCategory(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchRadiologyCategory";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchRadiologyCategory_sp(p);

            RadiologyCategory info = new RXGOADMIN.Models.RadiologyCategory();
            try
            {
                info = new RXGOADMIN.Models.RadiologyCategory()
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

        #region ChargeCategory

        public ActionResult ChargeCategory()
        {
            List<RadiologyChargeCategory> CategoryList = new List<RadiologyChargeCategory>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchChargeCategory";

            ds = dl.FetchChargeCategory_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    RadiologyChargeCategory m = new RadiologyChargeCategory();

                    m.ChargeCategoryId = item["ChargeCategoryId"].ToString();
                    m.ChargeCategoryName = item["ChargeCategoryName"].ToString();
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
        public ActionResult ChargeCategory(RadiologyChargeCategory c)
        {
            try
            {
                if (dl.InsertChargeCategory_Sp(c) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Radiology/ChargeCategory");
            }
            TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/Radiology/ChargeCategory");
        }
        public JsonResult DeleteChargeCategory(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteChargeCategory";
            ds = dl.FetchChargeCategory_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChargeCategoryStatus(string id, string status)
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
            ds = dl.FetchChargeCategory_sp(a);
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

            ds = dl.FetchChargeCategory_sp(p);

            RadiologyChargeCategory info = new RXGOADMIN.Models.RadiologyChargeCategory();
            try
            {
                info = new RXGOADMIN.Models.RadiologyChargeCategory()
                {
                    ChargeCategoryId = ds.Tables[0].Rows[0]["ChargeCategoryId"].ToString(),
                    ChargeCategoryName = ds.Tables[0].Rows[0]["ChargeCategoryName"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }
        #endregion

        #region Code
        public ActionResult Code()
        {
            List<CodeModel> CategoryList = new List<CodeModel>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchCode";

            ds = dl.FetchCode_sp(p);

            List<SelectListItem> Categoryinventory = new List<SelectListItem>();
            Categoryinventory.Add(new SelectListItem { Text = "Select Category", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Categoryinventory.Add(new SelectListItem { Text = dr["ChargeCategoryName"].ToString(), Value = dr["ChargeCategoryId"].ToString() });
            }
            ViewBag.Categoryinventory = new SelectList(Categoryinventory, "Value", "Text");

            
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    CodeModel m = new CodeModel();

                    m.CodeId = item["CodeId"].ToString();
                    m.Code = item["Code"].ToString();
                    m.StandardCharge = item["StandardCharge"].ToString();
                    m.ChargeCategoryId = item["ChargeCategoryId"].ToString();
                    m.ChargeCategoryName = item["ChargeCategoryName"].ToString();
                    m.HospitalId = item["HospitalId"].ToString();
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
        public ActionResult Code(CodeModel c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string hospitalid = rxgoAdminCookie.Values["Hid"];
            c.HospitalId = hospitalid;
            try
            {
                if (dl.InsertCode_Sp(c) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Radiology/Code");
            }
            TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/Radiology/Code");
        }


        public JsonResult DeleteCode(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteCode";
            ds = dl.FetchCode_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CodeStatus(string id, string status)
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
            a.OnTable = "ChangeCodeStatus";
            ds = dl.FetchCode_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditCode(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchCode";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchCode_sp(p);

            CodeModel info = new RXGOADMIN.Models.CodeModel();
            try
            {
                info = new RXGOADMIN.Models.CodeModel()
                {
                    CodeId = ds.Tables[1].Rows[0]["CodeId"].ToString(),
                    Code = ds.Tables[1].Rows[0]["Code"].ToString(),
                    StandardCharge = ds.Tables[1].Rows[0]["StandardCharge"].ToString()
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
            List<Parameter> CategoryList = new List<Parameter>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchParameter";

            ds = dl.FetchParameter_sp(p);


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
                    Parameter m = new Parameter();

                    m.ParameterId = item["ParameterId"].ToString();
                    m.ParameterName = item["ParameterName"].ToString();
                    m.ReferenceRange = item["ReferenceRange"].ToString();
                    m.Description = item["Description"].ToString();
                    m.UnitId = item["UnitId"].ToString();
                    m.UnitName = item["UnitName"].ToString();
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
        public ActionResult Parameter(Parameter c)
        {
            try
            {
                if (dl.InsertParameter_Sp(c) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Radiology/Parameter");
            }
            TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/Radiology/Parameter");
        }


        public JsonResult DeleteParameter(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteParameter";
            ds = dl.FetchParameter_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ParameterStatus(string id, string status)
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
            a.OnTable = "ChangeParameterStatus";
            ds = dl.FetchParameter_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditParameter(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchParameter";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchParameter_sp(p);

            List<SelectListItem> Categoryinventory = new List<SelectListItem>();
            Categoryinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Categoryinventory.Add(new SelectListItem { Text = dr["UnitName"].ToString(), Value = dr["UnitId"].ToString() });
            }
            ViewBag.Categoryinventory = new SelectList(Categoryinventory, "Value", "Text");


            Parameter info = new RXGOADMIN.Models.Parameter();
            try
            {
                info = new RXGOADMIN.Models.Parameter()
                {
                    ParameterId = ds.Tables[2].Rows[0]["ParameterId"].ToString(),
                    ParameterName = ds.Tables[2].Rows[0]["ParameterName"].ToString(),
                    ReferenceRange = ds.Tables[2].Rows[0]["ReferenceRange"].ToString(),
                    Description = ds.Tables[2].Rows[0]["Description"].ToString(),
                    UnitId = ds.Tables[2].Rows[0]["UnitId"].ToString(),
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }
        #endregion



        #region Unit
        public ActionResult Unit()
        {
            List<RadiologyUnit> CategoryList = new List<RadiologyUnit>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchUnit";

            ds = dl.FetchRadiologyUnit_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    RadiologyUnit m = new RadiologyUnit();

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
        public ActionResult Unit(RadiologyUnit c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertRadiologyUnit_Sp(c) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Radiology/Unit");
            }
            TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/Radiology/Unit");
        }


        public JsonResult DeleteUnit(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteUnit";
            ds = dl.FetchRadiologyUnit_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RadiologyUnitStatus(string id, string status)
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
            ds = dl.FetchRadiologyUnit_sp(a);
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

            ds = dl.FetchRadiologyUnit_sp(p);

            RadiologyUnit info = new RXGOADMIN.Models.RadiologyUnit();
            try
            {
                info = new RXGOADMIN.Models.RadiologyUnit()
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


        #region RadiologyTest

        public ActionResult RadiologyTest()
        {
            List<RadiologyTestReport> PathologyList = new List<RadiologyTestReport>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchRadiologyTest";

            ds = dl.FetchRadiologyReport_sp(p);


            List<SelectListItem> PatientList = new List<SelectListItem>();
            PatientList.Add(new SelectListItem { Text = "Select Patient", Value = "" });
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                PatientList.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["PatientId"].ToString() });
            }
            ViewBag.PatientList = new SelectList(PatientList, "Value", "Text");


            List<SelectListItem> DoctorList = new List<SelectListItem>();
            DoctorList.Add(new SelectListItem { Text = "Select Doctor", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                DoctorList.Add(new SelectListItem { Text = dr["FullName"].ToString(), Value = dr["EmployeeId"].ToString() });
            }
            ViewBag.DoctorList = new SelectList(DoctorList, "Value", "Text");

            return View();
        }


        [HttpPost]
        public ActionResult PatientTestReport(RadiologyTestReport p, List<HttpPostedFileBase> Attachment)
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
                if (dl.InsertRadiologyTestReport_Sp(p) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Radiology/RadiologyTest");
            }
            TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/Radiology/RadiologyTest");
        }



        #endregion



        #region TestReport

        public ActionResult TestReport()
        {
            List<RadiologyTestReport> CategoryList = new List<RadiologyTestReport>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchRadiologyTest";

            ds = dl.FetchRadiologyReport_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[2].Rows)
                {
                    RadiologyTestReport m = new RadiologyTestReport();

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
            ds = dl.FetchRadiologyReport_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}