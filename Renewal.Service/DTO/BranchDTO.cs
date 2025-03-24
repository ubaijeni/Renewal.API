namespace Renewal.Services.DTOs
{
        public class BranchDTO
        {
            public Guid BranchID { get; set; }
            public string BranchName { get; set; }
            public bool IsActive { get; set; }
            public bool Suspend { get; set; }
        }
}
