using AutoMapper;
using Renewal.DataHub.Models.Domain;
using Renewal.DataHub.Models.Repository;
using Renewal.Service.DTO;
using Renewal.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renewal.Service.BusinessLogic
{
    public class RenewalValueService : IRenewalValueService
    {
        private readonly IRenewalData _data;
        private readonly ITransactionDetailsData _transaction;
        private readonly IMapper _mapper;

        public RenewalValueService(IRenewalData data, ITransactionDetailsData transactiondetails, IMapper mapper)
        {
            _data = data;
            _transaction = transactiondetails;
            _mapper = mapper;
        }

        public async Task<List<RenewalValueDTO>> GetAsync()
        {
            var renewaldata = await _data.GetAsync(); // Ensure IRenewalData has an async Get method
            return _mapper.Map<List<RenewalValueDTO>>(renewaldata);
        }

        public async Task<RenewalValueDTO> GetByIdAsync(Guid id)
        {
            var renewaldata = await _data.GetByIdAsync(id); // Ensure IRenewalData has an async GetById method
            return _mapper.Map<RenewalValueDTO>(renewaldata);
        }

        public async Task<RenewalValueDTO> CreateAsync(AddRenewalValueDTO input)
        {
            var renewal = _mapper.Map<RenewalValue>(input);
            renewal = await _data.CreateAsync(renewal);

            await AddTransactionDetailsAsync(renewal);
            return _mapper.Map<RenewalValueDTO>(renewal);
        }

        private async Task AddTransactionDetailsAsync(RenewalValue renewal)
        {
            var transaction = _mapper.Map<TransactionDetails>(renewal);
            transaction.TransactionId = Guid.NewGuid();
            await _transaction.CreateAsync(transaction);
        }

        public async Task<RenewalValueDTO> UpdateAsync(Guid id, AddRenewalValueDTO input)
        {
            var renewal = await _data.GetByIdAsync(id);
            if (renewal == null) return null;

            _mapper.Map(input, renewal);
            renewal = await _data.UpdateAsync(renewal);

            return _mapper.Map<RenewalValueDTO>(renewal);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var renewal = await _data.GetByIdAsync(id);
            if (renewal == null) return false;

            await _data.DeleteAsync(renewal);
            return true;
        }
    }
}
