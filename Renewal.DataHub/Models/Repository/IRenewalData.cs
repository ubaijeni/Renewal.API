using Renewal.DataHub.Models.Domain;

namespace Renewal.DataHub.Models.Repository
{
    public interface IRenewalData
    {
        Task<List<RenewalValue>> GetAsync();
        Task<RenewalValue> GetByIdAsync(Guid id);
        Task<RenewalValue> CreateAsync(RenewalValue renewal);
        Task<RenewalValue> UpdateAsync(RenewalValue renewal);
        Task DeleteAsync(RenewalValue renewal);
    }
}
