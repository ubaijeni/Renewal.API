using Microsoft.EntityFrameworkCore;
using Renewal.DataHub.Data;
using Renewal.DataHub.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Renewal.DataHub.Repositories
{
    public class PODetailsRepository : IPODetailsRepository
    {
        private readonly ApplicationDbContext _context;

        public PODetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PODetail>> GetAllPODetailsAsync(
       bool includeDeleted = false,
       Guid? clientId = null,
       DateTime? startDate = null,
       DateTime? endDate = null,
       string? clientName = null)
        {

            var query = _context.PODetails
       .Include(p => p.Client) // Ensure Client data is loaded
       .AsQueryable();

            // Exclude deleted records
            if (!includeDeleted)
            {
                query = query.Where(p => p.IsActive == 1);
            }

            // Filter by Client ID
            if (clientId.HasValue)
            {
                query = query.Where(p => p.ClientNameId == clientId.Value);
            }

            if (!string.IsNullOrEmpty(clientName))
            {
                query = query.Where(p => p.Client != null &&
                                         p.Client.ClientName != null &&
                                         p.Client.ClientName.ToLower().Contains(clientName.ToLower()));
            }

            // Apply Start Date filter
            if (startDate.HasValue)
            {
                query = query.Where(p => p.CreatedDateTime >= startDate.Value);
            }

            // Apply End Date filter
            if (endDate.HasValue)
            {
                query = query.Where(p => p.CreatedDateTime <= endDate.Value);
            }

            // Execute the query
            var results = await query
                .Select(p => new PODetail
                {
                    POId = p.POId,
                    ClientNameId = p.ClientNameId,
                    IsActive = p.IsActive
                })
                .ToListAsync();

            return results;

        }

        public async Task<PODetail> GetPODetailByIdAsync(Guid id)
        {
            return await _context.PODetails
                .Include(p => p.Client) // Include related Client entity
                .FirstOrDefaultAsync(p => p.POId == id);
        }

        public async Task<PODetail> CreatePODetailAsync(PODetail poDetail)
        {
            poDetail.CreatedDateTime = DateTime.UtcNow;
            poDetail.IsActive = 1; // Default to active
            poDetail.Suspend = 0;  // Default to not suspended

            _context.PODetails.Add(poDetail);
            await _context.SaveChangesAsync();
            return poDetail;
        }

        public async Task<PODetail> UpdatePODetailAsync(PODetail poDetail)
        {
            poDetail.UpdatedDateTime = DateTime.UtcNow;

            _context.Entry(poDetail).State = EntityState.Modified;

            // Don't modify creation fields
            _context.Entry(poDetail).Property(x => x.CreatedBy).IsModified = false;
            _context.Entry(poDetail).Property(x => x.CreatedDateTime).IsModified = false;

            await _context.SaveChangesAsync();
            return poDetail;
        }

        public async Task<bool> DeletePODetailAsync(int id)
        {
            var poDetail = await _context.PODetails.FindAsync(id);
            if (poDetail == null)
                return false;

            // If already inactive, return success
            if (poDetail.IsActive == 0)
                return true;

            // Soft delete
            poDetail.IsActive = 0;
            poDetail.UpdatedDateTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
