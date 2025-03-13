using Renewal.DataHub.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renewal.DataHub.Repositories
{
    public interface IPODetailsRepository
    {
        /// Retrieves all PO Details with optional filtering
        Task<List<PODetail>> GetAllPODetailsAsync(
            bool includeDeleted = false, 
            int? clientId = null, 
            DateTime? startDate = null, 
            DateTime? endDate = null);
        Task<PODetail> GetPODetailByIdAsync(int id);
        Task<PODetail> CreatePODetailAsync(PODetail poDetail);
        Task<PODetail> UpdatePODetailAsync(PODetail poDetail);
        Task<bool> DeletePODetailAsync(int id);
    }
}