using System.ComponentModel.DataAnnotations;

namespace Renewal.Service.DTO
{
    public class AddClientDTO
    {
        [Required]
        public string ClientName { get; set; }
        public bool? Isactive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Suspend { get; set; }

    }
}
