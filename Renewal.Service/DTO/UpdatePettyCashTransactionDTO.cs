using System.ComponentModel.DataAnnotations;

namespace Renewal.Services.DTOs
{
    public class UpdatePettyCashTransactionDTO
    {
        public Guid TransactionID { get; set; }
        public string PaidTo { get; set; }
        public string Purpose { get; set; }
        public string ApprovedBy { get; set; }
        [Required]
        [RegularExpression("^(Credit|Debit)$", ErrorMessage = "TransactionType must be either 'Credit' or 'Debit'.")]
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string BranchName { get; set; }
    }

}


