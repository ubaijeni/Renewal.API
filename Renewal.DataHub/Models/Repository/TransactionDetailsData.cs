using Renewal.DataHub.Data;
using Renewal.DataHub.Models.Domain;
using System;

namespace Renewal.DataHub.Models.Repository
{
    public class TransactionDetailsData : ITransactionDetailsData
    {
        private readonly ApplicationDbContext _context;

        public TransactionDetailsData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TransactionDetails> CreateAsync(TransactionDetails transaction)
        {
          await  _context.Trans.AddAsync(transaction);
          await  _context.SaveChangesAsync();
            return transaction;
        }

    }
}
