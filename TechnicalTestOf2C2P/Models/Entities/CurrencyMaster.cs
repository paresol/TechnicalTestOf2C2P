namespace TechnicalTestOf2C2P.Models.Entities
{
    public class CurrencyMaster
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
