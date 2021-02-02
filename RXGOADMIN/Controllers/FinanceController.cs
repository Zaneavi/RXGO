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
    public class FinanceController : Controller
    {
        // GET: Finance
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        public ActionResult Index()
        {
            return View();
        }


        #region Incomehead
        public ActionResult Incomehead()
        {
            List<Incomehead> CategoryList = new List<Incomehead>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchIncomehead";

            ds = dl.FetchIncomehead_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Incomehead m = new Incomehead();

                    m.HeadId = item["HeadId"].ToString();
                    m.HeadName = item["HeadName"].ToString();
                    m.Description = item["Description"].ToString();
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
        public ActionResult Incomehead(Incomehead c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertIncomehead_Sp(c) > 0)
                {
                    TempData["MSG"] = "Income Head Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Finance/Incomehead");
            }
            TempData["MSG"] = "Income Head Added Successfully.";
            return Redirect("/Finance/Incomehead");
        }


        public JsonResult DeleteIncomehead(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteIncomehead";
            ds = dl.FetchIncomehead_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IncomeheadStatus(string id, string status)
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
            a.OnTable = "ChangeIncomeheadStatus";
            ds = dl.FetchIncomehead_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditIncomehead(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchIncomehead";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchIncomehead_sp(p);

            Incomehead info = new RXGOADMIN.Models.Incomehead();
            try
            {
                info = new RXGOADMIN.Models.Incomehead()
                {
                    HeadId = ds.Tables[1].Rows[0]["HeadId"].ToString(),
                    HeadName = ds.Tables[1].Rows[0]["HeadName"].ToString(),
                    Description = ds.Tables[1].Rows[0]["Description"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }

        #endregion


        #region Expensehead
        public ActionResult Expensehead()
        {
            List<Expensehead> CategoryList = new List<Expensehead>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchExpensehead";

            ds = dl.FetchExpensehead_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Expensehead m = new Expensehead();

                    m.HeadId = item["HeadId"].ToString();
                    m.HeadName = item["HeadName"].ToString();
                    m.Description = item["Description"].ToString();
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
        public ActionResult Expensehead(Expensehead c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertExpensehead_Sp(c) > 0)
                {
                    TempData["MSG"] = "Expense Head Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Finance/Expensehead");
            }
            TempData["MSG"] = "Expense Head Added Successfully.";
            return Redirect("/Finance/Expensehead");
        }


        public JsonResult DeleteExpensehead(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteExpensehead";
            ds = dl.FetchExpensehead_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExpenseheadStatus(string id, string status)
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
            a.OnTable = "ChangeExpenseheadStatus";
            ds = dl.FetchExpensehead_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditExpensehead(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchExpensehead";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchExpensehead_sp(p);

            Expensehead info = new RXGOADMIN.Models.Expensehead();
            try
            {
                info = new RXGOADMIN.Models.Expensehead()
                {
                    HeadId = ds.Tables[1].Rows[0]["HeadId"].ToString(),
                    HeadName = ds.Tables[1].Rows[0]["HeadName"].ToString(),
                    Description = ds.Tables[1].Rows[0]["Description"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }

        #endregion

        #region IncomeList
        public ActionResult IncomeList()
        {
            List<IncomeList> CategoryList = new List<IncomeList>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchIncomeList";

            ds = dl.FetchIncomeList_sp(p);

            List<SelectListItem> Categoryinventory = new List<SelectListItem>();
            Categoryinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Categoryinventory.Add(new SelectListItem { Text = dr["HeadName"].ToString(), Value = dr["HeadId"].ToString() });
            }
            ViewBag.Categoryinventory = new SelectList(Categoryinventory, "Value", "Text");


            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    IncomeList m = new IncomeList();

                    m.Id = item["Id"].ToString();
                    m.HeadId = item["HeadId"].ToString();
                    m.HeadName = item["HeadName"].ToString();
                    m.Name = item["Name"].ToString();
                    m.InvoiceNo = item["InvoiceNo"].ToString();
                    m.Date = item["Date"].ToString();
                    m.Amount = item["Amount"].ToString();
                    m.Attachment = item["Attachment"].ToString();
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
        public ActionResult IncomeList(IncomeList c, List<HttpPostedFileBase> Attachment)
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
                if (dl.InsertIncomeList_Sp(c) > 0)
                {
                    TempData["MSG"] = "Income List Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Finance/IncomeList");
            }
            TempData["MSG"] = "Income List Added Successfully.";
            return Redirect("/Finance/IncomeList");
        }
        
        public JsonResult DeleteIncomeList(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteIncomeList";
            ds = dl.FetchIncomeList_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IncomeListStatus(string id, string status)
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
            a.OnTable = "ChangeIncomeListStatus";
            ds = dl.FetchIncomeList_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditIncomeList(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchIncomeList";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchIncomeList_sp(p);

            List<SelectListItem> Categoryinventory = new List<SelectListItem>();
            Categoryinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Categoryinventory.Add(new SelectListItem { Text = dr["HeadName"].ToString(), Value = dr["HeadId"].ToString() });
            }
            ViewBag.Categoryinventory = new SelectList(Categoryinventory, "Value", "Text");

            IncomeList info = new RXGOADMIN.Models.IncomeList();
            try
            {
                info = new RXGOADMIN.Models.IncomeList()
                {
                    Id = ds.Tables[2].Rows[0]["Id"].ToString(),
                    HeadId = ds.Tables[2].Rows[0]["HeadId"].ToString(),
                    Name = ds.Tables[2].Rows[0]["Name"].ToString(),
                    InvoiceNo = ds.Tables[2].Rows[0]["InvoiceNo"].ToString(),
                    Date = ds.Tables[2].Rows[0]["Date"].ToString(),
                    Amount = ds.Tables[2].Rows[0]["Amount"].ToString(),
                    Attachment = ds.Tables[2].Rows[0]["Attachment"].ToString(),
                    Description = ds.Tables[2].Rows[0]["Description"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }



        #endregion

        #region ExpenseList
        public ActionResult ExpenseList()
        {
            List<ExpenseList> CategoryList = new List<ExpenseList>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchExpenseList";

            ds = dl.FetchExpenseList_sp(p);

            List<SelectListItem> Categoryinventory = new List<SelectListItem>();
            Categoryinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Categoryinventory.Add(new SelectListItem { Text = dr["HeadName"].ToString(), Value = dr["HeadId"].ToString() });
            }
            ViewBag.Categoryinventory = new SelectList(Categoryinventory, "Value", "Text");


            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    ExpenseList m = new ExpenseList();

                    m.Id = item["Id"].ToString();
                    m.HeadId = item["HeadId"].ToString();
                    m.HeadName = item["HeadName"].ToString();
                    m.Name = item["Name"].ToString();
                    m.InvoiceNo = item["InvoiceNo"].ToString();
                    m.Date = item["Date"].ToString();
                    m.Amount = item["Amount"].ToString();
                    m.Attachment = item["Attachment"].ToString();
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
        public ActionResult ExpenseList(ExpenseList c, List<HttpPostedFileBase> Attachment)
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
                if (dl.InsertExpenseList_Sp(c) > 0)
                {
                    TempData["MSG"] = "Expense List Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Finance/ExpenseList");
            }
            TempData["MSG"] = "Expense List Added Successfully.";
            return Redirect("/Finance/ExpenseList");
        }

        public JsonResult DeleteExpenseList(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteExpenseList";
            ds = dl.FetchExpenseList_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExpenseListStatus(string id, string status)
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
            a.OnTable = "ChangeExpenseListStatus";
            ds = dl.FetchExpenseList_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditExpenseList(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchExpenseList";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchExpenseList_sp(p);

            List<SelectListItem> Categoryinventory = new List<SelectListItem>();
            Categoryinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Categoryinventory.Add(new SelectListItem { Text = dr["HeadName"].ToString(), Value = dr["HeadId"].ToString() });
            }
            ViewBag.Categoryinventory = new SelectList(Categoryinventory, "Value", "Text");

            ExpenseList info = new RXGOADMIN.Models.ExpenseList();
            try
            {
                info = new RXGOADMIN.Models.ExpenseList()
                {
                    Id = ds.Tables[2].Rows[0]["Id"].ToString(),
                    HeadId = ds.Tables[2].Rows[0]["HeadId"].ToString(),
                    Name = ds.Tables[2].Rows[0]["Name"].ToString(),
                    InvoiceNo = ds.Tables[2].Rows[0]["InvoiceNo"].ToString(),
                    Date = ds.Tables[2].Rows[0]["Date"].ToString(),
                    Amount = ds.Tables[2].Rows[0]["Amount"].ToString(),
                    Attachment = ds.Tables[2].Rows[0]["Attachment"].ToString(),
                    Description = ds.Tables[2].Rows[0]["Description"].ToString()
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