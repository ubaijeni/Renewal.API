namespace Renewal.Services.DTOs
{
    public class UpdateBranchDTO
    {
        public Guid BranchID { get; set; }
        public string BranchName { get; set; }
        public bool IsActive { get; set; }
        public bool Suspend { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
    