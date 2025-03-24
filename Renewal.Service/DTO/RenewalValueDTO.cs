namespace Renewal.Service.DTO
{
    public class RenewalValueDTO
    {
        public Guid RenewalId { get; set; }
        public Guid? BranchId { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Valitity { get; set; }
        public string Renewaldata { get; set; }
        public decimal? Amount { get; set; }
        public int Reminder { get; set; }
        public string AlterTo { get; set; }
        public int Status { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Suspend { get; set; }
    }
}
