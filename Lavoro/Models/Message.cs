using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lavoro.Models
{
    public class Message
    {
        public int ID { get; set; }
        public int ConversationID { get; set; }
        public string MessageText { get; set; }
        public string Author { get; set; }
        public bool Direction { get; set; }
        public DateTime SentDate { get; set; }
    }
}