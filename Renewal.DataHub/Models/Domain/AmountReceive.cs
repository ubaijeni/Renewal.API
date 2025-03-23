using Renewal.DataHub.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class AmountReceive
{
    [Key]
    public Guid AmountreceivedId { get; set; }

    [ForeignKey("PODetail")] // Correct the ForeignKey reference
    public Guid POId { get; set; }

    public string InvoiceNo { get; set; }

    public DateTime PaymentDate { get; set; } // Use DateTime instead of string

    [Column(TypeName = "decimal(18,2)")]
    public decimal Amountreceived { get; set; }

    [NotMapped] // Ensure this property is not mapped to the database
    public decimal BalanceAmount { get; set; }

    // Navigation Property
    public virtual PODetail PODetail { get; set; }
}
