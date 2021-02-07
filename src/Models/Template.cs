using System.Collections.Generic;

namespace Communications.Api.Models
{
    public class Template : BaseModel
    {
        public string AccountId { get; set; }
        public string Name { get; set; }
        public string MessageType { get; set; }
        public string ContentType { get; set; }
        public string ContentPattern { get; set; }
        public bool Enabled { get; set; }
        public List<ContentParameter> ContentParameters { get; set; }
    }
}