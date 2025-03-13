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
            int? clientId = null, 
            DateTime? startDate = null, 
            DateTime? endDate = null)
        {
            var query = _context.PODetails.AsQueryable();

            // Filter out deleted records if not including
            if (!includeDeleted)
            {
                query = query.Where(p => p.IsActive == 1);
            }

            // Client filter
            if (clientId.HasValue)
            {
                query = query.Where(p => p.ClientNameId == clientId.Value);
            }
            
            if (startDate.HasValue)
            {
                string formattedStartDate = startDate.Value.ToString("yyyy-MM-dd");
                query = query.Where(p => 
                    !string.IsNullOrEmpty(p.StartDate) && 
                    string.Compare(p.StartDate, formattedStartDate) >= 0);
            }

     
            if (endDate.HasValue)
            {
                string formattedEndDate = endDate.Value.ToString("yyyy-MM-dd");
                query = query.Where(p => 
                    !string.IsNullOrEmpty(p.EndDate) && 
                    string.Compare(p.EndDate, formattedEndDate) <= 0);
            }

            return await query.ToListAsync();
        }

        public async Task<PODetail> GetPODetailByIdAsync(int id)
        {
            return await _context.PODetails.FindAsync(id);
        }
        
        public async Task<PODetail> CreatePODetailAsync(PODetail poDetail)
        {
            poDetail.CreatedDateTime = DateTime.Now;
            poDetail.IsActive = 1; // Default to active
            poDetail.Suspend = 0;  // Default to not suspended
    
            // Remove the ToString() conversion and handle potential null checks
            // Only set the dates if they are not null
            if (poDetail.JoiningDate != null)
            {
                poDetail.JoiningDate = DateTime.Parse(poDetail.JoiningDate).ToString("yyyy-MM-dd");
            }
    
            if (poDetail.RenewalDate != null)
            {
                poDetail.RenewalDate = DateTime.Parse(poDetail.RenewalDate).ToString("yyyy-MM-dd");
            }

            _context.PODetails.Add(poDetail);
            await _context.SaveChangesAsync();
            return poDetail;
        }

        public async Task<PODetail> UpdatePODetailAsync(PODetail poDetail)
        {
            poDetail.UpdatedDateTime = DateTime.Now;
    
            // Handle potential null checks for date fields
            if (poDetail.JoiningDate != null)
            {
                poDetail.JoiningDate = DateTime.Parse(poDetail.JoiningDate).ToString("yyyy-MM-dd");
            }
    
            if (poDetail.RenewalDate != null)
            {
                poDetail.RenewalDate = DateTime.Parse(poDetail.RenewalDate).ToString("yyyy-MM-dd");
            }

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
            poDetail.UpdatedDateTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}