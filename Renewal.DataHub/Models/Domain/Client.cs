using System.ComponentModel.DataAnnotations;

namespace Renewal.DataHub.Models.Domain
{
    public class Client
    {
        [Key]
        public Guid ClientId { get; set; }  
        public string ClientName{ get; set; }
        public bool? Isactive { get; set; }  
        public int? CreatedBy { get; set; }  
        public DateTime? CreatedDate { get; set; }  
        public int? UpdatedBy { get; set; } 
        public DateTime? UpdatedDate { get; set; }  
        public int? Suspend { get; set; }

       // public ICollection<PODetail> PODetails { get; set; } = new List<PODetail>();

    }
}
