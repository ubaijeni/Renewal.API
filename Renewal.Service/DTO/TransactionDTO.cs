namespace Renewal.Service.DTO
{
    public class TransactionDTO
    {
        public Guid TransactionId { get; set; }
        public Guid? TrenewalId { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? CategoryId { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string? Validity { get; set; }
        public string? RenewalDate { get; set; }
        public decimal? Amount { get; set; }
        public int? Reminder { get; set; }
        public string? AlterTo { get; set; }
        public int? Status { get; set; }
        public bool? Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? Suspend { get; set; }

    }
}
