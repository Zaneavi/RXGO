using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RXGOADMIN.Models
{
    public class Property
    {
        private string staticSMTPHOST = "#";

        public string StaticSMTPHOST
        {
            get
            {
                return staticSMTPHOST;
            }
        }

        public int staticSMTPPort = 25;
        public int StaticSMTPPort
        {
            get
            {
                return staticSMTPPort;
            }
        }
        public static string erroCheck { get; set; }
        private string staticCredentialEmail = "#";
        // private string staticCredentialEmail = "developer@gowebbi.com";
        public string StaticCredentialEmail
        {
            get
            {
                return staticCredentialEmail;
            }
        }

        //private string staticCredentialPass = "Gowebbi@123";
        private string staticCredentialPass = "#";

        public string StaticCredentialPass
        {
            get
            {
                return staticCredentialPass;
            }
        }

        public string Condition1 { get; set; }
        public string Condition2 { get; set; }
        public string Condition3 { get; set; }
        public string Condition4 { get; set; }
        public string Condition5 { get; set; }
        public string Condition6 { get; set; }
        public string Condition7 { get; set; }
        public string Condition8 { get; set; }
        public string Condition9 { get; set; }
        public string OnTable { get; set; }
    }
    #region AdminLogin
    public class AdminLogin
    {
        public string HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string HospitalWebsiteUrl { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CountryId { get; set; }
        public string StateId { get; set; }
        public string CityId { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string IsActive { get; set; }
    }
    #endregion
    #region Marketing Executive
    public class MarketingExecutive
    {
        public string ExecutiveId { get; set; }
        public string ExecutiveName { get; set; }
        public string ExecutiveEmail { get; set; }
        public string ExecutivePhone { get; set; }
        public string ExecutiveAge { get; set; }
        public string ExecutiveAddress { get; set; }
        public string AdminId { get; set; }
        public string Password { get; set; }
        public string CountryId { get; set; }
        public string StateId { get; set; }
        public string CityId { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string IsActive { get; set; }
    }
    public class Country
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string IsActive { get; set; }
    }
    public class State
    {
        public string StateId { get; set; }
        public string CountryId { get; set; }
        public string StateName { get; set; }
        public string IsActive { get; set; }
    }
    public class City
    {
        public string CityId { get; set; }
        public string CountryId { get; set; }
        public string StateId { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string IsActive { get; set; }
    }
    #endregion
    #region User Type
    public class UserTypes
    {
        public string UserTypeId { get; set; }
        public string UserType { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }
    #endregion
    #region Employee Profile
    public class EmployeeBasicdetail
    {
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Age { get; set; }
        public string UserTypeId { get; set; }
        public string HospitalId { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }
    public class EmployeePayroll
    {
        public string PayrollId { get; set; }
        public string EmployeeId { get; set; }
        public decimal Salary { get; set; }
        public decimal Pf { get; set; }
        public decimal MedicalIncentives { get; set; }
        public decimal ServiceTax { get; set; }
        public decimal Hra { get; set; }
        public string HospitalId { get; set; }
    }
    public class EmployeeDocument
    {
        public string DocumentId { get; set; }
        public string EmployeeId { get; set; }
        public string VoterId { get; set; }
        public string PanId { get; set; }
        public string AadharId { get; set; }
        public string ProfilePic { get; set; }
    }
    public class EmployeeDetails
    {
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string BloodGroup { get; set; }
        public string Dob { get; set; }
        public string DateJoining { get; set; }
        public string Address { get; set; }
        public string PermanentAddress { get; set; }
        public string Qualification { get; set; }
        public string WorkExp { get; set; }
        public string Specialization { get; set; }
        public string Note { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        //public string Age { get; set; }
        //public string HospitalId { get; set; }
        public string IsActive { get; set; }
        //public string PayrollId { get; set; }
        public string EPFNo { get; set; }
        public string ContractType { get; set; }
        public decimal Salary { get; set; }
        public string WorkShift { get; set; }
        public string Location { get; set; }
        public string DateOfLeaving { get; set; }
        //public string DocumentId { get; set; }
        public string Medical { get; set; }
        public string Casual { get; set; }
        public string Maternity { get; set; }
        public string AccountTitle { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string IFSCCode { get; set; }
        public string BankBranchName { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string LinkedinURL { get; set; }
        public string InstagramURL { get; set; }
        //public string VoterId { get; set; }
        public string Resume { get; set; }
        public string JoiningLetter { get; set; }
        public string ResignationLetter { get; set; }
        public string OtherDocuments { get; set; }
        public string ProfilePic { get; set; }
        public string UserTypeId { get; set; }
        public string UserType { get; set; }
    }
    #endregion

    public class Patient
    {
        public string PatientId { get; set; }
        public string Name { get; set; }
        public string GuardianName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string BloodGroup { get; set; }
        public string MaritalStatus { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public string AnyKnownAllergies { get; set; }
        public string PatientPhoto { get; set; }
        public string PatientUniqueId { get; set; }
    }

    #region OPD Patient
    public class OPDPatient
    {
        public string OPDId { get; set; }
        public string PatientId { get; set; }
        public string Name { get; set; }
        public string GuardianName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Age { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Remarks { get; set; }
        public string BloodGroup { get; set; }
        public string MaritalStatus { get; set; }
        public string PatientPhoto { get; set; }
        public string Address { get; set; }
        public string AnyKnownAllergies { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Bp { get; set; }
        public string Pulse { get; set; }
        public string Temperature { get; set; }
        public string Respiration { get; set; }
        public string SymptomsType { get; set; }
        public string SymptomsTypeId { get; set; }
        public string SymptomsTitle { get; set; }
        public string SymptomsTitleId { get; set; }
        public string Symptoms { get; set; }
        public string Note { get; set; }
        public string AppointmentDate { get; set; }
        public string PCase { get; set; }
        public string Casualty { get; set; }
        public string TPA { get; set; }
        public string Reference { get; set; }
        public string DoctorId { get; set; }
        public string ConsultantDoctor { get; set; }
        public decimal StandardCharge { get; set; }
        public decimal AppliedCharge { get; set; }
        public string PaymentMode { get; set; }
        public string OldPatient { get; set; }
        public string LiveConsultation { get; set; }
        public string Organisation { get; set; }
        public string TotalVisit { get; set; }
        public string OPDNo { get; set; }
        public string PatientUniqueId { get; set; }

    }
    #endregion
    #region IPD Patient
    public class IPDPatient
    {
        public string IPDNo { get; set; }
        //public string PatientId { get; set; }
        public string Name { get; set; }
        public string GuardianName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Remarks { get; set; }
        public string BloodGroup { get; set; }
        public string MaritalStatus { get; set; }
        public string PatientPhoto { get; set; }
        public string Address { get; set; }
        public string AnyKnownAllergies { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Bp { get; set; }
        public string Pulse { get; set; }
        public string Temperature { get; set; }
        public string Respiration { get; set; }
        public string SymptomsTitle { get; set; }
        public string AppointmentDate { get; set; }
        public string PCase { get; set; }
        public string Casualty { get; set; }
        public string Reference { get; set; }
        public string ConsultantDoctor { get; set; }
        public decimal CreditLimit { get; set; }
        public string PaymentMode { get; set; }
        public string OldPatient { get; set; }
        public string LiveConsultation { get; set; }
        public string Note { get; set; }
        public string BedGroup { get; set; }
        public string BedNumber { get; set; }

    }
    #endregion

    #region Pathology 
    public class Category
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string HospitalId { get; set; }
        public string IsActive { get; set; }
    }
    public class SubCategory
    {
        public string SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string HospitalId { get; set; }
        public string IsActive { get; set; }
    }
    public class Pathology
    {
        public string PathologyId { get; set; }
        public string TestName { get; set; }
        public string ShortName { get; set; }
        public string TestType { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string Method { get; set; }
        public string ReportDays { get; set; }
        public string ChargeCategoryId { get; set; }
        public string ChargeCategoryName { get; set; }
        public string CodeId { get; set; }
        public string Code { get; set; }
        public string Charge { get; set; }
        public string TestParameterNameId { get; set; }
        public string ParameterName { get; set; }
        public string ReferenceRange { get; set; }
        public string Unit { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }
    public class PathologyUnit
    {
        public string UnitId { get; set; }
        public string UnitName { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }
    public class PathologyParameter
    {
        public string PId { get; set; }
        public string PName { get; set; }
        public string RefRange { get; set; }
        public string Description { get; set; }
        public string UnitId { get; set; }
        public string UnitName { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }

    public class PathologyTestReport
    {
        public string BillId { get; set; }
        public string PatientId { get; set; }
        public string Name { get; set; }
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string ReportingDate { get; set; }
        public string Description { get; set;}
        public string Attachment { get; set; }
        public string AppliedCharge { get; set; }
    }


    #endregion



    #region Pharmacy 

    public class Medicine
    {
        public string MedicineId { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string MedicineName { get; set; }
        public string MedicineCompany { get; set; }
        public string MedicineComposition { get; set; }
        public string MedicineGroup { get; set; }
        public string Unit { get; set; }
        public string MinLevel { get; set; }
        public string ReOrderLevel { get; set; }
        public string VAT { get; set; }
        public string Packing { get; set; }
        public string VATAC { get; set; }
        public string Note { get; set; }
        public string MedicinePhoto { get; set; }
        public string AddedBy { get; set; }
        public string AddedOn { get; set; }
        public string IsActive { get; set; }
    }

    public class Pharmacy
    {
        public string PharmacyId { get; set; }
        public string PatientId { get; set; }
        public string Name { get; set; }
        public string BillNo { get; set; }
        public string Date { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string MedicineName { get; set; }
        public string MedicineId { get; set; }
        public string BatchNo { get; set; }
        public string BatchId { get; set; }
        public string ExpiryDate { get; set; }
        public string Quantity { get; set; }
        public string AvailableQty { get; set; }
        public string SalePrice { get; set; }
        public string Amount { get; set; }
        public string FullName { get; set; }
        public string EmployeeId { get; set; }
        public string Note { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal NetAmount { get; set; }
        public string IsActive { get; set; }
        public string AddedBy { get; set; }
    }

    public class PharmacyCategory
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string HospitalId { get; set; }
        public string AddedBy { get; set; }
        public string AddedOn { get; set; }
        public string IsActive { get; set; }
    }
    public class PharmacySubCategory
    {
        public string SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string HospitalId { get; set; }
        public string IsActive { get; set; }
    }
    //public class Pharmacy
    //{
    //    public string PathologyId { get; set; }
    //    public string TestName { get; set; }
    //    public string ShortName { get; set; }
    //    public string TestType { get; set; }
    //    public string CategoryId { get; set; }
    //    public string CategoryName { get; set; }
    //    public string SubCategoryId { get; set; }
    //    public string SubCategoryName { get; set; }
    //    public string Method { get; set; }
    //    public string ReportDays { get; set; }
    //    public string Charge { get; set; }
    //    public string AddedBy { get; set; }
    //    public string IsActive { get; set; }
    //}
    public class BillDetails
    {
        public string BillNo { get; set; }
        public string PatientId { get; set; }
        public string Name { get; set; }
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Date { get; set; }
        public string DoctorName { get; set; }
        public string Total { get; set; }


        public string PharmacyId { get; set; }
        
        
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string MedicineName { get; set; }
        public string MedicineId { get; set; }
        public string BatchNo { get; set; }
        public string BatchId { get; set; }
        public string ExpiryDate { get; set; }
        public string Quantity { get; set; }
        public string AvailableQty { get; set; }
        public string SalePrice { get; set; }
        public string Amount { get; set; }
        //public string DoctorName { get; set; }
        public string DoctorId { get; set; }
        public string Note { get; set; }
        //public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal NetAmount { get; set; }

    }

    public class Supplier
    {
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierContact { get; set; }
        public string PersonName { get; set; }
        public string PersonNo { get; set; }
        public string Address { get; set; }
        public string AddedBy { get; set; }
        public string AddedOn { get; set; }
        public string IsActive { get; set; }
    }
    public class PharmacyDosage
    {
        public string DosageId { get; set; }
        public string DName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }
    #endregion



    #region Radiology
    public class RadiologyCategory
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string IsActive { get; set; }
    }

    public class RadiologyChargeCategory
    {
        public string ChargeCategoryId { get; set; }
        public string ChargeCategoryName { get; set; }
        public string IsActive { get; set; }
    }

    public class CodeModel
    {
        public string CodeId { get; set; }
        public string Code { get; set; }
        public string StandardCharge { get; set; }
        public string ChargeCategoryId { get; set; }
        public string ChargeCategoryName { get; set; }
        public string HospitalId { get; set; }
        public string IsActive { get; set; }
    }

    public class Parameter
    {
        public string ParameterId { get; set; }
        public string ParameterName { get; set; }
        public string ReferenceRange { get; set; }
        public string Description { get; set; }
        public string UnitId { get; set; }
        public string UnitName { get; set; }
        public string IsActive { get; set; }
    }
    public class RadiologyUnit
    {
        public string UnitId { get; set; }
        public string UnitName { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }


    public class RadiologyTestReport
    {
        public string BillId { get; set; }
        public string PatientId { get; set; }
        public string Name { get; set; }
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string ReportingDate { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }
        public string AppliedCharge { get; set; }
    }

    #endregion


    #region TPA
    public class TPA
    {
        public string TPAId { get; set; }
        public string TPAName { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }
    public class TPAChargeCategory
    {
        public string CategoryId { get; set; }
        public string ChargeName { get; set; }
        public string Code { get; set; }
        public string StandardCharge { get; set; }
        public string AppliedCharge { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }

    #endregion
    #region Symptoms
    public class Symphead
    {
        public string SympId { get; set; }
        public string Symptomshead { get; set; }
        public string SymptomsType { get; set; }
        public string SympDescription { get; set; }
        public string IsActive { get; set; }
    }
    public class SympType
    {
        public string SympTypeId { get; set; }
        public string SymptomsType { get; set; }
        public string IsActive { get; set; }
    }

    #endregion

    #region TPAManage
    public class TPAManage
    {
        public string TPAId { get; set; }
        public string TPAName { get; set; }
        public string Code { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonPhone { get; set; }
        public string IsActive { get; set; }
    }

    #endregion

    #region Finance
    public class Incomehead
    {
        public string HeadId { get; set; }
        public string HeadName { get; set; }
        public string Description { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }
    public class Expensehead
    {
        public string HeadId { get; set; }
        public string HeadName { get; set; }
        public string Description { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }
    public class IncomeList
    {
        public string Id { get; set; }
        public string HeadId { get; set; }
        public string HeadName { get; set; }
        public string Name { get; set; }
        public string InvoiceNo { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string Attachment { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
    }
    public class ExpenseList
    {
        public string Id { get; set; }
        public string HeadId { get; set; }
        public string HeadName { get; set; }
        public string Name { get; set; }
        public string InvoiceNo { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string Attachment { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
    }
    #endregion


    #region BirthDeath
    public class BirthRecord
    {
        public string FieldId { get; set; }
        public string FieldName { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }
    public class DeathRecord
    {
        public string FieldId { get; set; }
        public string Name { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }
    #endregion

    #region FrontOffice
    public class Purpose
    {
        public string PId { get; set; }
        public string PName { get; set; }
        public string AddedBy { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
    }
    public class ComplainType
    {
        public string CId { get; set; }
        public string CType { get; set; }
        public string AddedBy { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
    }
    public class Source
    {
        public string SId { get; set; }
        public string SName { get; set; }
        public string AddedBy { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
    }
    public class AptPriority
    {
        public string PriorityId { get; set; }
        public string Priority { get; set; }
        public string AddedBy { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
    }

    public class Visitors
    {
        public string VId { get; set; }
        public string VName { get; set; }
        public string Phone { get; set; }
        public string Date { get; set; }
        public string IDCard { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string NOP { get; set; }
        public string Note { get; set; }
        public string Attachment { get; set; }
        public string AddedBy { get; set; }
        public string PId { get; set; }
        public string PName { get; set; }
        public string IsActive { get; set; }
    }

    public class GeneralCall
    {
        public string PId { get; set; }
        public string PName { get; set; }
        public string Phone { get; set; }
        public string Date { get; set; }
        public string NextDate { get; set; }
        public string CallDuration { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string CallType { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }

    public class PostalReceive
    {
        public string Id { get; set; }
        public string FromTitle { get; set; }
        public string ReferenceNo { get; set; }
        public string ToTitle { get; set; }
        public string Date { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public string Attachment { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }

    public class PostalDispatch
    {
        public string Id { get; set; }
        public string FromTitle { get; set; }
        public string ReferenceNo { get; set; }
        public string ToTitle { get; set; }
        public string Date { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public string Attachment { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }

    #endregion


    #region Bed
    public class Floor
    {
        public string FId { get; set; }
        public string Name { get; set; }
        public string AddedBy { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
    }
    public class BedGroup
    {
        public string BGId { get; set; }
        public string GName { get; set; }
        public string FId { get; set; }
        public string Name { get; set; }
        public string AddedBy { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
    }
    public class BedType
    {
        public string TId { get; set; }
        public string Purpose { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }
    public class Bed
    {
        public string BId { get; set; }
        public string BName { get; set; }
        public string TId { get; set; }
        public string Purpose { get; set; }
        public string BGId { get; set; }
        public string GName { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }

    #endregion



    #region Item

    public class AddItemStock
    {
        public string StockId { get; set; }
        public string ItemCategory { get; set; }
        public string ItemCategoryId { get; set; }
        public string Item { get; set; }
        public string ItemId { get; set; }
        public string Supplier { get; set; }
        public string SupplierId { get; set; }
        public string Store { get; set; }
        public string StoreId { get; set; }
        public string Symbol { get; set; }
        public string Quantity { get; set; }
        public string PurchasePrice { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string AttachDocument { get; set; }
        public string IsActive { get; set; }
    }

    public class IssueItem
    {
        public string IssueId { get; set; }
        public string UserType { get; set; }
        public string UserTypeId { get; set; }
        public string IssueTo { get; set; }
        public string IssueToId { get; set; }
        public string IssueBy { get; set; }
        public string IssueDate { get; set; }
        public string ReturnDate { get; set; }
        public string Note { get; set; }
        public string ItemCategory { get; set; }
        public string ItemCategoryId { get; set; }
        public string Item { get; set; }
        public string ItemId { get; set; }
        public string Quantity { get; set; }
        public string IsActive { get; set; }
    }

    public class ItemCategory
    {
        public string CategoryId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }
    public class ItemStore
    {
        public string StoreId { get; set; }
        public string StoreName { get; set; }
        public string StockCode { get; set; }
        public string Description { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }

    public class Item
    {
        public string ItemId { get; set; }
        //public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string CategoryId { get; set; }
        public string ItemCategory { get; set; }
        public string Unit { get; set; }
        public string AvailableQuantity { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
    }


    #endregion


    #region InPatient

    public class InPatient
    {
        public string IPDId { get; set; }
        //Patient
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BP { get; set; }
        public string Pulse { get; set; }
        public string Temperature { get; set; }
        public string Respiration { get; set; }
        //Symptoms
        public string Note { get; set; }
        public string AdmissionDate { get; set; }
        public string Case { get; set; }
        public string Casualty { get; set; }
        public string OldPatient { get; set; }
        //TPA
        public string CreditLimit { get; set; }
        public string Reference { get; set; }
        //Doctor
        //Bed
        public string LiveConsultation { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }
    public class ConsultantRegister
    {
        public string CId { get; set; }
        public string UserId { get; set; }
        public string AppDate { get; set; }
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Instruction { get; set; }
        public string InstructionDate { get; set; }
        public string AddedBy { get; set; }
        //public string IsActive { get; set; }
    }
    public class Diagnosis
    {
        public string DId { get; set; }
        public string PatientId { get; set; }
        public string IPDId { get; set; }
        public string ReportType { get; set; }
        public string ReportDate { get; set; }
        public string Attachment { get; set; }
        public string Description { get; set; }
        //public string AddedBy { get; set; }
        //public string IsActive { get; set; }
    }

    public class Timeline
    {
        public string TId { get; set; }
        public string PatientId { get; set; }
        public string IPDId { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }
        public string Visibility { get; set; }
        //public string AddedBy { get; set; }
        //public string IsActive { get; set; }
    }

    public class Prescription
    {
        public string PId { get; set; }
        public string PatientId { get; set; }
        public string IPDId { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public string Medicine { get; set; }
        public string Dosage { get; set; }
        public string Instruction { get; set; }
        public string PrescriptionNo { get; set; }
        public string Date { get; set; }
        //public string AddedBy { get; set; }
        //public string IsActive { get; set; }
    }


    #endregion

    #region Blood

    public class BloodBankStatus
    {
        public string StatusId { get; set; }
        public string BloodGroup { get; set; }
        public string Status { get; set; }
        public string IsActive { get; set; }
    }
    public class BloodDonor
    {
        public string DonorId { get; set; }
        public string DonorName { get; set; }
        public string AgeYear { get; set; }
        public string AgeMonth { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public string FatherName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string IsActive { get; set; }
    }


    public class DonorBloodDetails
    {
        public string DonorBloodId { get; set; }
        public string DonorId { get; set; }
        public string DonorDate { get; set; }
        public string Lot { get; set; }
        public string BagNo { get; set; }
        public string Quantity { get; set; }
        public string Institution { get; set; }
        public string IsActive { get; set; }
    }
    public class BloodIssueDetails
    {
        public string IssueId { get; set; }
        public string PatientId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string IssueDate { get; set; }
        public string HospitalDoctor { get; set; }
        public string DoctorName { get; set; }
        public string Technician { get; set; }
        public string DonorId { get; set; }
        public string DonorName { get; set; }
        public string Lot { get; set; }
        public string BagNo { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
        public string IsActive { get; set; }
    }

    #endregion

    #region Ambulance
    public class Ambulance
    {
        public string AmbulanceId { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleModel { get; set; }
        public string YearMade { get; set; }
        public string DriverName { get; set; }
        public string DriverLicense { get; set; }
        public string DriverContact { get; set; }
        public string VehicleType { get; set; }
        public string Note { get; set; }
        public string IsActive { get; set; }
    }
    public class AmbulanceCall
    {
        public string AmbulanceCallId { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string ContactNo { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleModelNo { get; set; }
        public string PatientAddress { get; set; }
        public string VehicleModelId { get; set; }
        public string DriverName { get; set; }
        public string Date { get; set; }
        public decimal Amount { get; set; }
        public string IsActive { get; set; }
    }
    #endregion


    #region Reports

    public class DeathReport
    {
        public string DId { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string IPDOPDNo { get; set; }
        public string DeathDate { get; set; }
        public string GuardianName { get; set; }
        public string Report { get; set; }
        public string ReceiverName { get; set; }
        public string IsActive { get; set; }
    }


    public class BirthReport
    {
        public string BId { get; set; }
        public string ChildName { get; set; }
        public string Gender { get; set; }
        public string Weight { get; set; }
        public string IPDOPDNo { get; set; }
        public string BirthDate { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string IsActive { get; set; }
    }

    public class InventoryIssueReport
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string CategoryId { get; set; }
        public string Category { get; set; }
        public string UserTypeId { get; set; }
        public string UserType { get; set; }
        public string IssueDate { get; set; }
        public string ReturnDate { get; set; }
        public string IssueBy { get; set; }
        public string Quantity { get; set; }
    }

    public class ExpiryMedicineReport
    {
        public string MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string BatchNo { get; set; }
        public string MedicineCompany { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string MedicineGroup { get; set; }
        public string ExpiryDate { get; set; }
        public string Quantity { get; set; }
    }

    public class InventoryStockReport
    {
        public string ItemName { get; set; } 
        public string Category { get; set; }
        public string SupplierName { get; set; }
        public string StoreName { get; set; }
        public string AvailableQuantity { get; set; }
        public string Quantity { get; set; }
    }

    public class BloodDonorReport
    {
        public string DonorName { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public string AgeYear { get; set; }
        public string Lot { get; set; }
        public string BagNo { get; set; }
        public string Quantity { get; set; }
        public string DonorDate { get; set; }
    }

    public class AmbulanceCallReport
    {
        public string VehicleNumber { get; set; }
        public string VehicleModel { get; set; }
        public string DriverName { get; set; }
        public string Date { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
    }

    public class PathologyPatientReport
    {
        public string TestName { get; set; }
        public string Description { get; set; }
        public string ChargeCategoryName { get; set; }
        public string AppliedCharge { get; set; }
        public string ReportingDate { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
    }

    #endregion

    public class RadiologyPatientReport
    {
        public string TestName { get; set; }
        public string ChargeCategoryName { get; set; }
        public string ReportingDate { get; set; }
        public string Description { get; set; }
        public string StandardCharge { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
    }

    public class InventoryItemReport
    {
        public string Quantity { get; set; }
        public string PurchasePrice { get; set; }
        public string Date { get; set; }
        public string StoreName { get; set; }
        public string SupplierName { get; set; }
        public string ItemCategory { get; set; }
        public string ItemName { get; set; }
    }

    #region  Hospital Charges
    public class ChargeType
    {
        public string ChargeTypeId { get; set; }
        public string Type { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }
    public class Charge
    {
        public string ChargeId { get; set; }
        public string ChargeType { get; set; }
        public string ChargeTypeId { get; set; }
        public string ChargeCategory { get; set; }
        public string ChargeCategoryId { get; set; }
        public string Code { get; set; }
        public string StandardCharge { get; set; }
        public string Description { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }
    public class ChargeCategory
    {
        public string ChargeCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ChargeType { get; set; }
        public string ChargeTypeId { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }
    public class ConsultCharges
    {
        public string ChargeId { get; set; }
        public string Doctor { get; set; }
        public string DoctorId { get; set; }
        public string StandardCharge { get; set; }
        public string AddedBy { get; set; }
        public string IsActive { get; set; }
    }
    #endregion

    public class OPDCharge
    {
        public string OPDChargeId { get; set; }
        public string OPDId { get; set; }
        public string PatientId { get; set; }
        public string Date { get; set; }
        public string ChargeTypeId { get; set; }
        public string Type { get; set; }
        public string ChargeCategoryId { get; set; }
        public string Name { get; set; }
        public string ChargeId { get; set; }
        public string Code { get; set; }
        public string StandardCharge { get; set; }
        public string AppliedCharge { get; set; }
        
    }

    public class OPDPayment
    {
        public string PaymentId { get; set; }
        public string OPDId { get; set; }
        public string PatientId { get; set; }
        public string Date { get; set; }
        public string Note { get; set; }
        public string PaymentMode { get; set; }
        public string Amount { get; set; }
        public string Attachment { get; set; }
    }

    public class OPDDiagnosis
    {
        public string DiagnosisId { get; set; }
        public string OPDId { get; set; }
        public string PatientId { get; set; }
        public string ReportType { get; set; }
        public string ReportDate { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }
    }





}