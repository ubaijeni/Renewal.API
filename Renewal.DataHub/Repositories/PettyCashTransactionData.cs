using Microsoft.EntityFrameworkCore;
using Renewal.DataHub.Models.Domain;

namespace Renewal.DataHub.Models.Repository
{
    public class PettyCashTransactionData : IPettyCashTransactionData
    {
        private readonly PettyCashDbContext _context;  
        public PettyCashTransactionData(PettyCashDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PettyCashTransaction>> GetAllTransactionsAsync(Guid? branchId, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.PettyCashTransaction.Include(pc => pc.Branch).AsQueryable();

            if (branchId.HasValue)
            {
                query = query.Where(pc => pc.BranchID == branchId.Value);
            }

            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(pc => pc.TransactionDate >= startDate.Value && pc.TransactionDate <= endDate.Value);
            }

            return await query.ToListAsync();
        }
        public async Task<PettyCashTransaction> GetTransactionByIdAsync(Guid transactionId)
        {
            return await _context.PettyCashTransaction 
                .Include(pc => pc.Branch)
                .FirstOrDefaultAsync(pc => pc.TransactionID == transactionId);
        }
        public async Task AddTransactionAsync(PettyCashTransaction transaction)
        {
            await _context.PettyCashTransaction.AddAsync(transaction);  
            await _context.SaveChangesAsync();
        }
        public async Task UpdateTransactionAsync(PettyCashTransaction transaction)
        {
            _context.PettyCashTransaction.Update(transaction);  
            await _context.SaveChangesAsync();
        }
        public async Task DeleteTransactionAsync(Guid transactionId)
        {
            var transaction = await _context.PettyCashTransaction.FindAsync(transactionId); 
            if (transaction != null)
            {
                _context.PettyCashTransaction.Remove(transaction);  
                await _context.SaveChangesAsync();
            }
        }
    }

}
