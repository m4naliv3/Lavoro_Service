using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lavoro.Models
{
    public class Conversation
    {
        public int ID { get; set; }
        public string CallerNo { get; set; }
        public string InboundNo { get; set; }
        public int ContactID { get; set; }
        public int ChannelTypeID { get; set; }
    }
}