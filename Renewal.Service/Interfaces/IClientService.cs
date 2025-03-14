using Renewal.Service.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renewal.Service.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDTO>> GetAsync();
        Task<ClientDTO> GetByIdAsync(Guid id);
        Task<ClientDTO> CreateAsync(AddClientDTO input);
        Task<ClientDTO> UpdateAsync(Guid id, AddClientDTO input);
        Task<bool> DeleteAsync(Guid id);
    }
}
