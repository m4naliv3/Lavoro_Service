using System.Web.Http;
using Twilio.TwiML;
using Twilio.TwiML.Messaging;

namespace Lavoro.Controllers
{
    public class RoutingController : ApiController
    {
        // GET: api/Routing/5
        public string Get(int channel)
        {
            return "value";
        }

        // POST: api/Routing
        public string Post([FromBody]string value)
        {
            MessagingResponse response = new MessagingResponse();
            Message message = new Message();
            message.From = "6613494046";
            message.To = "6615930958";
            message.BodyAttribute = "Hello World!";
            response.Append(message);
            
            return response.ToString();
        }
    }
}
