using Renewal.DataHub.Models.Domain;

namespace Renewal.DataHub.Models.Repository
{
    public interface ITransactionDetailsData
    {
        Task<TransactionDetails> CreateAsync(TransactionDetails transaction);
    }
}
