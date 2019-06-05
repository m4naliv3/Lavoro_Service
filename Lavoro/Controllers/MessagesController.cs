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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MessagesController : ApiController
    {
        // GET: api/Messages
        public HttpResponseMessage Get()
        {
            List<Message> messageList = new List<Message>();
            // Return all of the messages back to the Front End
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["LavoroDB"].ConnectionString))
            {
                var result = db.Query(@"
                    SELECT *
                    FROM lavoro_dev.dbo.MessageHistory
                ").ToList();
                foreach (var r in result)
                {
                    Message m = new Message
                    {
                        ID = r.ID,
                        ConversationID = r.ConversationID,
                        MessageText = r.MessageText,
                        Author = r.Author,
                        Direction = r.Direction,
                        SentDate = r.SentDate
                    };
                    messageList.Add(m);
                }
            }
            var response = JsonConvert.SerializeObject(messageList);
            return new HttpResponseMessage() { Headers = {  }, Content = new StringContent(response) };
        }

        // POST: api/Messages
        public void Post([FromBody]List<Message> messages)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["LavoroDB"].ConnectionString))
            {
                foreach (Message m in messages)
                {
                    // Connect to DB and insert each one individually
                    string sql = @"
                    INSERT INTO lavoro_dev.dbo.MessageHistory
                    (
                        ConversationID, 
                        MessageText, 
                        Author, 
                        Direction, 
                        SentDate
                    )
                    VALUES
                    (
                        @ConversationID, 
                        @MessageText, 
                        @Author, 
                        @Direction, 
                        @SentDate
                    )";
                    db.ExecuteScalar(sql, m);
                }
            }
        }
            
        // PUT: api/Messages/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Messages/5
        public void Delete(int id)
        {
        }
    }
}
