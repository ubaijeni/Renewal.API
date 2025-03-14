using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Renewal.DataHub.Models.Domain
{
    public class PettyCashTransaction
    {
        [Key]
        public Guid TransactionID { get; set; }
        [Required]
        public Guid BranchID { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        public string PaidTo { get; set; }
        public string Purpose { get; set; }
        public string ApprovedBy { get; set; }
        [Required]
        public string TransactionType { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? CreatedBy { get; set; }

        // Navigation Property
        public Branch Branch { get; set; }
    }
}
