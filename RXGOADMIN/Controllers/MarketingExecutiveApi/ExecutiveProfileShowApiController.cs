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
    public class ExecutiveProfileShowApiController : ApiController
    {
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        // GET: api/ExecutiveProfileShowApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ExecutiveProfileShowApi/5
        public IHttpActionResult Get(string id)
        {
            //List<MarketingExecutive> ExecutiveList = new List<MarketingExecutive>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.Condition1 = id;
            p.OnTable = "ShowProfile";
            ds = dl.Fetch_API_Executive(p);
            MarketingExecutive info = new RXGOADMIN.Models.MarketingExecutive();
            try
            {
                info = new RXGOADMIN.Models.MarketingExecutive()
                {
                    ExecutiveId = ds.Tables[0].Rows[0]["ExecutiveId"].ToString(),
                    ExecutiveName = ds.Tables[0].Rows[0]["ExecutiveName"].ToString(),
                    ExecutiveEmail = enc.Decrypt( ds.Tables[0].Rows[0]["ExecutiveEmail"].ToString()),
                    ExecutivePhone = ds.Tables[0].Rows[0]["ExecutivePhone"].ToString(),
                    ExecutiveAge = ds.Tables[0].Rows[0]["ExecutiveAge"].ToString(),
                    ExecutiveAddress = ds.Tables[0].Rows[0]["ExecutiveAddress"].ToString(),
                    CountryId = ds.Tables[0].Rows[0]["CountryId"].ToString(),
                    CountryName = ds.Tables[0].Rows[0]["CountryName"].ToString(),
                    StateId = ds.Tables[0].Rows[0]["StateId"].ToString(),
                    StateName = ds.Tables[0].Rows[0]["StateName"].ToString(),
                    CityId = ds.Tables[0].Rows[0]["CityId"].ToString(),
                    CityName= ds.Tables[0].Rows[0]["CityName"].ToString(),
                    AdminId= ds.Tables[0].Rows[0]["AdminId"].ToString(),
                    Password= enc.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString()),
                    IsActive= ds.Tables[0].Rows[0]["IsActive"].ToString(),
                };
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok(info);
        }

        // POST: api/ExecutiveProfileShowApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ExecutiveProfileShowApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ExecutiveProfileShowApi/5
        public void Delete(int id)
        {
        }
    }
}
