namespace Communications.Api.Models
{
    using System;
    using System.Collections.Generic;

    public class Template
    {
        public string Id { get; set; }

        public string AccountId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Subject { get; set; }
        public string MessageType { get; set; }
        public string ContentType { get; set; }
        public string ContentPattern { get; set; }
        public bool Enabled { get; set; }
        public List<ContentParameter> ContentParameters { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}