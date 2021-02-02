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
    public class ExecutiveLoginApiController : ApiController
    {
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        // GET: api/ExecutiveLoginApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ExecutiveLoginApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ExecutiveLoginApi
        public string Post([FromBody]MarketingExecutive m)
        {
            Property p = new Property();
            DataSet ds = new DataSet();

            p.Condition1 = enc.Encrypt(m.ExecutiveEmail);
            p.Condition2 = enc.Encrypt(m.Password);
            p.OnTable = "ExecutiveLogin";
            ds = dl.Fetch_API_Executive(p);
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return "Authenticate User";
                }
                else
                {
                    return "Not Authenticate User";
                }
            }
            catch(Exception e)
            {
                return "Not login";
            }
        }

        // PUT: api/ExecutiveLoginApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ExecutiveLoginApi/5
        public void Delete(int id)
        {
        }
    }
}
