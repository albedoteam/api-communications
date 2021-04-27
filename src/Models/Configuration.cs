namespace Communications.Api.Models
{
    using System;
    using System.Collections.Generic;

    public class Configuration
    {
        public string Id { get; set; }

        public string AccountId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Provider { get; set; }
        public List<ConfigurationContract> Contracts { get; set; }
        public bool Enabled { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}