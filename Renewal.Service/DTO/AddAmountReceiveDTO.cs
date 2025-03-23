using System.ComponentModel.DataAnnotations.Schema;

public class AddAmountReceiveDTO
{
    public Guid POId { get; set; }
    public string InvoiceNo { get; set; }
    public DateTime PaymentDate { get; set; }  // ✅ Changed to DateTime
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amountreceived { get; set; }
    [NotMapped]
    public decimal BalanceAmount { get; set; }
}
