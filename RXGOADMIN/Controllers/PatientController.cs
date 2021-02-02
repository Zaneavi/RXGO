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
    public class PatientController : Controller
    {
        // GET: Patient
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OPDPatient()
        {
            List<OPDPatient> PatientList = new List<OPDPatient>();

            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchOtpPatient";

            ds = dl.FetchOtpPatient_sp(p);

            List<SelectListItem> DoctorList = new List<SelectListItem>();
            DoctorList.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                DoctorList.Add(new SelectListItem { Text = dr["FullName"].ToString(), Value = dr["FullName"].ToString() });
            }
            ViewBag.DoctorList = new SelectList(DoctorList, "Value", "Text");

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                OPDPatient m = new OPDPatient();

                m.PatientId = item["PatientId"].ToString();
                m.Name = item["Name"].ToString();
                m.GuardianName = item["GuardianName"].ToString();
                m.Phone = item["Phone"].ToString();
                m.Gender = item["Gender"].ToString();
                m.ConsultantDoctor = item["ConsultantDoctor"].ToString();
                PatientList.Add(m);
            }
            ViewBag.PatientList = PatientList;

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult OPDPatient(OPDPatient p)
        {
            try
            {
                p.PatientPhoto = Session["PatientPhoto"].ToString();

                if (dl.InsertOtpPatient_Sp(p) > 0)
                {
                    TempData["MSG"] = "Patient Added Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Json(new { data = "error" }, JsonRequestBehavior.AllowGet);
            }
            int response = 1;
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddPatientPhoto(OPDPatient patient)
        {
            var profile = Request.Files;

            string imgname = string.Empty;
            string ImageName = string.Empty;

            //Following code will check that image is there 
            //If it will Upload or else it will use Default Image

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var logo = System.Web.HttpContext.Current.Request.Files["file"];
                if (logo.ContentLength > 0)
                {
                    var profileName = Path.GetFileName(logo.FileName);
                    var ext = Path.GetExtension(logo.FileName);

                    ImageName = profileName;
                    var comPath = Server.MapPath("/DataImages/") + ImageName;

                    logo.SaveAs(comPath);
                    patient.PatientPhoto = comPath;
                    Session["PatientPhoto"] = "~/DataImages/" + profileName;
                }

            }
            else
                patient.PatientPhoto = Server.MapPath("/DataImages/") + "patientphoto.jpg";

            int response = 1;
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public ActionResult IPDPatient()
        {
            List<IPDPatient> PatientList = new List<IPDPatient>();

            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchIpdPatient";

            ds = dl.FetchIpdPatient_sp(p);

            List<SelectListItem> DoctorList = new List<SelectListItem>();
            DoctorList.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                DoctorList.Add(new SelectListItem { Text = dr["FullName"].ToString(), Value = dr["FullName"].ToString() });
            }
            ViewBag.DoctorList = new SelectList(DoctorList, "Value", "Text");

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                IPDPatient m = new IPDPatient();

                m.IPDNo = item["IPDNo"].ToString();
                //m.PatientId = item["PatientId"].ToString();
                m.Name = item["Name"].ToString();
                m.GuardianName = item["GuardianName"].ToString();
                m.Phone = item["Phone"].ToString();
                m.Gender = item["Gender"].ToString();
                m.ConsultantDoctor = item["ConsultantDoctor"].ToString();
                PatientList.Add(m);
            }
            ViewBag.PatientList = PatientList;

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult IPDPatient(IPDPatient p)
        {
            try
            {
                p.PatientPhoto = Session["PatientPhoto"].ToString();

                if (dl.InsertIpdPatient_Sp(p) > 0)
                {
                    TempData["MSG"] = "Patient Added Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Json(new { data = "error" }, JsonRequestBehavior.AllowGet);
            }
            int response = 1;
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddIPDPatientPhoto(IPDPatient patient)
        {
            var profile = Request.Files;

            string imgname = string.Empty;
            string ImageName = string.Empty;

            //Following code will check that image is there 
            //If it will Upload or else it will use Default Image

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var logo = System.Web.HttpContext.Current.Request.Files["file"];
                if (logo.ContentLength > 0)
                {
                    var profileName = Path.GetFileName(logo.FileName);
                    var ext = Path.GetExtension(logo.FileName);

                    ImageName = profileName;
                    var comPath = Server.MapPath("/DataImages/") + ImageName;

                    logo.SaveAs(comPath);
                    patient.PatientPhoto = comPath;
                    Session["PatientPhoto"] = "~/DataImages/" + profileName;
                }

            }
            else
                patient.PatientPhoto = Server.MapPath("/DataImages/") + "patientphoto.jpg";

            int response = 1;
            return Json(response, JsonRequestBehavior.AllowGet);
        }


        public ActionResult profile(string id)
        {
            List<OPDPatient> OPDPatientList = new List<OPDPatient>();
            List<Diagnosis> DiagnosisList = new List<Diagnosis>();
            List<Timeline> TimelineList = new List<Timeline>();

            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "PatientDetails";
            p.Condition1 = id;

            ds = dl.FetchOpdPatient_sp(p);

            OPDPatient info = new RXGOADMIN.Models.OPDPatient();

            try
            {
                info = new RXGOADMIN.Models.OPDPatient()
                {
                    OPDId = ds.Tables[0].Rows[0]["OPDId"].ToString(),
                    PatientId = ds.Tables[0].Rows[0]["PatientId"].ToString(),
                    PatientUniqueId = ds.Tables[0].Rows[0]["PatientUniqueId"].ToString(),
                    Gender = ds.Tables[0].Rows[0]["Gender"].ToString(),
                    MaritalStatus = ds.Tables[0].Rows[0]["MaritalStatus"].ToString(),
                    Phone = ds.Tables[0].Rows[0]["Phone"].ToString(),
                    Email = ds.Tables[0].Rows[0]["Email"].ToString(),
                    Address = ds.Tables[0].Rows[0]["Address"].ToString(),
                    //Age= ds.Tables[0].Rows[0]["Age"].ToString(),
                    Year = ds.Tables[0].Rows[0]["Year"].ToString(),
                    Month = ds.Tables[0].Rows[0]["Month"].ToString(),
                    GuardianName = ds.Tables[0].Rows[0]["GuardianName"].ToString(),
                    Name = ds.Tables[0].Rows[0]["Name"].ToString(),
                    PatientPhoto = ds.Tables[0].Rows[0]["PatientPhoto"].ToString(),
                };
            }
            catch (Exception ex)
            {

            }

            foreach (DataRow item in ds.Tables[1].Rows)
            {
                OPDPatient m = new OPDPatient();

                m.OPDId = item["OPDId"].ToString();
                m.OPDNo = item["OPDNo"].ToString();
                m.AppointmentDate = item["AppointmentDate"].ToString();
                m.ConsultantDoctor = item["ConsultantDoctor"].ToString();
                m.Reference = item["Reference"].ToString();
                m.Symptoms = item["Symptoms"].ToString();
                m.SymptomsTitle = item["SymptomsTitle"].ToString();
                OPDPatientList.Add(m);
            }
            ViewBag.OPDPatientList = OPDPatientList;

            foreach (DataRow item in ds.Tables[2].Rows)
            {
                Diagnosis dis = new Diagnosis();

                dis.DId = item["DiagnosisId"].ToString();
                dis.ReportDate = item["ReportDate"].ToString();
                dis.ReportType = item["ReportType"].ToString();
                dis.Description = item["Description"].ToString();
                dis.Attachment = item["Attachment"].ToString();
                DiagnosisList.Add(dis);
            }
            ViewBag.DiagnosisList = DiagnosisList;

            foreach (DataRow item in ds.Tables[3].Rows)
            {
                Timeline t = new Timeline();

                t.TId = item["TId"].ToString();
                t.Date = item["Date"].ToString();
                t.Title = item["Title"].ToString();
                t.Description = item["Description"].ToString();
                t.Attachment = item["Attachment"].ToString();
                TimelineList.Add(t);
            }
            ViewBag.TimelineList = TimelineList;

            List<SelectListItem> DoctorList = new List<SelectListItem>();
            DoctorList.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[4].Rows)
            {
                DoctorList.Add(new SelectListItem { Text = dr["FullName"].ToString(), Value = dr["EmployeeId"].ToString() });
            }
            ViewBag.DoctorList = new SelectList(DoctorList, "Value", "Text");

            List<SelectListItem> SymptomsType = new List<SelectListItem>();
            SymptomsType.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[5].Rows)
            {
                SymptomsType.Add(new SelectListItem { Text = dr["SymptomsType"].ToString(), Value = dr["SymptomsTypeId"].ToString() });
            }
            ViewBag.SymptomsType = new SelectList(SymptomsType, "Value", "Text");

            List<SelectListItem> TPA = new List<SelectListItem>();
            TPA.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[6].Rows)
            {
                TPA.Add(new SelectListItem { Text = dr["TPAName"].ToString(), Value = dr["TPAId"].ToString() });
            }
            ViewBag.TPA = new SelectList(TPA, "Value", "Text");

            return View(info);
        }

        
        public ActionResult OPDCharges()
        {
            List<OPDCharge> CategoryList = new List<OPDCharge>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchOPDCharge";
            p.Condition1 = "1";

            ds = dl.FetchOPDCharge_sp(p);

            List<SelectListItem> ChargeTypeinventory = new List<SelectListItem>();
            ChargeTypeinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                ChargeTypeinventory.Add(new SelectListItem { Text = dr["Type"].ToString(), Value = dr["ChargeTypeId"].ToString() });
            }
            ViewBag.ChargeTypeinventory = new SelectList(ChargeTypeinventory, "Value", "Text");

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    OPDCharge m = new OPDCharge();

                    m.OPDChargeId = item["OPDChargeId"].ToString();
                    m.OPDId = item["OPDId"].ToString();
                    m.PatientId = item["PatientId"].ToString();
                    m.Date = item["Date"].ToString();
                    m.Type = item["Type"].ToString();
                    m.Name = item["Name"].ToString();
                    m.StandardCharge = item["StandardCharge"].ToString();
                    m.AppliedCharge = item["AppliedCharge"].ToString();
                    CategoryList.Add(m);
                }
                ViewBag.CategoryList = CategoryList;
            }
            catch (Exception ex)
            {

            }

            
            OPDCharge info = new RXGOADMIN.Models.OPDCharge();

            try
            {
                info = new RXGOADMIN.Models.OPDCharge()
                {
                    
                    AppliedCharge = ds.Tables[4].Rows[0]["AppliedCharge"].ToString(),
                   
                };
            }
            catch (Exception ex)
            {

            }

         
            OPDPayment info1 = new RXGOADMIN.Models.OPDPayment();

            try

            {
                info1 = new RXGOADMIN.Models.OPDPayment()
                {

                    Amount = ds.Tables[5].Rows[0]["Amount"].ToString(),

                };
                ViewBag.PaymentInfo = info1;
            }
            catch (Exception ex)
            {

            }

            

            List<OPDPayment> PaymentList = new List<OPDPayment>();
            p.OnTable = "FetchOPDPayment";
            ds = dl.FetchOPDPayment_sp(p);
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    OPDPayment m = new OPDPayment();

                    m.PaymentId = item["PaymentId"].ToString();
                    m.OPDId = item["OPDId"].ToString();
                    m.PatientId = item["PatientId"].ToString();
                    m.Date = item["Date"].ToString();
                    m.Note = item["Note"].ToString();
                    m.PaymentMode = item["PaymentMode"].ToString();
                    m.Amount = item["Amount"].ToString();
                    m.Attachment = item["Attachment"].ToString();
                    PaymentList.Add(m);
                }
                ViewBag.PaymentList = PaymentList;
            }
            catch (Exception ex)
            {

            }

            List<OPDDiagnosis> DiagnosisList = new List<OPDDiagnosis>();
            p.OnTable = "FetchOPDDiagnosis";
            ds = dl.FetchOPDDiagnosis_sp(p);
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    OPDDiagnosis m = new OPDDiagnosis();

                    m.DiagnosisId = item["DiagnosisId"].ToString();
                    m.OPDId = item["OPDId"].ToString();
                    m.PatientId = item["PatientId"].ToString();
                    m.ReportType = item["ReportType"].ToString();
                    m.ReportDate = item["ReportDate"].ToString();
                    m.Description = item["Description"].ToString();
                    m.Attachment = item["Attachment"].ToString();
                    DiagnosisList.Add(m);
                }
                ViewBag.DiagnosisList = DiagnosisList;
            }
            catch (Exception ex)
            {

            }


            return View(info);
        }


        [HttpPost]
        public ActionResult OPDCharges(OPDCharge c)
        {
            try
            {
                if (dl.InsertOPDCharge_Sp(c) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Patient/OPDCharges");
            }
            TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/Patient/OPDCharges");
        }

        public JsonResult DeleteCharge(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteOPDCharge";
            ds = dl.FetchOPDCharge_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChargeCategory(string id)
        {
            List<ChargeCategory> ChargeCategoryList = new List<ChargeCategory>();
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "FetchChargeCategory";
            ds = dl.FetchOPDCharge_sp(a);

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ChargeCategory m = new ChargeCategory();
                m.ChargeCategoryId = item["ChargeCategoryId"].ToString();
                m.Name = item["Name"].ToString();
                ChargeCategoryList.Add(m);
            }
            return Json(ChargeCategoryList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Charge(string id)
        {
            List<Charge> ChargeList = new List<Charge>();
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "FetchCharge";
            ds = dl.FetchOPDCharge_sp(a);

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Charge m = new Charge();
                m.ChargeId = item["ChargeId"].ToString();
                m.Code = item["Code"].ToString();
                m.StandardCharge = item["StandardCharge"].ToString();
                ChargeList.Add(m);
            }
            return Json(ChargeList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult StandardCharge(string id)
        {
            List<Charge> StandardChargeList = new List<Charge>();
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "FetchStandardCharge";
            ds = dl.FetchOPDCharge_sp(a);

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Charge m = new Charge();
                m.ChargeId = item["ChargeId"].ToString();
                m.StandardCharge = item["StandardCharge"].ToString();
                StandardChargeList.Add(m);
            }
            return Json(StandardChargeList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddPayment(OPDPayment c, List<HttpPostedFileBase> Attachment)
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
                if (dl.InsertOPDPayment_Sp(c) > 0)
                {
                    TempData["PaymentMSG"] = "Data Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["PaymentMSG"] = "Something went wrong.";
                return Redirect("/Patient/OPDCharges");
            }
            TempData["PaymentMSG"] = "Data Saved Successfully.";
            return Redirect("/Patient/OPDCharges");
        }
        public JsonResult DeletePayment(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeletePayment";
            ds = dl.FetchOPDPayment_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddDiagnosis(OPDDiagnosis c, List<HttpPostedFileBase> Attachment)
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
                if (dl.InsertOPDDiagnosis_Sp(c) > 0)
                {
                    TempData["PaymentMSG"] = "Data Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["DiagnosisMSG"] = "Something went wrong.";
                return Redirect("/Patient/OPDCharges");
            }
            TempData["DiagnosisMSG"] = "Data Saved Successfully.";
            return Redirect("/Patient/OPDCharges");
        }

        public JsonResult DeleteDiagnosis(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteDiagnosis";
            ds = dl.FetchOPDDiagnosis_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
    }
}