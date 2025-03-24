using Renewal.DataHub.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Renewal.Service.DTO
{
    public class AmountReceiveDTO
    {
        [Key]
        public Guid AmountreceivedId { get; set; }
        public Guid POId { get; set; }
        public string InvoiceNo { get; set; }
        public string PaymentDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amountreceived { get; set; }
        [NotMapped] // Ensure this property is not mapped to the database
        public decimal BalanceAmount { get; set; }
        [ForeignKey("POId")]
        public PODetail PODetail { get; set; }
    }
}
