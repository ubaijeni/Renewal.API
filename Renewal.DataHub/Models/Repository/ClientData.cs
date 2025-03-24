using Microsoft.EntityFrameworkCore;
using Renewal.DataHub.Data;
using Renewal.DataHub.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Renewal.DataHub.Models.Repository
{
    public class ClientData : IClientData
    {
        private readonly ApplicationDbContext _context;

        public ClientData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            return await _context.Clients.FirstOrDefaultAsync(t => t.ClientId == id);
        }

        public async Task<Client> CreateAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Guid?> GetClientIdByNameAsync(string name)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.ClientName == name);
            return client?.ClientId;
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task DeleteAsync(Client client)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}
