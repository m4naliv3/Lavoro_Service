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
    public class ContactsController : ApiController
    {
        // GET: api/Contacts
        public HttpResponseMessage Get(int id)
        {
            List<Contact> contactList = new List<Contact>();
            // Return all of the messages back to the Front End
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["LavoroDB"].ConnectionString))
            {
                string sql = @"
                    SELECT *
                    FROM lavoro_dev.dbo.Contacts
                    WHERE AccountID = @ID
                ";
                var result = db.Query<Contact>(sql, new { ID = id }).ToList();
                foreach (var r in result)
                {
                    Contact c = new Contact
                    {
                        ID = r.ID,
                        ContactName = r.ContactName,
                        Email = r.Email,
                        PhoneNumber = r.PhoneNumber,
                        ContactImage = r.ContactImage,
                        Company = r.Company,
                        Favorite = r.Favorite,
                        AccountID = r.AccountID,
                        ProviderID = r.ProviderID
                    };
                    contactList.Add(c);
                }
            }
            var response = JsonConvert.SerializeObject(contactList);
            return new HttpResponseMessage() { Headers = { }, Content = new StringContent(response) };
        }

        // POST: api/Contacts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Contacts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contacts/5
        public void Delete(int id)
        {
        }
    }
}
