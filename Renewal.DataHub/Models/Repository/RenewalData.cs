using Microsoft.EntityFrameworkCore;
using Renewal.DataHub.Data;
using Renewal.DataHub.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renewal.DataHub.Models.Repository
{
    public class RenewalData : IRenewalData
    {
        private readonly ApplicationDbContext _context;

        public RenewalData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RenewalValue>> GetAsync()
        {
            return await _context.Renewalset.ToListAsync();
        }

        public async Task<RenewalValue> GetByIdAsync(Guid id)
        {
            return await _context.Renewalset.FirstOrDefaultAsync(t => t.RENEWALID == id);
        }

        public async Task<RenewalValue> CreateAsync(RenewalValue renewal)
        {
            await _context.Renewalset.AddAsync(renewal);
            await _context.SaveChangesAsync();
            return renewal;
        }

        public async Task<RenewalValue> UpdateAsync(RenewalValue renewal)
        {
            _context.Renewalset.Update(renewal);
            await _context.SaveChangesAsync();
            return renewal;
        }

        public async Task DeleteAsync(RenewalValue renewal)
        {
            _context.Renewalset.Remove(renewal);
            await _context.SaveChangesAsync();
        }
    }
}
