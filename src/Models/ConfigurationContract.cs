namespace Communications.Api.Models
{
    using AlbedoTeam.Communications.Contracts.Common;

    public class ConfigurationContract
    {
        public MessageType MessageType { get; set; }
        public FromAddress From { get; set; }
        public int FreeQuota { get; set; }
        public decimal TaxPerMessage { get; set; }
    }
}