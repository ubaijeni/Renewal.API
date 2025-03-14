using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Renewal.DataHub.Models.Domain;
using Renewal.DataHub.Models.Repository;
using Renewal.Service.DTO;
using Renewal.Service.Interfaces;

namespace Renewal.Service.BusinessLogic
{
    public class ClientService : IClientService
    {
        private readonly IClientData _data;
        private readonly IMapper _mapper;

        public ClientService(IClientData data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public async Task<List<ClientDTO>> GetAsync()
        {
            var clientdata = await _data.GetAsync();
            return _mapper.Map<List<ClientDTO>>(clientdata);
        }

        public async Task<ClientDTO> GetByIdAsync(Guid id)
        {
            var clientdata = await _data.GetByIdAsync(id);
            return _mapper.Map<ClientDTO>(clientdata);
        }

        public async Task<ClientDTO> CreateAsync(AddClientDTO input)
        {
            var client = _mapper.Map<Client>(input);
            client = await _data.CreateAsync(client);
            return _mapper.Map<ClientDTO>(client);
        }

        public async Task<ClientDTO> UpdateAsync(Guid id, AddClientDTO input)
        {
            var client = await _data.GetByIdAsync(id);
            if (client == null) return null;

            _mapper.Map(input, client);
            client = await _data.UpdateAsync(client);

            return _mapper.Map<ClientDTO>(client);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var client = await _data.GetByIdAsync(id);
            if (client == null) return false;

            await _data.DeleteAsync(client);
            return true;
        }
    }
}
