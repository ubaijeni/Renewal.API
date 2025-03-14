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
            int? clientId = null,
            DateTime? startDate = null,
            DateTime? endDate = null);

        Task<PODetailsDto> GetPODetailByIdAsync(int id);
        Task<PODetailsDto> CreatePODetailAsync(CreatePODetailsDto createPODetailsDto);
        Task<PODetailsDto> UpdatePODetailAsync(int id, UpdatePODetailsDto updatePODetailsDto);
        Task<bool> DeletePODetailAsync(int id);
    }
}