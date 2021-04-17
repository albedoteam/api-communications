namespace Communications.Api.Models
{
    using System;
    using System.Collections.Generic;

    public class MessageLog : BaseModel
    {
        public string AccountId { get; set; }
        public string Provider { get; set; }
        public string MessageType { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string ContentType { get; set; }
        public string Content { get; set; }
        public List<DestinationAddress> Destinations { get; set; }
        public DateTime? SentAt { get; set; }
        public string Status { get; set; }
        public string DetailMessage { get; set; }
    }
}