using System.Xml.Serialization;

namespace TechnicalTestOf2C2P.Models.Transactions
{
    [XmlRoot("Transactions")]
    public class GetXmlTransactionModel
    {
        [XmlElement("Transaction")]
        public List<Transaction> TransactionList { get; set; }
    }

    public class Transaction
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        public DateTime? TransactionDate { get; set; }

        public PaymentDetails PaymentDetails { get; set; }

        public string Status { get; set; }
    }

    public class PaymentDetails
    {
        public decimal? Amount { get; set; }

        public string CurrencyCode { get; set; }
    }
}
