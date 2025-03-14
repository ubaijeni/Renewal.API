using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Renewal.DataHub.Models.Domain;
using Renewal.DataHub.Models.Repository;
using Renewal.Services.DTOs;
using Renewal.Services.Interfaces;
using Renewal.DataHub.Models.Domain;
using Renewal.DataHub.Models.Repository;
using Renewal.Services.Interfaces;

namespace Renewal.Services.BusinessLogic
{
    public class PettyCashTransactionService : IPettyCashTransactionService
    {
        private readonly IPettyCashTransactionData _pettyCashTransactionData;
        private readonly IMapper _mapper;

        public PettyCashTransactionService(IPettyCashTransactionData pettyCashTransactionData, IMapper mapper)
        {
            _pettyCashTransactionData = pettyCashTransactionData;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PettyCashTransactionDTO>> GetAllTransactionsAsync(Guid? branchId, DateTime? startDate, DateTime? endDate)
        {
            Console.WriteLine($"Fetching transactions for BranchID: {branchId}, StartDate: {startDate}, EndDate: {endDate}");
            if (startDate.HasValue)
            {
                startDate = startDate.Value.Date; // Set time to 00:00:00
            }
            if (endDate.HasValue)
            {
                endDate = endDate.Value.Date.AddDays(1).AddTicks(-1); // Set time to 23:59:59.9999999
            }

            var transactions = await _pettyCashTransactionData.GetAllTransactionsAsync(branchId, startDate, endDate);

            if (transactions == null || !transactions.Any())
            {
                Console.WriteLine("No transactions retrieved from DB.");
                return new List<PettyCashTransactionDTO>();
            }

            Console.WriteLine($"Transactions retrieved from DB: {transactions.Count()}");

            // Sort transactions by TransactionDate
            transactions = transactions.OrderBy(t => t.TransactionDate).ToList();

            var transactionDTOs = _mapper.Map<List<PettyCashTransactionDTO>>(transactions);
            Console.WriteLine($"Transactions after mapping: {transactionDTOs.Count()}");

            // ✅ Fix: Calculate Running Balance Correctly
            decimal runningBalance = 0;
            foreach (var transaction in transactionDTOs)
            {
                if (string.Equals(transaction.TransactionType, "Credit", StringComparison.OrdinalIgnoreCase))
                {
                    runningBalance += transaction.Amount; // Add amount for Credit
                }
                else if (string.Equals(transaction.TransactionType, "Debit", StringComparison.OrdinalIgnoreCase))
                {
                    runningBalance -= transaction.Amount; // Subtract amount for Debit
                }

                transaction.BalanceAmount = runningBalance; // Update balance in DTO
                Console.WriteLine($"Transaction ID: {transaction.TransactionID}, Type: {transaction.TransactionType}, Amount: {transaction.Amount}, Running Balance: {runningBalance}");
            }


            return transactionDTOs;
        }
        public async Task<PettyCashTransactionDTO> GetTransactionByIdAsync(Guid transactionId)
        {
            var transaction = await _pettyCashTransactionData.GetTransactionByIdAsync(transactionId);
            if (transaction == null)
                throw new KeyNotFoundException("Transaction not found!");

            return _mapper.Map<PettyCashTransactionDTO>(transaction);
        }
        public async Task<PettyCashTransactionDTO> AddTransactionAsync(AddPettyCashTransactionDTO transactionDTO)
        {
            var transaction = _mapper.Map<PettyCashTransaction>(transactionDTO);

            await _pettyCashTransactionData.AddTransactionAsync(transaction); 

            return _mapper.Map<PettyCashTransactionDTO>(transaction); 
        }
        public async Task UpdateTransactionAsync(UpdatePettyCashTransactionDTO transactionDTO)
        {
            if (transactionDTO == null)
                throw new ArgumentNullException(nameof(transactionDTO));

            var existingTransaction = await _pettyCashTransactionData.GetTransactionByIdAsync(transactionDTO.TransactionID);
            if (existingTransaction == null)
                throw new KeyNotFoundException("Transaction not found!");

            var transaction = _mapper.Map(transactionDTO, existingTransaction);
            await _pettyCashTransactionData.UpdateTransactionAsync(transaction);
        }
        public async Task DeleteTransactionAsync(Guid transactionId)
        {
            var existingTransaction = await _pettyCashTransactionData.GetTransactionByIdAsync(transactionId);
            if (existingTransaction == null)
                throw new KeyNotFoundException("Transaction not found!");

            await _pettyCashTransactionData.DeleteTransactionAsync(transactionId);
        }
    }
}
