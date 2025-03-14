namespace Renewal.Services.DTOs
{
    public class PettyCashTransactionDTO
    {
        public Guid TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string PaidTo { get; set; }
        public string Purpose { get; set; }
        public string ApprovedBy { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string BranchName { get; set; }
        public decimal? CashIn
        {
            get
            {
                return TransactionType.Equals("Credit", StringComparison.OrdinalIgnoreCase) ? Amount : (decimal?)null;
            }
        }

        // Calculated property for CashOut
        public decimal? CashOut
        {
            get
            {
                return TransactionType.Equals("Debit", StringComparison.OrdinalIgnoreCase) ? Amount : (decimal?)null;
            }
        }
        public decimal BalanceAmount { get; set; }
    }
}

