using System.Collections.Generic;

namespace messenger_webhook.Models
{
    public class Request
    {
        public string Object { get; set; }

        public List<Messages> Entry { get; set; }
    }

    public class Messages
    {
        public List<TheMessage> Messaging { get; set; }
    }

    public class TheMessage
    {
        public string Message { get; set; }
    }
}