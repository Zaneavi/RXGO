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
    public class MedicineCategoryController : Controller
    {
        // GET: MedicineCategory
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        public ActionResult Index()
        {
            return View();
        }

        #region Category
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
                    TempData["MSG"] = "Category Added Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Pharmacy/Category");
            }
            TempData["MSG"] = "Category Added Successfully.";
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
        #region Supplier
        public ActionResult Supplier()
        {
            List<Supplier> SupplierList = new List<Supplier>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchSupplier";

            ds = dl.FetchSupplier_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Supplier m = new Supplier();

                    m.SupplierId = item["SupplierId"].ToString();
                    m.SupplierName = item["SupplierName"].ToString();
                    m.SupplierContact = item["SupplierContact"].ToString();
                    m.PersonName = item["PersonName"].ToString();
                    m.PersonNo = item["PersonNo"].ToString();
                    m.Address = item["Address"].ToString();
                    m.AddedBy = item["AddedBy"].ToString();
                    m.AddedOn = item["AddedOn"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    SupplierList.Add(m);
                }
                ViewBag.SupplierList = SupplierList;
            }
            catch (Exception e)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult Supplier(Supplier s)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string hospitalid = rxgoAdminCookie.Values["Hid"];
            s.AddedBy = hospitalid;
            try
            {
                if (dl.InsertSupplier_Sp(s) > 0)
                {
                    TempData["MSG"] = "Supplier Added Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/MedicineCategory/Supplier");
            }
            TempData["MSG"] = "Supplier Added Successfully.";
            return Redirect("/MedicineCategory/Supplier");
        }
        public JsonResult SupplierStatus(string id, string status)
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
            a.OnTable = "ChangeSupplierStatus";
            ds = dl.FetchSupplier_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteSupplier(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteSupplier";
            ds = dl.FetchSupplier_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditSupplier(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchSupplier";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchSupplier_sp(p);

            Supplier info = new RXGOADMIN.Models.Supplier();
            try
            {
                info = new RXGOADMIN.Models.Supplier()
                {
                    SupplierId = ds.Tables[1].Rows[0]["SupplierId"].ToString(),
                    SupplierName = ds.Tables[1].Rows[0]["SupplierName"].ToString(),
                    SupplierContact = ds.Tables[1].Rows[0]["SupplierContact"].ToString(),
                    PersonName = ds.Tables[1].Rows[0]["PersonName"].ToString(),
                    PersonNo = ds.Tables[1].Rows[0]["PersonNo"].ToString(),
                    Address = ds.Tables[1].Rows[0]["Address"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }
        #endregion

        #region Dosage
        public ActionResult Dosage()
        {
            List<PharmacyDosage> CategoryList = new List<PharmacyDosage>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPharmacyDosage";

            ds = dl.FetchPharmacyDosage_sp(p);


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
                    PharmacyDosage m = new PharmacyDosage();

                    m.DosageId = item["DosageId"].ToString();
                    m.DName = item["DName"].ToString();
                    m.CategoryId = item["CategoryId"].ToString();
                    m.CategoryName = item["CategoryName"].ToString();
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
        public ActionResult Dosage(PharmacyDosage c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertPharmacyDosage_sp(c) > 0)
                {
                    TempData["MSG"] = "Dosage Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/MedicineCategory/Dosage");
            }
            TempData["MSG"] = "Dosage Added Successfully.";
            return Redirect("/MedicineCategory/Dosage");
        }


        public JsonResult DeleteDosage(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteDosage";
            ds = dl.FetchPharmacyDosage_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PharmacyDosageStatus(string id, string status)
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
            a.OnTable = "ChangeDosageStatus";
            ds = dl.FetchPharmacyDosage_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditDosage(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPharmacyDosage";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchPharmacyDosage_sp(p);

            List<SelectListItem> Categoryinventory = new List<SelectListItem>();
            Categoryinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Categoryinventory.Add(new SelectListItem { Text = dr["CategoryName"].ToString(), Value = dr["CategoryId"].ToString() });
            }
            ViewBag.Categoryinventory = new SelectList(Categoryinventory, "Value", "Text");


            PharmacyDosage info = new RXGOADMIN.Models.PharmacyDosage();
            try
            {
                info = new RXGOADMIN.Models.PharmacyDosage()
                {
                    DosageId = ds.Tables[2].Rows[0]["DosageId"].ToString(),
                    DName = ds.Tables[2].Rows[0]["DName"].ToString(),
                    CategoryId = ds.Tables[2].Rows[0]["CategoryId"].ToString()
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