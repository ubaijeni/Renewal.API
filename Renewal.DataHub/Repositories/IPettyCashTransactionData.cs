using Renewal.DataHub.Models.Domain;

namespace Renewal.DataHub.Models.Repository
{
    public interface IPettyCashTransactionData
    {
        Task<IEnumerable<PettyCashTransaction>> GetAllTransactionsAsync(Guid? branchId, DateTime? startDate, DateTime? endDate);
        Task<PettyCashTransaction> GetTransactionByIdAsync(Guid transactionId);
        Task AddTransactionAsync(PettyCashTransaction transaction);
        Task UpdateTransactionAsync(PettyCashTransaction transaction);
        Task DeleteTransactionAsync(Guid transactionId);
    }
}
