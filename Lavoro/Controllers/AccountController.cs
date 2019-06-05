using Dapper;
using Lavoro.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Lavoro.Controllers
{
    public class AccountController : ApiController
    {
        // GET: api/Account/5
        public HttpResponseMessage Get(int id)
        {
            Account account = new Account();
            // Return all of the messages back to the Front End
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["LavoroDB"].ConnectionString))
            {
                string sql = @"
                    SELECT *
                    FROM lavoro_dev.dbo.UserAccounts
                    WHERE ID = @ID
                ";
                account = db.Query<Account>(sql, new { ID = id }).FirstOrDefault();
            }
            var response = JsonConvert.SerializeObject(account);
            return new HttpResponseMessage() { Headers = { }, Content = new StringContent(response) };
        }

        // POST: api/Account
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Account/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Account/5
        public void Delete(int id)
        {
        }
    }
}
