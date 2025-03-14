using Renewal.Service.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renewal.Service.Interfaces
{
    public interface IRenewalValueService
    {
        Task<List<RenewalValueDTO>> GetAsync();
        Task<RenewalValueDTO> GetByIdAsync(Guid id);
        Task<RenewalValueDTO> CreateAsync(AddRenewalValueDTO input);
        Task<RenewalValueDTO> UpdateAsync(Guid id, AddRenewalValueDTO input);
        Task<bool> DeleteAsync(Guid id);
    }
}
