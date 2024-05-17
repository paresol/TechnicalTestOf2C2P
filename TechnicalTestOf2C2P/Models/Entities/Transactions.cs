using System.ComponentModel.DataAnnotations;

namespace TechnicalTestOf2C2P.Models.Entities
{
    public class Transactions
    {
        [Required(ErrorMessage = "Transaction Id is invalid")]
        [StringLength(50, ErrorMessage = "Transaction Id can't be longer than 50 characters.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Amount is invalid")]
        public decimal? Amount { get; set; }

        [Required(ErrorMessage = "Currency Code is invalid")]
        public string Currency { get; set; }

        [Required(ErrorMessage = "Status is invalid")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Transaction Date is invalid")]
        public DateTime? TransactionDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
