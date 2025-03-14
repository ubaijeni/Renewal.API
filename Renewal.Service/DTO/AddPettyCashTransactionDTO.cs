using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Renewal.Services.DTOs
{
    public class AddPettyCashTransactionDTO
    {
        public DateTime TransactionDate { get; set; }
        [Required(ErrorMessage = "PaidTo is required.")]
        [JsonPropertyName("PaidTo")]
        public string PaidTo { get; set; }
        public string Purpose { get; set; }
        public string ApprovedBy { get; set; }
        public Guid BranchID { get; set; }
        public decimal Amount { get; set; }
        [Required]
        [RegularExpression("^(Credit|Debit)$", ErrorMessage = "TransactionType must be either 'Credit' or 'Debit'.")]
        public string TransactionType { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int? CreatedBy { get; set; }   
    }
}

