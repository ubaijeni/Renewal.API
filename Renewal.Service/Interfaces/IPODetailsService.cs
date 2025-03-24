using Renewal.Service.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renewal.Service.Interfaces
{
    public interface IPODetailsService
    {
        Task<List<PODetailsDto>> GetAllPODetailsAsync(
            bool includeDeleted = false,
            Guid? clientId = null,
            DateTime? startDate = null,
            DateTime? endDate = null, string? clientName = null, int? PONumber = null);

        Task<PODetailsDto> GetPODetailByIdAsync(Guid id);
        Task<PODetailsDto> CreatePODetailAsync(CreatePODetailsDto createPODetailsDto);
        Task<PODetailsDto> UpdatePODetailAsync(Guid id, UpdatePODetailsDto updatePODetailsDto);
        Task<bool> DeletePODetailAsync(int id);
    }
}