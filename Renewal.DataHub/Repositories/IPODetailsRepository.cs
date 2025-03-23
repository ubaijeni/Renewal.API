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
             Guid? clientId = null,
             DateTime? startDate = null,
             DateTime? endDate = null,
             string? clientName = null // Add this parameter
         );
        Task<PODetail> GetPODetailByIdAsync(Guid id);
        Task<PODetail> CreatePODetailAsync(PODetail poDetail);
        Task<PODetail> UpdatePODetailAsync(PODetail poDetail);
        Task<bool> DeletePODetailAsync(int id);
    }
}
