using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
//using System.Configuration;
//using System.Text;

namespace RXGOADMIN.Models
{
    public class DLayer
    {
        private string con = @"data source=AVISHEK;initial catalog=hospital;integrated security=true;";


        #region Connection string for Demo
        //private string con = "data source=184.168.47.19;initial catalog=HnsRxgo; user id=HnsRxgo;password=HnsRxgo@357";
        #endregion

        #region Data Access Layer Work
        public string Con
        {
            get
            {

                return con;
            }
        }
        public static byte[] pImage;
        public int Int_Process(String Storp, string[] parametername, string[] parametervalue)
        {
            int a = 0;

            SqlConnection con = new SqlConnection(Con);
            SqlCommand cmd = new SqlCommand(Storp, con);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < parametername.Length; i++)
            {
                if (parametername[i] == "@img")
                {
                    cmd.Parameters.AddWithValue(parametername[i], pImage);
                }
                else
                {
                    cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                }
            }
            con.Open();

            a = cmd.ExecuteNonQuery();
            con.Dispose();
            return a;
        }
        public DataSet Ds_Process(String Storp, string[] parametername, string[] parametervalue)
        {
            try
            {

                SqlConnection con = new SqlConnection(Con);
                SqlCommand cmd = new SqlCommand(Storp, con);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parametername.Length; i++)
                {
                    cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                }
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                da.Dispose();
                con.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                Property.erroCheck = ex.ToString();

                DataSet ds = null;
                return ds;
            }

        }
        public DataSet MyDs_Process(String Storp)
        {

            SqlConnection con = new SqlConnection(Con);
            SqlCommand cmd = new SqlCommand(Storp, con);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            da.Dispose();
            con.Dispose();
            return ds;

        }
        public int ExecNonQuery(String Qry)
        {
            int a = 0;

            SqlConnection con = new SqlConnection(Con);
            SqlCommand cmd = new SqlCommand(Qry, con);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            con.Open();
            a = cmd.ExecuteNonQuery();
            con.Dispose();
            return a;
        }

        #endregion
        #region FetchLogin
        public DataSet FetchAdminLogin(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchAdminLogin_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Marketing Executive
        public int InsertExecutive_Sp(MarketingExecutive m)
        {
            string[] paname = { "@ExecutiveId", "@ExecutiveName", "@ExecutiveEmail", "@ExecutivePhone", "@ExecutiveAge", "@ExecutiveAddress", "@AdminId", "@Password", "@CountryId", "@StateId", "@CityId" };
            string[] pavalue = { m.ExecutiveId, m.ExecutiveName, m.ExecutiveEmail, m.ExecutivePhone, m.ExecutiveAge, m.ExecutiveAddress, m.AdminId, m.Password, m.CountryId, m.StateId, m.CityId };
            return Int_Process("InsertExecutive_Sp", paname, pavalue);
        }
        public DataSet FetchMarketingExecutive_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchMarketingExecutive_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Hospital
        public int InsertHospital_Sp(AdminLogin a)
        {
            string[] pname = { "@HospitalId", "@HospitalName", "@HospitalWebsiteUrl", "@Email", "@Password", "@Phone", "@Address", "@CountryId", "@StateId", "@CityId" };
            string[] pvalue = { a.HospitalId, a.HospitalName, a.HospitalWebsiteUrl, a.Email, a.Password, a.Phone, a.Address, a.CountryId, a.StateId, a.CityId };
            return Int_Process("InsertHospital_Sp", pname, pvalue);
        }
        #endregion
        #region Executive Api
        public DataSet Fetch_API_Executive(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("Fetch_API_Executive", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Fetch User Type List
        public DataSet FetchUserList_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchUserList_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Designation
        public DataSet FetchDesignation_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchDesignation_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Specialist
        public DataSet FetchSpecialist_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchSpecialist_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Department
        public DataSet FetchDepartment_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchDepartment_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion



        
        #region Employee
        public int InsertEmployee_Sp(EmployeeDetails m)
        {
            string[] paname = { "@EmployeeId", "@FullName", "@EmailId", "@Password", "@Phone", "@UserTypeId", "@Salary", "@ProfilePic" };
            string[] pavalue = { m.EmployeeId, m.FullName, m.EmailId, m.Password, m.Phone, m.UserTypeId, m.Salary.ToString(), m.ProfilePic };
            return Int_Process("InsertEmployee_Sp", paname, pavalue);
        }
        public DataSet FetchEmployee_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchEmployee_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int UpdateEmployee_Sp(EmployeeDetails m)
        {
            string[] paname = { "@EmployeeId", "@FullName", "@EmailId", "@Password", "@Phone", "@UserTypeId", "@Salary", "@ProfilePic" };
            string[] pavalue = { m.EmployeeId, m.FullName, m.EmailId, m.Password, m.Phone, m.UserTypeId, m.Salary.ToString(), m.ProfilePic };
            return Int_Process("UpdateEmployee", paname, pavalue);
        }
        public int InsertEmployeePayroll_Sp(EmployeeDetails m)
        {
            string[] paname = { "@Salary", "@EmployeeId" };
            string[] pavalue = { m.Salary.ToString(), m.EmployeeId };
            return Int_Process("InsertEmployeePayroll_Sp", paname, pavalue);
        }
        #endregion
        #region OTP Patient
        public int InsertOtpPatient_Sp(OPDPatient m)
        {
            string[] paname = { "@PatientId", "@Name", "@GuardianName", "@Gender", "@DOB", "@Age", "@Phone", "@Email", "@Remarks", "@BloodGroup", "@MaritalStatus", "@PatientPhoto", "@Address", "@AnyKnownAllergies", "@Height", "@Weight", "@Bp", "@Pulse", "@Temperature", "@Respiration", "@SymptomsTitle", "@AppointmentDate", "@PCase", "@Casualty", "@Reference", "@ConsultantDoctor", "@AppliedCharge", "@PaymentMode", "@OldPatient", "@LiveConsultation", "@Note" };
            string[] pavalue = { m.PatientId, m.Name, m.GuardianName, m.Gender, m.DOB, m.Age, m.Phone, m.Email, m.Remarks, m.BloodGroup, m.MaritalStatus, m.PatientPhoto, m.Address, m.AnyKnownAllergies, m.Height, m.Weight, m.Bp, m.Pulse, m.Temperature, m.Respiration, m.SymptomsTitle, m.AppointmentDate, m.PCase, m.Casualty, m.Reference, m.ConsultantDoctor, m.AppliedCharge.ToString(), m.PaymentMode, m.OldPatient, m.LiveConsultation, m.Note };
            return Int_Process("InsertOtpPatient_Sp", paname, pavalue);
        }
        public DataSet FetchOtpPatient_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchOtpPatient_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region IPD Patient
        public int InsertIpdPatient_Sp(IPDPatient m)
        {
            string[] paname = { "@IPDNo", "@Name", "@GuardianName", "@Gender", "@DOB", "@Age", "@Phone", "@Email", "@Remarks", "@BloodGroup", "@MaritalStatus", "@PatientPhoto", "@Address", "@AnyKnownAllergies", "@Height", "@Weight", "@Bp", "@Pulse", "@Temperature", "@Respiration", "@SymptomsTitle", "@AppointmentDate", "@PCase", "@Casualty", "@Reference", "@ConsultantDoctor", "@CreditLimit", "@PaymentMode", "@OldPatient", "@LiveConsultation", "@Note", "@BedGroup", "@BedNumber" };
            string[] pavalue = { m.IPDNo, m.Name, m.GuardianName, m.Gender, m.DOB, m.Age, m.Phone, m.Email, m.Remarks, m.BloodGroup, m.MaritalStatus, m.PatientPhoto, m.Address, m.AnyKnownAllergies, m.Height, m.Weight, m.Bp, m.Pulse, m.Temperature, m.Respiration, m.SymptomsTitle, m.AppointmentDate, m.PCase, m.Casualty, m.Reference, m.ConsultantDoctor, m.CreditLimit.ToString(), m.PaymentMode, m.OldPatient, m.LiveConsultation, m.Note, m.BedGroup, m.BedNumber };
            return Int_Process("InsertIpdPatient_Sp", paname, pavalue);
        }
        public DataSet FetchIpdPatient_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchIpdPatient_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Pathology
        public int InsertPathologyCategory_Sp(Category m)
        {
            string[] paname = { "@CategoryName", "@HospitalId" };
            string[] pavalue = { m.CategoryName, m.HospitalId };
            return Int_Process("InsertPathologyCategory_Sp", paname, pavalue);
        }
        public DataSet FetchPathologyCategory_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchPathologyCategory_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public int InsertPathologySubCategory_Sp(SubCategory m)
        {
            string[] paname = { "@SubCategoryId", "@SubCategoryName", "@CategoryId", "@HospitalId" };
            string[] pavalue = { m.SubCategoryId, m.SubCategoryName, m.CategoryId, m.HospitalId };
            return Int_Process("InsertPathologySubCategory_Sp", paname, pavalue);
        }
        public DataSet FetchPathologySubCategory_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchPathologySubCategory_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public int InsertPathologyTest_Sp(Pathology m)
        {
            string[] paname = { "@PathologyId", "@TestName", "@ShortName", "@TestType", "@CategoryId", "@SubCategoryId", "@Method", "@ReportDays", "@Charge", "@AddedBy" };
            string[] pavalue = { m.PathologyId, m.TestName, m.ShortName, m.TestType, m.CategoryId, m.SubCategoryId, m.Method, m.ReportDays, m.Charge, m.AddedBy };
            return Int_Process("InsertPathologyTest_Sp", paname, pavalue);
        }
        public DataSet FetchPathologyTest_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchPathologyTest_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertPathologyUnit_Sp(PathologyUnit m)
        {
            string[] paname = { "@UnitId", "@UnitName", "@AddedBy" };
            string[] pavalue = { m.UnitId, m.UnitName, m.AddedBy };
            return Int_Process("InsertPathologyUnit_Sp", paname, pavalue);
        }
        public DataSet FetchPathologyUnit_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchPathologyUnit_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertPathologyParameter_Sp(PathologyParameter m)
        {
            string[] paname = { "@PId", "@PName", "@RefRange", "@Description", "@UnitId", "@AddedBy" };
            string[] pavalue = { m.PId, m.PName, m.RefRange, m.Description, m.UnitId, m.AddedBy };
            return Int_Process("InsertPathologyParameter_Sp", paname, pavalue);
        }
        public DataSet FetchPathologyParameter_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchPathologyParameter_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public int InsertPathologyTestReport_Sp(PathologyTestReport m)
        {
            string[] paname = { "@BillId", "@PatientId", "@EmployeeId", "@ReportingDate", "@Description", "@Attachment", "@AppliedCharge" };
            string[] pavalue = { m.BillId, m.PatientId, m.EmployeeId, m.ReportingDate, m.Description, m.Attachment, m.AppliedCharge };
            return Int_Process("InsertPathologyTestReport_Sp", paname, pavalue);
        }



        public DataSet FetchPathologyReport_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchPathologyReport_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Pharmacy Category
        public int InsertPharmacyCategory_Sp(PharmacyCategory m)
        {
            string[] paname = { "@CategoryId", "@CategoryName", "@AddedBy" };
            string[] pavalue = { m.CategoryId, m.CategoryName, m.AddedBy };
            return Int_Process("InsertPharmacyCategory_Sp", paname, pavalue);
        }
        public DataSet FetchPharmacyCategory_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchPharmacyCategory_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertSupplier_Sp(Supplier s)
        {
            string[] paname = { "@SupplierId", "@SupplierName", "@SupplierContact", "@PersonName", "@PersonNo", "@Address", "@AddedBy" };
            string[] pavalue = { s.SupplierId, s.SupplierName, s.SupplierContact, s.PersonName, s.PersonNo, s.Address, s.AddedBy };
            return Int_Process("InsertSupplier_Sp", paname, pavalue);
        }
        public DataSet FetchSupplier_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchSupplier_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertPharmacyDosage_sp(PharmacyDosage m)
        {
            string[] paname = { "@DosageId", "@DName", "@CategoryId", "@AddedBy" };
            string[] pavalue = { m.DosageId, m.DName, m.CategoryId, m.AddedBy };
            return Int_Process("InsertPharmacyDosage_sp", paname, pavalue);
        }
        public DataSet FetchPharmacyDosage_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchPharmacyDosage_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion


        #region Generate Bill
        public int InsertBillDetails_Sp(BillDetails m)
        {
            string[] paname = { "@BillNo", "@Date", "@PatientName", "@DoctorName", "@Total" };
            string[] pavalue = { m.BillNo, m.Date, m.DoctorName, m.Total };
            return Int_Process("InsertBillDetails_Sp", paname, pavalue);
        }
        public DataSet FetchBillDetails_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchBillDetails_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion


        #region Radiology
        public int InsertRadiologyCategory_Sp(RadiologyCategory m)
        {
            string[] paname = { "@CategoryId", "@CategoryName" };
            string[] pavalue = { m.CategoryId, m.CategoryName };
            return Int_Process("InsertRadiologyCategory_Sp", paname, pavalue);
        }
        public DataSet FetchRadiologyCategory_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchRadiologyCategory_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public int InsertChargeCategory_Sp(RadiologyChargeCategory m)
        {
            string[] paname = { "@ChargeCategoryId", "@ChargeCategoryName" };
            string[] pavalue = { m.ChargeCategoryId, m.ChargeCategoryName };
            return Int_Process("InsertChargeCategory_Sp", paname, pavalue);
        }
        public DataSet FetchChargeCategory_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchChargeCategory_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public int InsertCode_Sp(CodeModel m)
        {
            string[] paname = { "@CodeId", "@Code", "@StandardCharge", "@ChargeCategoryId", "@HospitalId" };
            string[] pavalue = { m.CodeId, m.Code, m.StandardCharge, m.ChargeCategoryId, m.HospitalId };
            return Int_Process("InsertCode_Sp", paname, pavalue);
        }
        public DataSet FetchCode_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchCode_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public int InsertParameter_Sp(Parameter m)
        {
            string[] paname = { "@ParameterId", "@ParameterName", "@ReferenceRange", "@UnitId", "@Description" };
            string[] pavalue = { m.ParameterId, m.ParameterName, m.ReferenceRange, m.UnitId, m.Description };
            return Int_Process("InsertParameter_Sp", paname, pavalue);
        }
        public DataSet FetchParameter_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchParameter_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int InsertRadiologyUnit_Sp(RadiologyUnit m)
        {
            string[] paname = { "@UnitId", "@UnitName", "@AddedBy" };
            string[] pavalue = { m.UnitId, m.UnitName, m.AddedBy };
            return Int_Process("InsertRadiologyUnit_Sp", paname, pavalue);
        }
        public DataSet FetchRadiologyUnit_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchRadiologyUnit_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertRadiologyTestReport_Sp(RadiologyTestReport m)
        {
            string[] paname = { "@BillId", "@PatientId", "@EmployeeId", "@ReportingDate", "@Description", "@Attachment", "@AppliedCharge" };
            string[] pavalue = { m.BillId, m.PatientId, m.EmployeeId, m.ReportingDate, m.Description, m.Attachment, m.AppliedCharge };
            return Int_Process("InsertRadiologyTestReport_Sp", paname, pavalue);
        }



        public DataSet FetchRadiologyReport_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchRadiologyReport_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        #endregion


        #region TPA

        public int InsertTPA_Sp(TPA m)
        {
            string[] paname = { "@TPAId", "@TPAName", "@AddedBy" };
            string[] pavalue = { m.TPAId, m.TPAName, m.AddedBy };
            return Int_Process("InsertTPA_Sp", paname, pavalue);
        }
        public DataSet FetchTPA_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchTPA_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int InsertChargeCat_Sp(TPAChargeCategory m)
        {
            string[] paname = { "@CategoryId", "@ChargeName", "@Code", "@StandardCharge", "@AppliedCharge", "@AddedBy" };
            string[] pavalue = { m.CategoryId, m.ChargeName, m.Code, m.StandardCharge, m.AppliedCharge, m.AddedBy };
            return Int_Process("InsertChargeCat_Sp", paname, pavalue);
        }
        public DataSet FetchChargeCat_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchChargeCat_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        #endregion

        #region Symptoms
        public int InsertSymphead_Sp(Symphead m)
        {
            string[] paname = { "@SympId", "@Symptomshead", "@SymptomsType", "@SympDescription" };
            string[] pavalue = { m.SympId, m.Symptomshead, m.SymptomsType, m.SympDescription };
            return Int_Process("InsertSymphead_Sp", paname, pavalue);
        }
        public DataSet FetchSymphead_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchSymphead_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertSympType_Sp(SympType m)
        {
            string[] paname = { "@SympTypeId", "@SymptomsType" };
            string[] pavalue = { m.SympTypeId, m.SymptomsType };
            return Int_Process("InsertSympType_Sp", paname, pavalue);
        }
        public DataSet FetchSympType_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchSympType_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region TPAManage

        public int InsertTPAManage_Sp(TPAManage m)
        {
            string[] paname = { "@TPAId", "@TPAName", "@Code", "@Phone", "@Address", "@ContactPersonName", "@ContactPersonPhone" };
            string[] pavalue = { m.TPAId, m.TPAName, m.Code, m.Phone, m.Address, m.ContactPersonName, m.ContactPersonPhone };
            return Int_Process("InsertTPAManage_Sp", paname, pavalue);
        }
        public DataSet FetchTPAManage_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchTPAManage_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Finance

        public int InsertIncomehead_Sp(Incomehead m)
        {
            string[] paname = { "@HeadId", "@HeadName", "@Description", "@AddedBy" };
            string[] pavalue = { m.HeadId, m.HeadName, m.Description, m.AddedBy };
            return Int_Process("InsertIncomehead_Sp", paname, pavalue);
        }
        public DataSet FetchIncomehead_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchIncomehead_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertExpensehead_Sp(Expensehead m)
        {
            string[] paname = { "@HeadId", "@HeadName", "@Description", "@AddedBy" };
            string[] pavalue = { m.HeadId, m.HeadName, m.Description, m.AddedBy };
            return Int_Process("InsertExpensehead_Sp", paname, pavalue);
        }
        public DataSet FetchExpensehead_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchExpensehead_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertIncomeList_Sp(IncomeList m)
        {
            string[] paname = { "@Id", "@HeadId", "@Name", "@InvoiceNo", "@Date", "@Amount", "@Attachment", "@Description" };
            string[] pavalue = { m.Id, m.HeadId, m.Name, m.InvoiceNo, m.Date, m.Amount, m.Attachment, m.Description };
            return Int_Process("InsertIncomeList_Sp", paname, pavalue);
        }
        public DataSet FetchIncomeList_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchIncomeList_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertExpenseList_Sp(ExpenseList m)
        {
            string[] paname = { "@Id", "@HeadId", "@Name", "@InvoiceNo", "@Date", "@Amount", "@Attachment", "@Description" };
            string[] pavalue = { m.Id, m.HeadId, m.Name, m.InvoiceNo, m.Date, m.Amount, m.Attachment, m.Description };
            return Int_Process("InsertExpenseList_Sp", paname, pavalue);
        }
        public DataSet FetchExpenseList_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchExpenseList_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion


        public DataSet FetchOpdPatient_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchOpdPatient_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        #region BirthDeath
        public int InsertBirthRecord_Sp(BirthRecord m)
        {
            string[] paname = { "@FieldId", "@FieldName", "@AddedBy" };
            string[] pavalue = { m.FieldId, m.FieldName, m.AddedBy };
            return Int_Process("InsertBirthRecord_Sp", paname, pavalue);
        }
        public DataSet FetchBirthRecord_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchBirthRecord_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertDeathRecord_Sp(DeathRecord m)
        {
            string[] paname = { "@FieldId", "@Name", "@AddedBy" };
            string[] pavalue = { m.FieldId, m.Name, m.AddedBy };
            return Int_Process("InsertDeathRecord_Sp", paname, pavalue);
        }
        public DataSet FetchDeathRecord_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchDeathRecord_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region FrontOffice
        public int InsertPurpose_Sp(Purpose m)
        {
            string[] paname = { "@PId", "@PName", "@Description", "@AddedBy" };
            string[] pavalue = { m.PId, m.PName, m.Description, m.AddedBy };
            return Int_Process("InsertPurpose_Sp", paname, pavalue);
        }
        public DataSet FetchPurpose_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchPurpose_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public int InsertComplainType_Sp(ComplainType m)
        {
            string[] paname = { "@CId", "@CType", "@Description", "@AddedBy" };
            string[] pavalue = { m.CId, m.CType, m.Description, m.AddedBy };
            return Int_Process("InsertComplainType_Sp", paname, pavalue);
        }
        public DataSet FetchComplainType_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchComplainType_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertFrontSource_Sp(Source m)
        {
            string[] paname = { "@SId", "@SName", "@Description", "@AddedBy" };
            string[] pavalue = { m.SId, m.SName, m.Description, m.AddedBy };
            return Int_Process("InsertFrontSource_Sp", paname, pavalue);
        }
        public DataSet FetchFrontSource_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchFrontSource_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertFrontAptPriority_Sp(AptPriority m)
        {
            string[] paname = { "@PriorityId", "@Priority", "@Description", "@AddedBy" };
            string[] pavalue = { m.PriorityId, m.Priority, m.AddedBy, m.Description };
            return Int_Process("InsertFrontAptPriority_Sp", paname, pavalue);
        }
        public DataSet FetchFrontAptPriority_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchFrontAptPriority_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertVisitors_Sp(Visitors m)
        {
            string[] paname = { "@VId", "@VName", "@Phone", "@Date", "@IDCard", "@InTime", "@OutTime", "@NOP", "@Note", "@Attachment", "@PId", "@AddedBy" };
            string[] pavalue = { m.VId, m.VName, m.Phone, m.Date, m.IDCard, m.InTime, m.OutTime, m.NOP, m.Note, m.Attachment, m.PId, m.AddedBy };
            return Int_Process("InsertVisitors_Sp", paname, pavalue);
        }
        public DataSet FetchVisitors_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchVisitors_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertGeneralCall_Sp(GeneralCall m)
        {
            string[] paname = { "@PId", "@PName", "@Phone", "@Date", "@NextDate", "@Note", "@Description", "@CallDuration", "@CallType", "@AddedBy" };
            string[] pavalue = { m.PId, m.PName, m.Phone, m.Date, m.NextDate, m.Note, m.Description, m.CallDuration, m.CallType, m.AddedBy };
            return Int_Process("InsertGeneralCall_Sp", paname, pavalue);
        }
        public DataSet FetchGeneralCall_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchGeneralCall_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertPostalReceive_Sp(PostalReceive m)
        {
            string[] paname = { "@Id", "@FromTitle", "@ReferenceNo", "@ToTitle", "@Date", "@Address", "@Note", "@Attachment", "@AddedBy" };
            string[] pavalue = { m.Id, m.FromTitle, m.ReferenceNo, m.ToTitle, m.Date, m.Address, m.Note, m.Attachment, m.AddedBy };
            return Int_Process("InsertPostalReceive_Sp", paname, pavalue);
        }
        public DataSet FetchPostalReceive_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchPostalReceive_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertPostalDispatch_Sp(PostalDispatch m)
        {
            string[] paname = { "@Id", "@FromTitle", "@ReferenceNo", "@ToTitle", "@Date", "@Address", "@Note", "@Attachment", "@AddedBy" };
            string[] pavalue = { m.Id, m.FromTitle, m.ReferenceNo, m.ToTitle, m.Date, m.Address, m.Note, m.Attachment, m.AddedBy };
            return Int_Process("InsertPostalDispatch_Sp", paname, pavalue);
        }
        public DataSet FetchPostalDispatch_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchPostalDispatch_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Bed
        public int InsertFloor_Sp(Floor m)
        {
            string[] paname = { "@FId", "@Name", "@Description", "@AddedBy" };
            string[] pavalue = { m.FId, m.Name, m.Description, m.AddedBy };
            return Int_Process("InsertFloor_Sp", paname, pavalue);
        }
        public DataSet FetchFloor_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchFloor_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertBedGroup_Sp(BedGroup m)
        {
            string[] paname = { "@BGId", "@GName", "@Description", "@FId", "@AddedBy" };
            string[] pavalue = { m.BGId, m.GName, m.Description, m.FId, m.AddedBy };
            return Int_Process("InsertBedGroup_Sp", paname, pavalue);
        }
        public DataSet FetchBedGroup_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchBedGroup_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertBedType_Sp(BedType m)
        {
            string[] paname = { "@TId", "@Purpose", "@AddedBy" };
            string[] pavalue = { m.TId, m.Purpose, m.AddedBy };
            return Int_Process("InsertBedType_Sp", paname, pavalue);
        }
        public DataSet FetchBedType_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchBedType_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public int InsertBed_Sp(Bed m)
        {
            string[] paname = { "@BId", "@BName", "@TId", "@BGId", "@AddedBy" };
            string[] pavalue = { m.BId, m.BName, m.TId, m.BGId, m.AddedBy };
            return Int_Process("InsertBed_Sp", paname, pavalue);
        }
        public DataSet FetchBed_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchBed_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region AddStaff

        public int InsertStaffRecord_Sp(PharmacyCategory m)
        {
            string[] paname = { "@CategoryId", "@CategoryName", "@AddedBy" };
            string[] pavalue = { m.CategoryId, m.CategoryName, m.AddedBy };
            return Int_Process("InsertStaffRecord_Sp", paname, pavalue);
        }
        public DataSet FetchStaffRecord_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchStaffRecord_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion


        #region Patient
        public DataSet FetchPatient_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchPatient_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion




        #region InPatient
        public int InsertInPatient_Sp(InPatient m)
        {
            string[] paname = { "@IPDId", "@Height", "@Weight", "@BP", "@Pulse", "@Temperature", "@Respiration", "@Note", "@AddedBy" };
            string[] pavalue = { m.IPDId, m.Height, m.Weight, m.BP, m.Pulse, m.Temperature, m.Respiration, m.Note, m.AddedBy };
            return Int_Process("InsertInPatient_Sp", paname, pavalue);
        }
        public DataSet FetchInPatient_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchInPatient_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public int InsertInPatientConsultant_Sp(ConsultantRegister m)
        {
            string[] paname = { "@CId", "@UserId", "@AppDate", "@EmployeeId", "@Instruction", "@InstructionDate", "@AddedBy" };
            string[] pavalue = { m.CId, m.UserId, m.AppDate, m.EmployeeId, m.Instruction, m.InstructionDate, m.AddedBy };
            return Int_Process("InsertInPatientConsultant_Sp", paname, pavalue);
        }
        public DataSet FetchInPatientConsultant_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchInPatientConsultant_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertDiagnosis_Sp(Diagnosis m)
        {
            string[] paname = { "@DId", "@PatientId", "@IPDId", "@ReportType", "@ReportDate", "@Attachment", "@Description" };
            string[] pavalue = { m.DId, m.PatientId, m.IPDId, m.ReportType, m.ReportDate, m.Attachment, m.Description };
            return Int_Process("InsertDiagnosis_Sp", paname, pavalue);
        }
        public DataSet FetchDiagnosis_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchDiagnosis_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int InsertTimeline_Sp(Timeline m)
        {
            string[] paname = { "@TId", "@PatientId", "@IPDId", "@Title", "@Date", "@Description", "@Attachment", "@Visibility" };
            string[] pavalue = { m.TId, m.PatientId, m.IPDId, m.Title, m.Date, m.Description, m.Attachment, m.Visibility };
            return Int_Process("InsertTimeline_Sp", paname, pavalue);
        }
        public DataSet FetchTimeline_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchTimeline_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertPrescription_Sp(Prescription m)
        {
            string[] paname = { "@PId", "@PatientId", "@IPDId", "@CategoryId", "@Header", "@Footer", "@Medicine", "@Dosage", "@Instruction", "@PrescriptionNo", "@Date" };
            string[] pavalue = { m.PId, m.PatientId, m.IPDId, m.CategoryId, m.Header, m.Footer, m.Medicine, m.Dosage, m.Instruction, m.PrescriptionNo, m.Date };
            return Int_Process("InsertPrescription_Sp", paname, pavalue);
        }
        public DataSet FetchPrescription_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchPrescription_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion


        #region Reports
        public DataSet GetDeathReport_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("GetDeathReport_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public DataSet GetBirthReport_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("GetBirthReport_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public DataSet GetIncomeReport_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("GetIncomeReport_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetExpenseReport_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("GetExpenseReport_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetBillReport_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("GetBillReport_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetBloodIssueReport_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("GetBloodIssueReport_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetInventoryIssueReport_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("GetInventoryIssueReport_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public DataSet GetExpiryMedicineReport_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("GetExpiryMedicineReport_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetInventoryStockReport_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("GetInventoryStockReport_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetBloodDonorReport_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("GetBloodDonorReport_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetAmbulanceCallReport_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("GetAmbulanceCallReport_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet FetchPathologyPatientReport_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchPathologyPatientReport_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet FetchRadiologyPatientReport_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchRadiologyPatientReport_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetInventoryItemReport_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("GetInventoryItemReport_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion


        #region OPD

        public int InsertOPDCharge_Sp(OPDCharge m)
        {
            string[] paname = { "@OPDChargeId", "@OPDId", "@PatientId", "@Date", "@ChargeTypeId", "@ChargeCategoryId", "@ChargeId", "@StandardCharge" , "@AppliedCharge" };
            string[] pavalue = { m.OPDChargeId, m.OPDId, m.PatientId, m.Date,  m.ChargeTypeId, m.ChargeCategoryId, m.ChargeId, m.StandardCharge, m.AppliedCharge };
            return Int_Process("InsertOPDCharge_Sp", paname, pavalue);
        }
        public DataSet FetchOPDCharge_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchOPDCharge_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public int InsertOPDPayment_Sp(OPDPayment m)
        {
            string[] paname = { "@PaymentId", "@OPDId", "@PatientId", "@Date", "@Note", "@PaymentMode", "@Amount", "@Attachment" };
            string[] pavalue = { m.PaymentId, m.OPDId, m.PatientId, m.Date, m.Note, m.PaymentMode, m.Amount, m.Attachment };
            return Int_Process("InsertOPDPayment_Sp", paname, pavalue);
        }
        public DataSet FetchOPDPayment_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchOPDPayment_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public int InsertOPDDiagnosis_Sp(OPDDiagnosis m)
        {
            string[] paname = { "@DiagnosisId", "@OPDId", "@PatientId", "@ReportType", "@ReportDate", "@Description", "@Attachment" };
            string[] pavalue = { m.DiagnosisId, m.OPDId, m.PatientId, m.ReportType, m.ReportDate, m.Description, m.Attachment };
            return Int_Process("InsertOPDDiagnosis_Sp", paname, pavalue);
        }
        public DataSet FetchOPDDiagnosis_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchOPDDiagnosis_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion



    }
}