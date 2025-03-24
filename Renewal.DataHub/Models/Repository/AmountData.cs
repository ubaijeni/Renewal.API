using Microsoft.EntityFrameworkCore;
using Renewal.DataHub.Data;
using Renewal.DataHub.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Renewal.DataHub.Models.Repository
{
    public class AmountData : IAmountData
    {
        private readonly ApplicationDbContext _context;

        public AmountData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AmountReceive>> GetAsync()
        {
            return await _context.AmountReceived
                .Include(a => a.PODetail)
                .ToListAsync();
        }

        public async Task<AmountReceive> GetByIdAsync(Guid id)
        {
            return await _context.AmountReceived
                .Include(a => a.PODetail)
                .FirstOrDefaultAsync(a => a.AmountreceivedId == id);
        }

        public async Task<AmountReceive> CreateAsync(AmountReceive amountReceive)
        {
            _context.AmountReceived.Add(amountReceive);
            await _context.SaveChangesAsync();
            return amountReceive;
        }

        public async Task<AmountReceive> UpdateAsync(AmountReceive amountReceive)
        {
            _context.AmountReceived.Update(amountReceive);
            await _context.SaveChangesAsync();
            return amountReceive;
        }

        public async Task<bool> DeleteAsync(AmountReceive amountReceive)
        {
            _context.AmountReceived.Remove(amountReceive);
            return await _context.SaveChangesAsync() > 0;
        }

        // 🔹 Get PO details by POId
        public async Task<PODetail> GetPODetailByIdAsync(Guid poId)
        {
            return await _context.PODetails.FindAsync(poId);
        }

        // 🔹 Get the total amount received for a specific POId
        public async Task<decimal> GetTotalAmountReceivedByPOIdAsync(Guid poId)
        {
            return await _context.AmountReceived
                .Where(a => a.POId == poId)
                .SumAsync(a => (decimal?)a.Amountreceived) ?? 0;
        }
    }
}
