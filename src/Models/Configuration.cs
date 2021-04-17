namespace Communications.Api.Models
{
    using System.Collections.Generic;

    public class Configuration : BaseModel
    {
        public string AccountId { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
        public List<ConfigurationContract> Contracts { get; set; }
        public bool Enabled { get; set; }
    }
}