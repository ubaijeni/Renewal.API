using AutoMapper;
using Renewal.DataHub.Models.Repository;
using Renewal.Service.DTO;

namespace Renewal.Service.Interfaces
{
    public interface IAmountService
    {
        Task<List<AmountReceiveDTO>> GetAsync();
        Task<AmountReceiveDTO> GetByIdAsync(Guid id);
        Task<AmountReceiveDTO> CreateAsync(AddAmountReceiveDTO input);
        Task<AmountReceiveDTO> UpdateAsync(Guid id, AddAmountReceiveDTO input);
        Task<bool> DeleteAsync(Guid id);
    }
}
