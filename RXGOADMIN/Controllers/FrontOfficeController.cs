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
    public class FrontOfficeController : Controller
    {
        // GET: Finance
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        public ActionResult Index()
        {
            return View();
        }


        #region Purpose
        public ActionResult Purpose()
        {
            List<Purpose> CategoryList = new List<Purpose>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPurpose";

            ds = dl.FetchPurpose_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Purpose m = new Purpose();

                    m.PId = item["PId"].ToString();
                    m.PName = item["PName"].ToString();
                    m.AddedBy = item["AddedBy"].ToString();
                    m.Description = item["Description"].ToString();
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
        public ActionResult Purpose(Purpose c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertPurpose_Sp(c) > 0)
                {
                    TempData["MSG"] = "Purpose Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/FrontOffice/Purpose");
            }
            TempData["MSG"] = "Purpose Added Successfully.";
            return Redirect("/FrontOffice/Purpose");
        }


        public JsonResult DeletePurpose(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeletePurpose";
            ds = dl.FetchPurpose_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PurposeStatus(string id, string status)
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
            a.OnTable = "ChangePurposeStatus";
            ds = dl.FetchPurpose_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditPurpose(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPurpose";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchPurpose_sp(p);

            Purpose info = new RXGOADMIN.Models.Purpose();
            try
            {
                info = new RXGOADMIN.Models.Purpose()
                {
                    PId = ds.Tables[1].Rows[0]["PId"].ToString(),
                    PName = ds.Tables[1].Rows[0]["PName"].ToString(),
                    Description = ds.Tables[1].Rows[0]["Description"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }

        #endregion


        #region ComplainType
        public ActionResult ComplainType()
        {
            List<ComplainType> CategoryList = new List<ComplainType>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchComplainType";

            ds = dl.FetchComplainType_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    ComplainType m = new ComplainType();

                    m.CId = item["CId"].ToString();
                    m.CType = item["CType"].ToString();
                    m.AddedBy = item["AddedBy"].ToString();
                    m.Description = item["Description"].ToString();
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
        public ActionResult ComplainType(ComplainType c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertComplainType_Sp(c) > 0)
                {
                    TempData["MSG"] = "Compalin Type Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/FrontOffice/ComplainType");
            }
            TempData["MSG"] = "Compalin Type Added Successfully.";
            return Redirect("/FrontOffice/ComplainType");
        }


        public JsonResult DeleteComplainType(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteComplainType";
            ds = dl.FetchComplainType_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ComplainTypeStatus(string id, string status)
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
            a.OnTable = "ChangeComplainTypeStatus";
            ds = dl.FetchComplainType_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditComplainType(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchComplainType";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchComplainType_sp(p);

            ComplainType info = new RXGOADMIN.Models.ComplainType();
            try
            {
                info = new RXGOADMIN.Models.ComplainType()
                {
                    CId = ds.Tables[1].Rows[0]["CId"].ToString(),
                    CType = ds.Tables[1].Rows[0]["CType"].ToString(),
                    Description = ds.Tables[1].Rows[0]["Description"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }

        #endregion

        #region Source
        public ActionResult Source()
        {
            List<Source> CategoryList = new List<Source>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchSource";

            ds = dl.FetchFrontSource_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Source m = new Source();

                    m.SId = item["SId"].ToString();
                    m.SName = item["SName"].ToString();
                    m.AddedBy = item["AddedBy"].ToString();
                    m.Description = item["Description"].ToString();
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
        public ActionResult Source(Source c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertFrontSource_Sp(c) > 0)
                {
                    TempData["MSG"] = "Source Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/FrontOffice/Source");
            }
            TempData["MSG"] = "Source Added Successfully.";
            return Redirect("/FrontOffice/Source");
        }


        public JsonResult DeleteSource(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteSource";
            ds = dl.FetchFrontSource_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SourceStatus(string id, string status)
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
            a.OnTable = "ChangeSourceStatus";
            ds = dl.FetchFrontSource_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditSource(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchSource";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchFrontSource_sp(p);

            Source info = new RXGOADMIN.Models.Source();
            try
            {
                info = new RXGOADMIN.Models.Source()
                {
                    SId = ds.Tables[1].Rows[0]["SId"].ToString(),
                    SName = ds.Tables[1].Rows[0]["SName"].ToString(),
                    Description = ds.Tables[1].Rows[0]["Description"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }

        #endregion

        #region AptPriority
        public ActionResult AptPriority()
        {
            List<AptPriority> CategoryList = new List<AptPriority>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchAptPriority";

            ds = dl.FetchFrontAptPriority_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    AptPriority m = new AptPriority();

                    m.PriorityId = item["PriorityId"].ToString();
                    m.Priority = item["Priority"].ToString();
                    m.AddedBy = item["AddedBy"].ToString();
                    m.Description = item["Description"].ToString();
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
        public ActionResult AptPriority(AptPriority c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertFrontAptPriority_Sp(c) > 0)
                {
                    TempData["MSG"] = "Priority Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/FrontOffice/AptPriority");
            }
            TempData["MSG"] = "Priority Added Successfully.";
            return Redirect("/FrontOffice/AptPriority");
        }


        public JsonResult DeleteAptPriority(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteAptPriority";
            ds = dl.FetchFrontAptPriority_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AptPriorityStatus(string id, string status)
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
            a.OnTable = "ChangeAptPriorityStatus";
            ds = dl.FetchFrontAptPriority_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditAptPriority(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchAptPriority";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchFrontAptPriority_sp(p);

            AptPriority info = new RXGOADMIN.Models.AptPriority();
            try
            {
                info = new RXGOADMIN.Models.AptPriority()
                {
                    PriorityId = ds.Tables[1].Rows[0]["PriorityId"].ToString(),
                    Priority = ds.Tables[1].Rows[0]["Priority"].ToString(),
                    Description = ds.Tables[1].Rows[0]["Description"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }

        #endregion

        
        #region Visitors
        public ActionResult Visitors()
        {
            List<Visitors> CategoryList = new List<Visitors>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchVisitors";

            ds = dl.FetchVisitors_sp(p);

            List<SelectListItem> Purposeinventory = new List<SelectListItem>();
            Purposeinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Purposeinventory.Add(new SelectListItem { Text = dr["PName"].ToString(), Value = dr["PId"].ToString() });
            }
            ViewBag.Purposeinventory = new SelectList(Purposeinventory, "Value", "Text");
            
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Visitors m = new Visitors();

                    m.VId = item["VId"].ToString();
                    m.VName = item["VName"].ToString();
                    m.Phone = item["Phone"].ToString();
                    m.Date = item["Date"].ToString();
                    m.IDCard = item["IDCard"].ToString();
                    m.InTime = item["InTime"].ToString();
                    m.OutTime = item["OutTime"].ToString();
                    m.NOP = item["NOP"].ToString();
                    m.PId = item["PId"].ToString();
                    m.PName = item["PName"].ToString();
                    m.Attachment = item["Attachment"].ToString();
                    m.AddedBy = item["AddedBy"].ToString();
                    m.Note = item["Note"].ToString();
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
        public ActionResult Visitors(Visitors c, List<HttpPostedFileBase> Attachment)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;

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
                if (dl.InsertVisitors_Sp(c) > 0)
                {
                    TempData["MSG"] = "Visitors Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/FrontOffice/Visitors");
            }
            TempData["MSG"] = "Visitors Added Successfully.";
            return Redirect("/FrontOffice/Visitors");
        }


        public JsonResult DeleteVisitors(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteVisitor";
            ds = dl.FetchVisitors_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult VisitorStatus(string id, string status)
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
            a.OnTable = "ChangeVisitorStatus";
            ds = dl.FetchVisitors_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditVisitors(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchVisitors";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchVisitors_sp(p);


            List<SelectListItem> Purposeinventory = new List<SelectListItem>();
            Purposeinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Purposeinventory.Add(new SelectListItem { Text = dr["PName"].ToString(), Value = dr["PId"].ToString() });
            }
            ViewBag.Purposeinventory = new SelectList(Purposeinventory, "Value", "Text");

            Visitors info = new RXGOADMIN.Models.Visitors();

            try
            {
                info = new RXGOADMIN.Models.Visitors()
                {
               VId  = ds.Tables[2].Rows[0]["VId"].ToString(),
               VName= ds.Tables[2].Rows[0]["VName"].ToString(),
               Phone = ds.Tables[2].Rows[0]["Phone"].ToString(),
               Date= ds.Tables[2].Rows[0]["Date"].ToString(),
               IDCard= ds.Tables[2].Rows[0]["IDCard"].ToString(),
               InTime= ds.Tables[2].Rows[0]["InTime"].ToString(),
               OutTime = ds.Tables[2].Rows[0]["OutTime"].ToString(),
               NOP = ds.Tables[2].Rows[0]["NOP"].ToString(),
               Note = ds.Tables[2].Rows[0]["Note"].ToString(),
               Attachment = ds.Tables[2].Rows[0]["Attachment"].ToString(),
               PId = ds.Tables[2].Rows[0]["PId"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }

        #endregion

        #region GeneralCall
        public ActionResult GeneralCall()
        {
            List<GeneralCall> CategoryList = new List<GeneralCall>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchGeneralCall";

            ds = dl.FetchGeneralCall_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    GeneralCall m = new GeneralCall();

                    m.PId = item["PId"].ToString();
                    m.PName = item["PName"].ToString();
                    m.Phone = item["Phone"].ToString();
                    m.Date = item["Date"].ToString();
                    m.NextDate = item["NextDate"].ToString();
                    m.CallType = item["CallType"].ToString();
                    m.Note = item["Note"].ToString();
                    m.CallDuration = item["CallDuration"].ToString();
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
        public ActionResult GeneralCall(GeneralCall c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertGeneralCall_Sp(c) > 0)
                {
                    TempData["MSG"] = "General Call Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/FrontOffice/GeneralCall");
            }
            TempData["MSG"] = "General Call Added Successfully.";
            return Redirect("/FrontOffice/GeneralCall");
        }


        public JsonResult DeleteGeneralCall(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteGeneralCall";
            ds = dl.FetchGeneralCall_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult GeneralCallStatus(string id, string status)
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
        //    a.OnTable = "ChangeGeneralCallStatus";
        //    ds = dl.FetchGeneralCall_sp(a);
        //    return Json(1, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult EditGeneralCall(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchGeneralCall";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchGeneralCall_sp(p);

            GeneralCall info = new RXGOADMIN.Models.GeneralCall();
            try
            {
                info = new RXGOADMIN.Models.GeneralCall()
                {
                    PId = ds.Tables[1].Rows[0]["PId"].ToString(),
                    PName = ds.Tables[1].Rows[0]["PName"].ToString(),
                    Phone = ds.Tables[1].Rows[0]["Phone"].ToString(),
                    Date = ds.Tables[1].Rows[0]["Date"].ToString(),
                    NextDate = ds.Tables[1].Rows[0]["NextDate"].ToString(),
                    CallType = ds.Tables[1].Rows[0]["CallType"].ToString(),
                    Description = ds.Tables[1].Rows[0]["Description"].ToString(),
                    Note = ds.Tables[1].Rows[0]["Note"].ToString(),
                    CallDuration = ds.Tables[1].Rows[0]["CallDuration"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }

        #endregion

        #region Postal
        public ActionResult PostalReceive()
        {
            List<PostalReceive> CategoryList = new List<PostalReceive>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPostalReceive";

            ds = dl.FetchPostalReceive_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    PostalReceive m = new PostalReceive();

                    m.Id = item["Id"].ToString();
                    m.FromTitle = item["FromTitle"].ToString();
                    m.ReferenceNo = item["ReferenceNo"].ToString();
                    m.ToTitle = item["ToTitle"].ToString();
                    m.Date = item["Date"].ToString();
                    m.Address = item["Address"].ToString();
                    m.Note = item["Note"].ToString();
                    m.Attachment = item["Attachment"].ToString();
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
        public ActionResult PostalReceive(PostalReceive c, List<HttpPostedFileBase> Attachment)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;

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
                if (dl.InsertPostalReceive_Sp(c) > 0)
                {
                    TempData["MSG"] = "Postal Receive Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/FrontOffice/PostalReceive");
            }
            TempData["MSG"] = "Postal Receive Added Successfully.";
            return Redirect("/FrontOffice/PostalReceive");
        }


        public JsonResult DeletePostalReceive(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeletePostalReceive";
            ds = dl.FetchPostalReceive_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult PostalReceiveStatus(string id, string status)
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
        //    a.OnTable = "ChangePostalReceiveStatus";
        //    ds = dl.FetchPostalReceive_sp(a);
        //    return Json(1, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult EditPostalReceive(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPostalReceive";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchPostalReceive_sp(p);

            PostalReceive info = new RXGOADMIN.Models.PostalReceive();
            try
            {
                info = new RXGOADMIN.Models.PostalReceive()
                {
                    Id = ds.Tables[1].Rows[0]["Id"].ToString(),
                    FromTitle = ds.Tables[1].Rows[0]["FromTitle"].ToString(),
                    ReferenceNo = ds.Tables[1].Rows[0]["ReferenceNo"].ToString(),
                    ToTitle = ds.Tables[1].Rows[0]["ToTitle"].ToString(),
                    Date = ds.Tables[1].Rows[0]["Date"].ToString(),
                    Address = ds.Tables[1].Rows[0]["Address"].ToString(),
                    Note = ds.Tables[1].Rows[0]["Note"].ToString(),
                    Attachment = ds.Tables[1].Rows[0]["Attachment"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }


        public ActionResult PostalDispatch()
        {
            List<PostalDispatch> CategoryList = new List<PostalDispatch>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPostalDispatch";

            ds = dl.FetchPostalDispatch_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    PostalDispatch m = new PostalDispatch();

                    m.Id = item["Id"].ToString();
                    m.FromTitle = item["FromTitle"].ToString();
                    m.ReferenceNo = item["ReferenceNo"].ToString();
                    m.ToTitle = item["ToTitle"].ToString();
                    m.Date = item["Date"].ToString();
                    m.Address = item["Address"].ToString();
                    m.Note = item["Note"].ToString();
                    m.Attachment = item["Attachment"].ToString();
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
        public ActionResult PostalDispatch(PostalDispatch c, List<HttpPostedFileBase> Attachment)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;

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
                if (dl.InsertPostalDispatch_Sp(c) > 0)
                {
                    TempData["MSG"] = "Postal Dispatch Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/FrontOffice/PostalDispatch");
            }
            TempData["MSG"] = "Postal Dispatch Added Successfully.";
            return Redirect("/FrontOffice/PostalDispatch");
        }


        public JsonResult DeletePostalDispatch(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeletePostalDispatch";
            ds = dl.FetchPostalDispatch_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult PostalDispatchStatus(string id, string status)
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
        //    a.OnTable = "ChangePostalDispatchStatus";
        //    ds = dl.FetchPostalDispatch_sp(a);
        //    return Json(1, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult EditPostalDispatch(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPostalDispatch";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchPostalDispatch_sp(p);

            PostalDispatch info = new RXGOADMIN.Models.PostalDispatch();
            try
            {
                info = new RXGOADMIN.Models.PostalDispatch()
                {
                    Id = ds.Tables[1].Rows[0]["Id"].ToString(),
                    FromTitle = ds.Tables[1].Rows[0]["FromTitle"].ToString(),
                    ReferenceNo = ds.Tables[1].Rows[0]["ReferenceNo"].ToString(),
                    ToTitle = ds.Tables[1].Rows[0]["ToTitle"].ToString(),
                    Date = ds.Tables[1].Rows[0]["Date"].ToString(),
                    Address = ds.Tables[1].Rows[0]["Address"].ToString(),
                    Note = ds.Tables[1].Rows[0]["Note"].ToString(),
                    Attachment = ds.Tables[1].Rows[0]["Attachment"].ToString()
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