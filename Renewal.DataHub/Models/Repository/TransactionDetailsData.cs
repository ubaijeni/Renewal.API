using Renewal.DataHub.Models.Domain;
using System;

namespace Renewal.DataHub.Models.Repository
{
    public class TransactionDetailsData : ITransactionDetailsData
    {
        private readonly SampleDbContext _context;

        public TransactionDetailsData(SampleDbContext context)
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
