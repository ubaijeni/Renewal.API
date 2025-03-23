using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Renewal.DataHub.Models.Domain
{
    public class TransactionDetails
    {
        [Key]
        public Guid TransactionId { get; set; }

        [ForeignKey("Renewal")]
        public Guid? RenewalId { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? CategoryId { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string? Validity { get; set; }
        public string? RenewalDate { get; set; }
        public decimal? Amount { get; set; }
        public int Remider { get; set; }
        public string? AlertTo { get; set; }
        public int Status { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Suspend { get; set; }
        public RenewalValue Renewal { get; set; }
    }
}
