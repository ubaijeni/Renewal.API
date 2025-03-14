using System.ComponentModel.DataAnnotations;

namespace Renewal.DataHub.Models.Domain
{
    public class Branch
    {
        [Key]
        public Guid BranchID { get; set; }
        [Required]
        public string BranchName { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Suspend { get; set; }

        // Navigation Property
        public ICollection<PettyCashTransaction> PettyCashTransaction { get; set; }
    }
}
