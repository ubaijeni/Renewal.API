using Renewal.DataHub.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renewal.DataHub.Models.Repository
{
    public interface IAmountData
    {
        Task<List<AmountReceive>> GetAsync();
        Task<AmountReceive> GetByIdAsync(Guid id);
        Task<AmountReceive> CreateAsync(AmountReceive amountReceive);
        Task<AmountReceive> UpdateAsync(AmountReceive amountReceive);
        Task<bool> DeleteAsync(AmountReceive amountReceive);

        // 🔹 Add this missing method in the interface
        Task<PODetail> GetPODetailByIdAsync(Guid POId);
        Task<decimal> GetTotalAmountReceivedByPOIdAsync(Guid poId);
    }
}
