using System;

namespace WebForUsers.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Topic { get; set; }

        public string Text { get; set; }

        public DateTime Received { get; set; }

        public int? SenderUserId { get; set; }

        public User SenderUser { get; set; }

        public int? ReceiverUserId { get; set; }

        public User ReceiverUser { get; set; }
    }
}
