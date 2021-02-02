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
    public class InPatientController : Controller
    {
        // GET: InPatient
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InPatient()
        {
            List<InPatient> CategoryList = new List<InPatient>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPatient";

            ds = dl.FetchInPatient_sp(p);

            //try
            //{
            //    foreach (DataRow item in ds.Tables[0].Rows)
            //    {
            //        InPatient m = new InPatient();

            //        m.PatientId = item["PatientId"].ToString();
            //        m.PatientName = item["PatientName"].ToString();
            //        m.Code = item["Code"].ToString();
            //        m.Phone = item["Phone"].ToString();
            //        m.Address = item["Address"].ToString();
            //        m.ContactPersonName = item["ContactPersonName"].ToString();
            //        m.ContactPersonPhone = item["ContactPersonPhone"].ToString();
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
        [HttpPost]
        public ActionResult InPatient(InPatient c)
        {
            try
            {
                if (dl.InsertInPatient_Sp(c) > 0)
                {
                    TempData["MSG"] = "Patient Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/InPatient/InPatient");
            }
            TempData["MSG"] = "Patient Added Successfully.";
            return Redirect("/InPatient/InPatient");
        }


        public JsonResult DeletePatient(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeletePatient";
            ds = dl.FetchInPatient_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PatientStatus(string id, string status)
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
            a.OnTable = "ChangePatientStatus";
            ds = dl.FetchInPatient_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

       public ActionResult Show()
        {
            return View();
        }
        public ActionResult DischargedPatient()
        {
            return View();
        }



        #region Consultant
        public ActionResult ConsultantRegister()
        {
            List<ConsultantRegister> CategoryList = new List<ConsultantRegister>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchConsultantRegister";

            ds = dl.FetchInPatientConsultant_sp(p);

            List<SelectListItem> Categoryinventory = new List<SelectListItem>();
            Categoryinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Categoryinventory.Add(new SelectListItem { Text = dr["FullName"].ToString(), Value = dr["EmployeeId"].ToString() });
            }
            ViewBag.Categoryinventory = new SelectList(Categoryinventory, "Value", "Text");


            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    ConsultantRegister m = new ConsultantRegister();

                    m.CId = item["CId"].ToString();
                    m.UserId = item["UserId"].ToString();
                    m.AppDate = item["AppDate"].ToString();
                    m.EmployeeId = item["EmployeeId"].ToString();
                    m.FullName = item["FullName"].ToString();
                    m.Instruction = item["Instruction"].ToString();
                    m.InstructionDate = item["InstructionDate"].ToString();
                    m.AddedBy = item["AddedBy"].ToString();
                    //m.IsActive = item["IsActive"].ToString();
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
        public ActionResult ConsultantRegister(ConsultantRegister c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertInPatientConsultant_Sp(c) > 0)
                {
                    TempData["MSG"] = "Consultant Register Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/InPatient/ConsultantRegister");
            }
            TempData["MSG"] = "Consultant Register Added Successfully.";
            return Redirect("/InPatient/ConsultantRegister");
        }
        public JsonResult DeleteConsultantRegister(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteConsultantRegister";
            ds = dl.FetchInPatientConsultant_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region Diagnosis
        public ActionResult Diagnosis()
        {
            List<Diagnosis> CategoryList = new List<Diagnosis>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchDiagnosis";

            ds = dl.FetchDiagnosis_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Diagnosis m = new Diagnosis();

                    m.DId = item["DId"].ToString();
                    m.PatientId = item["PatientId"].ToString();
                    m.IPDId = item["IPDId"].ToString();
                    m.ReportType = item["ReportType"].ToString();
                    m.ReportDate = item["ReportDate"].ToString();
                    m.Attachment = item["Attachment"].ToString();
                    m.Description = item["Description"].ToString();
                    //m.AddedBy = item["AddedBy"].ToString();
                    //m.IsActive = item["IsActive"].ToString();
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
        public ActionResult Diagnosis(Diagnosis c, List<HttpPostedFileBase> Attachment)
        {
           
            //string no = "BR" + System.DateTime.Now.Year + 1;
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
                                c.Attachment = c.Attachment;
                            }
                            else
                            {
                                c.Attachment = fileLocation;
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
                if (dl.InsertDiagnosis_Sp(c) > 0)
                {
                    TempData["MSG"] = "Diagnosis Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/InPatient/Diagnosis");
            }
            TempData["MSG"] = "Diagnosis Added Successfully.";
            return Redirect("/InPatient/Diagnosis");
        }
        public JsonResult DeleteDiagnosis(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteDiagnosis";
            ds = dl.FetchDiagnosis_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Timeline
        public ActionResult Timeline()
        {
            List<Timeline> CategoryList = new List<Timeline>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchTimeline";

            ds = dl.FetchTimeline_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Timeline m = new Timeline();

                    m.TId = item["TId"].ToString();
                    m.PatientId = item["PatientId"].ToString();
                    m.IPDId = item["IPDId"].ToString();
                    m.Title = item["Title"].ToString();
                    m.Date = item["Date"].ToString();
                    m.Description = item["Description"].ToString();
                    m.Attachment = item["Attachment"].ToString();
                    m.Visibility = item["Visibility"].ToString();
                    //m.AddedBy = item["AddedBy"].ToString();
                    //m.IsActive = item["IsActive"].ToString();
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
        public ActionResult Timeline(Timeline c, List<HttpPostedFileBase> Attachment)
        {
            
            //string no = "BR" + System.DateTime.Now.Year + 1;
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
                                c.Attachment = c.Attachment;
                            }
                            else
                            {
                                c.Attachment = fileLocation;
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
                if (dl.InsertTimeline_Sp(c) > 0)
                {
                    TempData["MSG"] = "Timeline Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/InPatient/Timeline");
            }
            TempData["MSG"] = "Timeline Added Successfully.";
            return Redirect("/InPatient/Timeline");
        }
        public JsonResult DeleteTimeline(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteTimeline";
            ds = dl.FetchTimeline_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Prescription
        public ActionResult Prescription()
        {
            List<Prescription> CategoryList = new List<Prescription>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPrescription";

            ds = dl.FetchPrescription_sp(p);


            List<SelectListItem> Categoryinventory = new List<SelectListItem>();
            Categoryinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Categoryinventory.Add(new SelectListItem { Text = dr["CategoryName"].ToString(), Value = dr["CategoryId"].ToString() });
            }
            ViewBag.Categoryinventory = new SelectList(Categoryinventory, "Value", "Text");

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Prescription m = new Prescription();

                    m.PId = item["PId"].ToString();
                    m.PatientId = item["PatientId"].ToString();
                    m.IPDId = item["IPDId"].ToString();
                    m.CategoryId = item["CategoryId"].ToString();
                    m.CategoryName = item["CategoryName"].ToString();
                    m.Header = item["Header"].ToString();
                    m.Footer = item["Footer"].ToString();
                    m.Medicine = item["Medicine"].ToString();
                    m.Dosage = item["Dosage"].ToString();
                    m.Instruction = item["Instruction"].ToString();
                    m.PrescriptionNo = item["PrescriptionNo"].ToString();
                    m.Date = item["Date"].ToString();
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
        public ActionResult Prescription(Prescription c)
        {
            try
            {
                if (dl.InsertPrescription_Sp(c) > 0)
                {
                    TempData["MSG"] = "Prescription Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/InPatient/Prescription");
            }
            TempData["MSG"] = "Prescription Added Successfully.";
            return Redirect("/InPatient/Prescription");
        }




        #endregion

    }
}