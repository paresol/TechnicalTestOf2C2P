namespace TechnicalTestOf2C2P.Models.Entities
{
    public class Transactions
    {
        public string Id { get; set; }
        public decimal? Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public DateTime? TransactionDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
