using RXGOADMIN.Helpers;
using RXGOADMIN.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RXGOADMIN.Controllers.MarketingExecutiveApi
{
    public class ExecutiveForgetPasswordApiController : ApiController
    {
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        // GET: api/ExecutiveForgetPasswordApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ExecutiveForgetPasswordApi/5
        public string Get(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();

            p.Condition1 = id;
            p.OnTable = "ForgetPassword";
            ds = dl.Fetch_API_Executive(p);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return "Your password is " + enc.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString());
            }
            else
            {
                return "No executive found";
            }
            //catch (Exception e)
            //{
            //    return "Not found";
            //}
        }

        // POST: api/ExecutiveForgetPasswordApi
        //public string Post([FromBody]MarketingExecutive m)
        //{
        //    Property p = new Property();
        //    DataSet ds = new DataSet();
            
        //    p.OnTable = "ForgetPassword";
        //    ds = dl.Fetch_API_Executive(p);
        //    try
        //    {
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            return "Your password is" + enc.Decrypt(m.Password);
        //        }
        //        else
        //        {
        //            return "No executive found";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return "Not found";
        //    }
        //}

        // PUT: api/ExecutiveForgetPasswordApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ExecutiveForgetPasswordApi/5
        public void Delete(int id)
        {
        }
    }
}
