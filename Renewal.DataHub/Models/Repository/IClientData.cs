using Renewal.DataHub.Models.Domain;

namespace Renewal.DataHub.Models.Repository
{
    public interface IClientData
    {
        Task<List<Client>> GetAsync();
        Task<Client> GetByIdAsync(Guid id);
        Task<Client> CreateAsync(Client client);
        Task<Guid?> GetClientIdByNameAsync(string name);
        Task<Client> UpdateAsync(Client client);
        Task DeleteAsync(Client client);
    }
}
