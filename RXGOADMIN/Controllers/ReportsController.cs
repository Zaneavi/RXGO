using RXGOADMIN.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RXGOADMIN.Controllers
{
    public class ReportsController : Controller
    {
        DLayer dl = new DLayer();
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        #region DeathReport
        public ActionResult DeathReport(string date_from,string date_to)
        {
            List<DeathReport> DthList = new List<DeathReport>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "GetDeathRecord";
            p.Condition1 = date_from;
            p.Condition2 = date_to;
            ds = dl.GetDeathReport_sp(p);
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    DeathReport m = new DeathReport();

                    m.DId = item["DId"].ToString();
                    m.PatientName = item["PatientName"].ToString();
                    m.Gender = item["Gender"].ToString();
                    m.DeathDate = item["DeathDate"].ToString();
                    m.IPDOPDNo = item["IPDOPDNo"].ToString();
                    //m.GuardianName = item["GuardianName"].ToString();
                    //m.Report = item["Report"].ToString();
                    //m.ReceiverName = item["ReceiverName"].ToString();
                    //m.IsActive = item["IsActive"].ToString();
                    DthList.Add(m);
                }
                ViewBag.DthList = DthList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }


        public ActionResult BirthReport(string date_from, string date_to)
        {
            List<BirthReport> BthList = new List<BirthReport>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "GetBirthRecord";
            p.Condition1 = date_from;
            p.Condition2 = date_to;
            ds = dl.GetBirthReport_sp(p);
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    BirthReport m = new BirthReport();

                    m.BId = item["BId"].ToString();
                    m.ChildName = item["ChildName"].ToString();
                    m.Gender = item["Gender"].ToString();
                    m.Weight = item["Weight"].ToString();
                    m.IPDOPDNo = item["IPDOPDNo"].ToString();
                    m.BirthDate = item["BirthDate"].ToString();
                    m.FatherName = item["FatherName"].ToString();
                    m.MotherName = item["MotherName"].ToString();
                   

                    //m.GuardianName = item["GuardianName"].ToString();
                    //m.Report = item["Report"].ToString();
                    //m.ReceiverName = item["ReceiverName"].ToString();
                    //m.IsActive = item["IsActive"].ToString();
                    BthList.Add(m);
                }
                ViewBag.BthList = BthList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }





        public ActionResult IncomeReport(string date_from, string date_to)
        {
            List<IncomeList> IncList = new List<IncomeList>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "GetIncomeRecord";
            p.Condition1 = date_from;
            p.Condition2 = date_to;
            ds = dl.GetIncomeReport_sp(p);
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    IncomeList m = new IncomeList();

                    m.Id = item["Id"].ToString();
                    m.Name = item["Name"].ToString();
                    m.InvoiceNo = item["InvoiceNo"].ToString();
                    m.HeadId = item["HeadId"].ToString();
                    m.HeadName = item["HeadName"].ToString();
                    m.Date = item["Date"].ToString();
                    m.Amount = item["Amount"].ToString();
                    //m.ReceiverName = item["ReceiverName"].ToString();
                    //m.IsActive = item["IsActive"].ToString();
                    IncList.Add(m);
                }
                ViewBag.IncList = IncList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult ExpenseReport(string date_from, string date_to)
        {
            List<ExpenseList> ExpList = new List<ExpenseList>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "GetExpenseRecord";
            p.Condition1 = date_from;
            p.Condition2 = date_to;
            ds = dl.GetExpenseReport_sp(p);
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    ExpenseList m = new ExpenseList();

                    m.Id = item["Id"].ToString();
                    m.Name = item["Name"].ToString();
                    m.InvoiceNo = item["InvoiceNo"].ToString();
                    m.HeadId = item["HeadId"].ToString();
                    m.HeadName = item["HeadName"].ToString();
                    m.Date = item["Date"].ToString();
                    m.Amount = item["Amount"].ToString();
                    //m.ReceiverName = item["ReceiverName"].ToString();
                    //m.IsActive = item["IsActive"].ToString();
                    ExpList.Add(m);
                }
                ViewBag.ExpList = ExpList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult PharmacyBillReport(string date_from, string date_to)
        {
            List<BillDetails> BillList = new List<BillDetails>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "GetBillRecord";
            p.Condition1 = date_from;
            p.Condition2 = date_to;
            ds = dl.GetBillReport_sp(p);
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    BillDetails m = new BillDetails();

                    m.BillNo = item["BillNo"].ToString();
                    m.Date = item["Date"].ToString();
                    m.EmployeeId = item["EmployeeId"].ToString();
                    m.FullName = item["FullName"].ToString();
                    m.Name = item["Name"].ToString();
                    m.Total = item["Total"].ToString();
                  
                    BillList.Add(m);
                }
                ViewBag.BillList = BillList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult BloodIssueReport(string date_from, string date_to)
        {
            List<BloodIssueDetails> IssueList = new List<BloodIssueDetails>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "GetBloodIssueRecord";
            p.Condition1 = date_from;
            p.Condition2 = date_to;
            ds = dl.GetBloodIssueReport_sp(p);
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    BloodIssueDetails m = new BloodIssueDetails();

                    m.IssueId = item["IssueId"].ToString();
                    m.IssueDate = item["IssueDate"].ToString();
                    m.PatientId = item["PatientId"].ToString();
                    m.Name = item["Name"].ToString();
                    m.BloodGroup = item["BloodGroup"].ToString();
                    m.Gender = item["Gender"].ToString();
                    m.Lot = item["Lot"].ToString();
                    m.BagNo = item["BagNo"].ToString();
                    m.DonorName = item["DonorName"].ToString();
                    m.Amount = item["Amount"].ToString();

                    IssueList.Add(m);
                }
                ViewBag.IssueList = IssueList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }



        public ActionResult InventoryIssueReport(string date_from, string date_to)
        {
            List<InventoryIssueReport> InventoryIssueList = new List<InventoryIssueReport>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "GetInventoryIssueRecord";
            p.Condition1 = date_from;
            p.Condition2 = date_to;
            ds = dl.GetInventoryIssueReport_sp(p);
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    InventoryIssueReport m = new InventoryIssueReport();

                    m.ItemId = item["ItemId"].ToString();
                    m.ItemName = item["ItemName"].ToString();
                    m.CategoryId = item["CategoryId"].ToString();
                    m.Category = item["Category"].ToString();
                    m.IssueDate = item["IssueDate"].ToString();
                    m.ReturnDate = item["ReturnDate"].ToString();
                    m.IssueBy = item["IssueBy"].ToString();
                    m.Quantity = item["Quantity"].ToString();
                   
                    m.UserType = item["UserType"].ToString();

                    InventoryIssueList.Add(m);
                }
                ViewBag.InventoryIssueList = InventoryIssueList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult ExpiryMedicineReport(string date_from, string date_to)
        {
            List<ExpiryMedicineReport> ExpiryMedicineList = new List<ExpiryMedicineReport>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "GetExpiryMedicineRecord";
            p.Condition1 = date_from;
            p.Condition2 = date_to;
            ds = dl.GetExpiryMedicineReport_sp(p);
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    ExpiryMedicineReport m = new ExpiryMedicineReport();

                    m.MedicineId = item["MedicineId"].ToString();
                    m.MedicineName = item["MedicineName"].ToString();
                    m.BatchNo = item["BatchNo"].ToString();
                    m.MedicineCompany = item["MedicineCompany"].ToString();
                    m.CategoryId = item["CategoryId"].ToString();
                    m.CategoryName = item["CategoryName"].ToString();
                    m.MedicineGroup = item["MedicineGroup"].ToString();
                    m.ExpiryDate = item["ExpiryDate"].ToString();
                    m.Quantity = item["Quantity"].ToString();

                    ExpiryMedicineList.Add(m);
                }
                ViewBag.ExpiryMedicineList = ExpiryMedicineList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult InventoryStockReport()
        {
            List<InventoryStockReport> InventoryStockList = new List<InventoryStockReport>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "GetInventoryStockRecord";
            
            ds = dl.GetInventoryStockReport_sp(p);
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    InventoryStockReport m = new InventoryStockReport();
                    
                    m.ItemName = item["ItemName"].ToString();
                    m.Category = item["Category"].ToString();
                    m.SupplierName = item["SupplierName"].ToString();
                    m.StoreName = item["StoreName"].ToString();
                    m.AvailableQuantity = item["AvailableQuantity"].ToString();
                    m.Quantity = item["Quantity"].ToString();

                    InventoryStockList.Add(m);
                }
                ViewBag.InventoryStockList = InventoryStockList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult BloodDonorReport(string date_from, string date_to)
        {
            List<BloodDonorReport> BloodDonorList = new List<BloodDonorReport>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "GetBloodDonorRecord";
            p.Condition1 = date_from;
            p.Condition2 = date_to;
            ds = dl.GetBloodDonorReport_sp(p);
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    BloodDonorReport m = new BloodDonorReport();

                    m.DonorName = item["DonorName"].ToString();
                    m.BloodGroup = item["BloodGroup"].ToString();
                    m.Gender = item["Gender"].ToString();
                    m.AgeYear = item["AgeYear"].ToString();
                    m.Lot = item["Lot"].ToString();
                    m.BagNo = item["BagNo"].ToString();
                    m.Quantity = item["Quantity"].ToString();
                    m.DonorDate = item["DonorDate"].ToString();

                    BloodDonorList.Add(m);
                }
                ViewBag.BloodDonorList = BloodDonorList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult AmbulanceCallReport(string date_from, string date_to)
        {
            List<AmbulanceCallReport> AmbulanceCallList = new List<AmbulanceCallReport>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "GetAmbulanceCallRecord";
            p.Condition1 = date_from;
            p.Condition2 = date_to;
            ds = dl.GetAmbulanceCallReport_sp(p);
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    AmbulanceCallReport m = new AmbulanceCallReport();

                    m.VehicleNumber = item["VehicleNumber"].ToString();
                    m.VehicleModel = item["VehicleModel"].ToString();
                    m.DriverName = item["DriverName"].ToString();
                    m.Date = item["Date"].ToString();
                    m.Amount = Decimal.Parse (item["Amount"].ToString());
                    m.Name = item["Name"].ToString();
                   
                    AmbulanceCallList.Add(m);
                }
                ViewBag.AmbulanceCallList = AmbulanceCallList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }



        public ActionResult PathologyPatientReport(string date_from, string date_to)
        {
            List<PathologyPatientReport> PathologyPatientReport = new List<PathologyPatientReport>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchPathologyPatientReport";
            p.Condition1 = date_from;
            p.Condition2 = date_to;
            ds = dl.FetchPathologyPatientReport_sp(p);
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    PathologyPatientReport m = new PathologyPatientReport();

                    m.TestName = item["TestName"].ToString();
                    m.Description = item["Description"].ToString();
                    m.ChargeCategoryName = item["ChargeCategoryName"].ToString();
                    m.AppliedCharge = item["AppliedCharge"].ToString();
                    m.ReportingDate = item["ReportingDate"].ToString();
                    m.DoctorName = item["DoctorName"].ToString();
                    m.PatientName = item["PatientName"].ToString();

                    PathologyPatientReport.Add(m);
                }
                ViewBag.PathologyPatientReport = PathologyPatientReport;
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult RadiologyPatientReport(string date_from, string date_to)
        {
            List<RadiologyPatientReport> RadiologyPatientReport = new List<RadiologyPatientReport>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchRadiologyPatientReport";
            p.Condition1 = date_from;
            p.Condition2 = date_to;
            ds = dl.FetchRadiologyPatientReport_sp(p);
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    RadiologyPatientReport m = new RadiologyPatientReport();

                    m.TestName = item["TestName"].ToString();
                    m.ChargeCategoryName = item["ChargeCategoryName"].ToString();
                    m.ReportingDate = item["ReportingDate"].ToString();
                    m.Description = item["Description"].ToString();
                    m.StandardCharge = item["StandardCharge"].ToString();
                    m.DoctorName = item["DoctorName"].ToString();
                    m.PatientName = item["PatientName"].ToString();

                    RadiologyPatientReport.Add(m);
                }
                ViewBag.RadiologyPatientReport = RadiologyPatientReport;
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult InventoryItemReport(string date_from, string date_to)
        {
            DateTime dt1 = Convert.ToDateTime(date_from);
            DateTime dt2 = Convert.ToDateTime(date_to);
            List<InventoryItemReport> InventoryItemList = new List<InventoryItemReport>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "GetInventoryItemRecord";
            p.Condition1 = dt1.ToShortDateString();
            p.Condition2 = dt2.ToShortDateString();
            ds = dl.GetInventoryItemReport_sp(p);
            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    InventoryItemReport m = new InventoryItemReport();

                    m.Quantity = item["Quantity"].ToString();
                    m.PurchasePrice = item["PurchasePrice"].ToString();
                    m.Date = item["Date"].ToString();
                    m.StoreName = item["StoreName"].ToString();
                    m.SupplierName = item["SupplierName"].ToString();
                    m.ItemCategory = item["ItemCategory"].ToString();
                    m.ItemName = item["ItemName"].ToString();

                    InventoryItemList.Add(m);
                }
                ViewBag.InventoryItemList = InventoryItemList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }


        #endregion

    }
}