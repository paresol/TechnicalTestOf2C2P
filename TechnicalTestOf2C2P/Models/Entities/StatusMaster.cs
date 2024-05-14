namespace TechnicalTestOf2C2P.Models.Entities
{
    public class StatusMaster
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Output { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
