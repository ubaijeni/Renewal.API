using Renewal.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renewal.Services.Interfaces
{
    public interface IPettyCashTransactionService
    {
        Task<IEnumerable<PettyCashTransactionDTO>> GetAllTransactionsAsync(Guid? branchId, DateTime? startDate, DateTime? endDate);
        Task<PettyCashTransactionDTO> GetTransactionByIdAsync(Guid transactionId);
        Task<PettyCashTransactionDTO> AddTransactionAsync(AddPettyCashTransactionDTO transactionDTO);
        Task UpdateTransactionAsync(UpdatePettyCashTransactionDTO transactionDTO);
        Task DeleteTransactionAsync(Guid transactionId);

    }
}
