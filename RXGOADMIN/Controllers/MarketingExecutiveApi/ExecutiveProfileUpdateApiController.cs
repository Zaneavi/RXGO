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
    public class ExecutiveProfileUpdateApiController : ApiController
    {
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        // GET: api/ExecutiveProfileUpdateApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ExecutiveProfileUpdateApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ExecutiveProfileUpdateApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ExecutiveProfileUpdateApi/5
        public IHttpActionResult Put(string id, [FromBody]MarketingExecutive m)
        {
            m.ExecutiveId = id;
            m.Password = enc.Encrypt(m.Password);
            m.ExecutiveEmail = enc.Encrypt(m.ExecutiveEmail);

            try
            {
                if (dl.InsertExecutive_Sp(m) > 0)
                {
                    return Ok("Executive Profile Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE: api/ExecutiveProfileUpdateApi/5
        public void Delete(int id)
        {
        }
    }
}
