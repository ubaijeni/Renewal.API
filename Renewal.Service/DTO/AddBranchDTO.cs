using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renewal.Services.DTOs
{
    public class AddBranchDTO
    {
        public string BranchName { get; set; }
        public bool IsActive { get; set; }
        public bool Suspend { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
