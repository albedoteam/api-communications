namespace Communications.Api.Models
{
    public class ConfigurationContract
    {
        public string MessageType { get; set; }
        public int FreeQuota { get; set; }
        public decimal TaxPerMessage { get; set; }
    }
}