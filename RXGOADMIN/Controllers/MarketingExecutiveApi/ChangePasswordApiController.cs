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
    public class ChangePasswordApiController : ApiController
    {
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        // GET: api/ChangePasswordApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ChangePasswordApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ChangePasswordApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ChangePasswordApi/5
        public string Put(string id, [FromBody]MarketingExecutive m)
        {
            Property p = new Property();
            DataSet ds = new DataSet();

            m.Password= enc.Encrypt(m.Password);
            m.ExecutiveEmail = enc.Encrypt(m.ExecutiveEmail);
            m.ExecutiveId = id;

            try
            {
                if (dl.InsertExecutive_Sp(m) > 0)
                {
                    return "Your Password Is Updated";
                }
            }
            catch (Exception ex)
            {
                return "Not found";
            }
            return "Ok";
        }

        // DELETE: api/ChangePasswordApi/5
        public void Delete(int id)
        {
        }
    }
}
