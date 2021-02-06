using System.Collections.Generic;

namespace Communications.Api.Models
{
    public class Configuration : BaseModel
    {
        public string AccountId { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
        public List<ConfigurationContract> Contracts { get; set; }
        public bool Enabled { get; set; }
    }
}