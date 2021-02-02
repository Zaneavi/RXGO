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
    public class PharmacyController : Controller
    {
        // GET: Pharmacy
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category()
        {
            List<PharmacyCategory> CategoryList = new List<PharmacyCategory>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPharmacyCategory";

            ds = dl.FetchPharmacyCategory_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    PharmacyCategory m = new PharmacyCategory();

                    m.CategoryId = item["CategoryId"].ToString();
                    m.CategoryName = item["CategoryName"].ToString();
                    m.AddedBy = item["AddedBy"].ToString();
                    m.AddedOn = item["AddedOn"].ToString();
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
        public ActionResult Category(PharmacyCategory c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string hospitalid = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = hospitalid;
            try
            {
                if (dl.InsertPharmacyCategory_Sp(c) > 0)
                {
                    TempData["MSG"] = "Data Saved Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Pharmacy/Category");
            }
            TempData["MSG"] = "Data Saved Successfully.";
            return Redirect("/Pharmacy/Category");
        }
        public JsonResult DeleteCategory(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteCategory";
            ds = dl.FetchPharmacyCategory_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PharmacyCategoryStatus(string id, string status)
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
            a.OnTable = "ChangePharmacyStatus";
            ds = dl.FetchPharmacyCategory_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditCategory(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPharmacyCategory";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchPharmacyCategory_sp(p);

            PharmacyCategory info = new RXGOADMIN.Models.PharmacyCategory();
            try
            {
                info = new RXGOADMIN.Models.PharmacyCategory()
                {
                    CategoryId = ds.Tables[0].Rows[0]["CategoryId"].ToString(),
                    CategoryName = ds.Tables[0].Rows[0]["CategoryName"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }
        //public ActionResult Medicine()
        //{
        //    List<Medicine> MedicineList = new List<Medicine>();
        //    Property p = new Property();
        //    DataSet ds = new DataSet();
        //    p.OnTable = "FetchMedicine";

        //    ds = dl.FetchMedicine_sp(p);

        //    List<SelectListItem> CategoryList = new List<SelectListItem>();
        //    CategoryList.Add(new SelectListItem { Text = "Select Category", Value = "" });
        //    foreach (DataRow dr in ds.Tables[1].Rows)
        //    {
        //        CategoryList.Add(new SelectListItem { Text = dr["CategoryName"].ToString(), Value = dr["CategoryId"].ToString() });
        //    }
        //    ViewBag.CategoryList = new SelectList(CategoryList, "Value", "Text");

        //    try
        //    {
        //        foreach (DataRow item in ds.Tables[0].Rows)
        //        {
        //            Medicine m = new Medicine();

        //            m.MedicineId = item["MedicineId"].ToString();
        //            m.CategoryId = item["CategoryId"].ToString();
        //            m.CategoryName = item["CategoryName"].ToString();
        //            m.MedicineName = item["MedicineName"].ToString();
        //            m.MedicineCompany = item["MedicineCompany"].ToString();
        //            m.MedicineComposition = item["MedicineComposition"].ToString();
        //            m.MedicineGroup = item["MedicineGroup"].ToString();
        //            m.Unit = item["Unit"].ToString();
        //            m.MinLevel = item["MinLevel"].ToString();
        //            m.ReOrderLevel = item["ReOrderLevel"].ToString();
        //            m.VAT = item["VAT"].ToString();
        //            m.Packing = item["Packing"].ToString();
        //            m.VATAC = item["VATAC"].ToString();
        //            m.Note = item["Note"].ToString();
        //            m.IsActive = item["IsActive"].ToString();
        //            m.MedicinePhoto = item["MedicinePhoto"].ToString();
        //            MedicineList.Add(m);
        //        }
        //        ViewBag.MedicineList = MedicineList;
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Medicine(Medicine m, List<HttpPostedFileBase> fileUpload)
        //{
        //    string fileLocation = "";
        //    string ItemUploadFolderPath = "~/DataImages/";
        //    try
        //    {
        //        try
        //        {
        //            if (fileUpload.Count > 0)
        //            {
        //                foreach (HttpPostedFileBase file in fileUpload)
        //                {
        //                    try
        //                    {
        //                        if (file.ContentLength == 0)
        //                            continue;

        //                        if (file.ContentLength > 0)
        //                        {
        //                            fileLocation = HelperFunctions.renameUploadFile(file, ItemUploadFolderPath);
        //                            if (fileLocation == "")
        //                            {
        //                                fileLocation = "";
        //                            }
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {

        //                    }

        //                    if (fileLocation == "" || fileLocation == null)
        //                    {
        //                        m.MedicinePhoto = m.MedicinePhoto;
        //                    }
        //                    else
        //                    {
        //                        m.MedicinePhoto = fileLocation;
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
        //    string hospitalid = rxgoAdminCookie.Values["Hid"];
        //    m.AddedBy = hospitalid;

        //    try
        //    {
        //        if (dl.InsertMedicine_Sp(m) > 0)
        //        {
        //            TempData["MSG"] = "Data Saved Successfully.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["MSG"] = "Something went wrong.";
        //        return Redirect("/Pharmacy/Medicine");
        //    }
        //    TempData["MSG"] = "Data Saved Successfully.";
        //    return Redirect("/Pharmacy/Medicine");
        //}
        //public ActionResult Bill()
        //{
        //    List<Pharmacy> PharmacyList = new List<Pharmacy>();
        //    Property p = new Property();
        //    DataSet ds = new DataSet();
        //    p.OnTable = "FetchPharmacy";
        //    ds = dl.FetchBill_sp(p);

        //    int ID = 1;
        //    ViewBag.Bill = ID;

        //    List<SelectListItem> PatientList = new List<SelectListItem>();
        //    PatientList.Add(new SelectListItem { Text = "Select", Value = "" });
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        PatientList.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["PatientId"].ToString() });
        //    }
        //    ViewBag.PatientList = new SelectList(PatientList, "Value", "Text");

        //    List<SelectListItem> CategoryList = new List<SelectListItem>();
        //    CategoryList.Add(new SelectListItem { Text = "Select Category", Value = "" });
        //    foreach (DataRow dr in ds.Tables[1].Rows)
        //    {
        //        CategoryList.Add(new SelectListItem { Text = dr["CategoryName"].ToString(), Value = dr["CategoryId"].ToString() });
        //    }
        //    ViewBag.CategoryList = new SelectList(CategoryList, "Value", "Text");

        //    List<SelectListItem> DoctorList = new List<SelectListItem>();
        //    DoctorList.Add(new SelectListItem { Text = "Select", Value = "" });
        //    foreach (DataRow dr in ds.Tables[3].Rows)
        //    {
        //        DoctorList.Add(new SelectListItem { Text = dr["FullName"].ToString(), Value = dr["EmployeeId"].ToString() });
        //    }
        //    ViewBag.DoctorList = new SelectList(DoctorList, "Value", "Text");

        //    try
        //    {
        //        foreach (DataRow item in ds.Tables[5].Rows)
        //        {
        //            Pharmacy m = new Pharmacy();

        //            m.PharmacyId = item["PharmacyId"].ToString();
        //            m.BillNo = item["BillNo"].ToString();
        //            m.Date = item["Date"].ToString();
        //            m.PatientId = item["PatientId"].ToString();
        //            m.Name = item["Name"].ToString();
        //            m.EmployeeId = item["EmployeeId"].ToString();
        //            m.FullName = item["FullName"].ToString();
        //            m.Total = Convert.ToDecimal(item["Total"].ToString());
        //            m.IsActive = item["IsActive"].ToString();
        //            PharmacyList.Add(m);
        //        }
        //        ViewBag.PharmacyList = PharmacyList;
        //    }
        //    catch (Exception e)
        //    {

        //    }

        //    Pharmacy info = new Pharmacy();
        //    try
        //    {
        //        info = new RXGOADMIN.Models.Pharmacy()
        //        {
        //            BillNo = ds.Tables[6].Rows[0]["BillNo"].ToString()
        //        };
        //        long bill = Convert.ToInt64(info.BillNo);
        //        bill++;
        //        ViewBag.Bill = bill;
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Bill(Pharmacy p)
        //{
        //    HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
        //    string hospitalid = rxgoAdminCookie.Values["Hid"];
        //    p.AddedBy = hospitalid;

        //    try
        //    {
        //        if (dl.InsertBill_Sp(p) > 0)
        //        {
        //            TempData["MSG"] = "Data Saved Successfully.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["MSG"] = "Something went wrong.";
        //        return Redirect("/Pharmacy/Bill");
        //    }
        //    TempData["MSG"] = "Data Saved Successfully.";
        //    return Redirect("/Pharmacy/Bill");
        //}
        //public ActionResult Purchase()
        //{
        //    List<Purchase> PurchaseList = new List<Purchase>();
        //    Property p = new Property();
        //    DataSet ds = new DataSet();
        //    p.OnTable = "FetchMedicine";

        //    ds = dl.FetchMedicinesPurchase_sp(p);

        //    List<SelectListItem> SupplierList = new List<SelectListItem>();
        //    SupplierList.Add(new SelectListItem { Text = "Select Supplier", Value = "" });
        //    foreach (DataRow dr in ds.Tables[1].Rows)
        //    {
        //        SupplierList.Add(new SelectListItem { Text = dr["SupplierName"].ToString(), Value = dr["SupplierId"].ToString() });
        //    }
        //    ViewBag.SupplierList = new SelectList(SupplierList, "Value", "Text");

        //    List<SelectListItem> MedicineCategoryList = new List<SelectListItem>();
        //    MedicineCategoryList.Add(new SelectListItem { Text = "Select", Value = "" });
        //    foreach (DataRow dr in ds.Tables[2].Rows)
        //    {
        //        MedicineCategoryList.Add(new SelectListItem { Text = dr["CategoryName"].ToString(), Value = dr["CategoryId"].ToString() });
        //    }
        //    ViewBag.MedicineCategoryList = new SelectList(MedicineCategoryList, "Value", "Text");

        //    try
        //    {
        //        foreach (DataRow item in ds.Tables[4].Rows)
        //        {
        //            Purchase m = new Purchase();

        //            m.PurchaseId = item["PurchaseId"].ToString();
        //            m.InvoiceNo = item["InvoiceNo"].ToString();
        //            m.SupplierId = item["SupplierId"].ToString();
        //            m.SupplierName = item["SupplierName"].ToString();
        //            m.Amount = item["Amount"].ToString();
        //            m.Tax = Convert.ToDecimal(item["Tax"].ToString());
        //            m.Discount = Convert.ToDecimal(item["Discount"].ToString());
        //            m.Total = Convert.ToDecimal(item["Total"].ToString());
        //            m.IsActive = item["IsActive"].ToString();
        //            PurchaseList.Add(m);
        //        }
        //        ViewBag.PurchaseList = PurchaseList;
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Purchase(Purchase p, List<HttpPostedFileBase> fileUpload)
        //{
        //    string fileLocation = "";
        //    string ItemUploadFolderPath = "~/DataImages/";
        //    try
        //    {
        //        try
        //        {
        //            if (fileUpload.Count > 0)
        //            {
        //                foreach (HttpPostedFileBase file in fileUpload)
        //                {
        //                    try
        //                    {
        //                        if (file.ContentLength == 0)
        //                            continue;

        //                        if (file.ContentLength > 0)
        //                        {
        //                            fileLocation = HelperFunctions.renameUploadFile(file, ItemUploadFolderPath);
        //                            if (fileLocation == "")
        //                            {
        //                                fileLocation = "";
        //                            }
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {

        //                    }

        //                    if (fileLocation == "" || fileLocation == null)
        //                    {
        //                        p.AttachDocument = p.AttachDocument;
        //                    }
        //                    else
        //                    {
        //                        p.AttachDocument = fileLocation;
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
        //    string hospitalid = rxgoAdminCookie.Values["Hid"];
        //    p.AddedBy = hospitalid;

        //    try
        //    {
        //        if (dl.InsertMedicinePurchase_Sp(p) > 0)
        //        {
        //            TempData["MSG"] = "Data Saved Successfully.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["MSG"] = "Something went wrong.";
        //        return Redirect("/Pharmacy/Purchase");
        //    }
        //    TempData["MSG"] = "Data Saved Successfully.";
        //    return Redirect("/Pharmacy/Purchase");
        //}
        //public JsonResult get_medicine_name(string medicine_category_id)
        //{
        //    List<Medicine> MedicineList = new List<Medicine>();
        //    Property a = new Property();
        //    DataSet ds = new DataSet();
        //    a.Condition1 = medicine_category_id;
        //    a.OnTable = "FetchMedicine";
        //    ds = dl.FetchMedicinesPurchase_sp(a);

        //    foreach (DataRow item in ds.Tables[3].Rows)
        //    {
        //        Medicine m = new Medicine();
        //        m.MedicineId = item["MedicineId"].ToString();
        //        m.MedicineName = item["MedicineName"].ToString();
        //        MedicineList.Add(m);
        //    }
        //    return Json(MedicineList, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult get_batch_no(string medicine_name_id)
        //{
        //    List<Purchase> BatchList = new List<Purchase>();
        //    Property a = new Property();
        //    DataSet ds = new DataSet();
        //    a.Condition1 = medicine_name_id;
        //    a.OnTable = "FetchPharmacy";
        //    ds = dl.FetchBill_sp(a);

        //    foreach (DataRow item in ds.Tables[2].Rows)
        //    {
        //        Purchase m = new Purchase();
        //        m.MedicineId = item["MedicineId"].ToString();
        //        m.BatchNo = item["BatchNo"].ToString();
        //        BatchList.Add(m);
        //    }
        //    return Json(BatchList, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult getExpiryDate(string batch_no, string med_id)
        //{
        //    //List<Purchase> BatchList = new List<Purchase>();
        //    Property a = new Property();
        //    DataSet ds = new DataSet();
        //    a.Condition1 = batch_no;
        //    a.Condition2 = med_id;
        //    a.OnTable = "FetchPharmacy";
        //    ds = dl.FetchBill_sp(a);

        //    Purchase info = new Purchase();
        //    try
        //    {
        //        info = new RXGOADMIN.Models.Purchase()
        //        {
        //            ExpiryDate = ds.Tables[4].Rows[0]["ExpiryDate"].ToString()
        //        };
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return Json(new { res = info.ExpiryDate }, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult getQuantity(string batch_no, string med_id)
        //{
        //    Property a = new Property();
        //    DataSet ds = new DataSet();
        //    a.Condition1 = batch_no;
        //    a.Condition2 = med_id;
        //    a.OnTable = "FetchPharmacy";
        //    ds = dl.FetchBill_sp(a);

        //    Purchase info = new Purchase();
        //    try
        //    {
        //        info = new RXGOADMIN.Models.Purchase()
        //        {
        //            SalePrice = ds.Tables[4].Rows[0]["SalePrice"].ToString()
        //        };
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return Json(new { res = info.SalePrice }, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult getBillNo(int id)
        //{
        //    return Json(id, JsonRequestBehavior.AllowGet);
        //}
        ////public JsonResult getBillNo(int id)
        ////{
        ////    Property a = new Property();
        ////    DataSet ds = new DataSet();
        ////    a.OnTable = "FetchPharmacy";
        ////    ds = dl.FetchBill_sp(a);

        ////    Pharmacy info = new Pharmacy();
        ////    try
        ////    {
        ////        info = new RXGOADMIN.Models.Pharmacy()
        ////        {
        ////            BillNo = ds.Tables[6].Rows[0]["BillNo"].ToString()
        ////        };
        ////        id++;
        ////    }
        ////    catch (Exception e)
        ////    {

        ////    }
        ////    return Json(id, JsonRequestBehavior.AllowGet);
        ////}
        //public ActionResult Supplier()
        //{
        //    List<Supplier> SupplierList = new List<Supplier>();
        //    Property p = new Property();
        //    DataSet ds = new DataSet();
        //    p.OnTable = "FetchSupplier";

        //    ds = dl.FetchSupplier_sp(p);

        //    try
        //    {
        //        foreach (DataRow item in ds.Tables[0].Rows)
        //        {
        //            Supplier m = new Supplier();

        //            m.SupplierId = item["SupplierId"].ToString();
        //            m.SupplierName = item["SupplierName"].ToString();
        //            m.AddedBy = item["AddedBy"].ToString();
        //            m.AddedOn = item["AddedOn"].ToString();
        //            m.IsActive = item["IsActive"].ToString();
        //            SupplierList.Add(m);
        //        }
        //        ViewBag.SupplierList = SupplierList;
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Supplier(Supplier s)
        //{
        //    HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
        //    string hospitalid = rxgoAdminCookie.Values["Hid"];
        //    s.AddedBy = hospitalid;
        //    try
        //    {
        //        if (dl.InsertSupplier_Sp(s) > 0)
        //        {
        //            TempData["MSG"] = "Data Saved Successfully.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["MSG"] = "Something went wrong.";
        //        return Redirect("/Pharmacy/Supplier");
        //    }
        //    TempData["MSG"] = "Data Saved Successfully.";
        //    return Redirect("/Pharmacy/Supplier");
        //}
        //public JsonResult SupplierStatus(string id, string status)
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
        //    a.OnTable = "ChangeSupplierStatus";
        //    ds = dl.FetchSupplier_sp(a);
        //    return Json(1, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult DeleteSupplier(string id)
        //{
        //    Property a = new Property();
        //    DataSet ds = new DataSet();
        //    a.Condition1 = id;
        //    a.OnTable = "DeleteSupplier";
        //    ds = dl.FetchSupplier_sp(a);
        //    return Json(1, JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult EditSupplier(string id)
        //{
        //    Property p = new Property();
        //    DataSet ds = new DataSet();
        //    p.OnTable = "FetchSupplier";
        //    if (id != null)
        //    {
        //        p.Condition1 = id;
        //    }

        //    ds = dl.FetchSupplier_sp(p);

        //    Supplier info = new RXGOADMIN.Models.Supplier();
        //    try
        //    {
        //        info = new RXGOADMIN.Models.Supplier()
        //        {
        //            SupplierId = ds.Tables[1].Rows[0]["SupplierId"].ToString(),
        //            SupplierName = ds.Tables[1].Rows[0]["SupplierName"].ToString()
        //        };

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return PartialView(info);
        //}
        //public ActionResult getSupplierDetails(string id)
        //{
        //    Property p = new Property();
        //    DataSet ds = new DataSet();
        //    p.OnTable = "FetchMedicine";
        //    if (id != null)
        //    {
        //        p.Condition1 = id;
        //    }

        //    ds = dl.FetchMedicinesPurchase_sp(p);

        //    Purchase info = new RXGOADMIN.Models.Purchase();
        //    try
        //    {
        //        info = new RXGOADMIN.Models.Purchase()
        //        {
        //            PurchaseId = ds.Tables[5].Rows[0]["PurchaseId"].ToString(),
        //            InvoiceNo = ds.Tables[5].Rows[0]["InvoiceNo"].ToString(),
        //            PurchaseDate = ds.Tables[5].Rows[0]["PurchaseDate"].ToString(),
        //            SupplierName = ds.Tables[5].Rows[0]["SupplierName"].ToString(),
        //            CategoryName = ds.Tables[5].Rows[0]["CategoryName"].ToString(),
        //            MedicineName = ds.Tables[5].Rows[0]["MedicineName"].ToString(),
        //            BatchNo = ds.Tables[5].Rows[0]["BatchNo"].ToString(),
        //            ExpiryDate = ds.Tables[5].Rows[0]["ExpiryDate"].ToString(),
        //            MRP = ds.Tables[5].Rows[0]["MRP"].ToString(),
        //            BatchAmt = ds.Tables[5].Rows[0]["BatchAmt"].ToString(),
        //            SalePrice = ds.Tables[5].Rows[0]["SalePrice"].ToString(),
        //            PackingQty = ds.Tables[5].Rows[0]["PackingQty"].ToString(),
        //            Quantity = ds.Tables[5].Rows[0]["Quantity"].ToString(),
        //            PurchasePrice = ds.Tables[5].Rows[0]["PurchasePrice"].ToString(),
        //            Amount = ds.Tables[5].Rows[0]["Amount"].ToString(),
        //            Total = Convert.ToDecimal(ds.Tables[5].Rows[0]["Total"].ToString()),
        //            Discount = Convert.ToDecimal(ds.Tables[5].Rows[0]["Discount"].ToString()),
        //            Tax = Convert.ToDecimal(ds.Tables[5].Rows[0]["Tax"].ToString()),
        //            NetAmount = Convert.ToDecimal(ds.Tables[5].Rows[0]["NetAmount"].ToString())
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return PartialView(info);
        //}
        //public ActionResult getBill(string id)
        //{
        //    Property p = new Property();
        //    DataSet ds = new DataSet();
        //    p.OnTable = "FetchPharmacy";
        //    if (id != null)
        //    {
        //        p.Condition1 = id;
        //    }

        //    ds = dl.FetchBill_sp(p);

        //    Pharmacy info = new RXGOADMIN.Models.Pharmacy();
        //    try
        //    {
        //        info = new RXGOADMIN.Models.Pharmacy()
        //        {
        //            PharmacyId = ds.Tables[7].Rows[0]["PharmacyId"].ToString(),
        //            BillNo = ds.Tables[7].Rows[0]["BillNo"].ToString(),
        //            Date = ds.Tables[7].Rows[0]["Date"].ToString(),
        //            Name = ds.Tables[7].Rows[0]["Name"].ToString(),
        //            FullName = ds.Tables[7].Rows[0]["FullName"].ToString(),
        //            MedicineName = ds.Tables[7].Rows[0]["MedicineName"].ToString(),
        //            BatchNo = ds.Tables[7].Rows[0]["BatchNo"].ToString(),
        //            ExpiryDate = ds.Tables[7].Rows[0]["ExpiryDate"].ToString(),
        //            Quantity = ds.Tables[7].Rows[0]["Quantity"].ToString(),
        //            SalePrice = ds.Tables[7].Rows[0]["SalePrice"].ToString(),
        //            Total = Convert.ToDecimal(ds.Tables[7].Rows[0]["Total"].ToString()),
        //            Discount = Convert.ToDecimal(ds.Tables[7].Rows[0]["Discount"].ToString()),
        //            Tax = Convert.ToDecimal(ds.Tables[7].Rows[0]["Tax"].ToString()),
        //            NetAmount = Convert.ToDecimal(ds.Tables[7].Rows[0]["NetAmount"].ToString())
        //            //AddedBy= ds.Tables[7].Rows[0]["AddedBy"].ToString()
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return PartialView(info);
        //}
        //public ActionResult searchpatient(string phoneno)
        //{
        //    Property p = new Property();
        //    DataSet ds = new DataSet();
        //    p.Condition1 = phoneno;
        //    p.OnTable = "FetchPhoneno";
        //    ds = dl.FetchBill_sp(p);

        //    OPDPatient info = new RXGOADMIN.Models.OPDPatient();
        //    try
        //    {
        //        info = new RXGOADMIN.Models.OPDPatient()
        //        {
        //            PatientId = ds.Tables[0].Rows[0]["PatientId"].ToString(),
        //            Name = ds.Tables[0].Rows[0]["Name"].ToString(),
        //            Phone = ds.Tables[0].Rows[0]["Phone"].ToString()
        //        };

        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    //return Json(info, JsonRequestBehavior.AllowGet);
        //    if (info.Name != null)
        //    {
        //        return Json(info, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("", JsonRequestBehavior.AllowGet);
        //    }
        //}

    }
}