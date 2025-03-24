using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Renewal.DataHub.Models.Domain;
using Renewal.DataHub.Models.Repository;
using Renewal.Service.DTO;
using Renewal.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Renewal.Service.BusinessLogic
{
    public class AmountService : IAmountService
    {
        private readonly IAmountData _data;
        private readonly IMapper _mapper;

        public AmountService(IAmountData data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public async Task<List<AmountReceiveDTO>> GetAsync()
        {
            var receivedData = await _data.GetAsync();
            var resultList = new List<AmountReceiveDTO>();

            foreach (var amount in receivedData)
            {
                decimal totalReceived = await _data.GetTotalAmountReceivedByPOIdAsync(amount.POId);

                var result = _mapper.Map<AmountReceiveDTO>(amount, opts =>
                    opts.Items["TotalAmountReceived"] = totalReceived);

                resultList.Add(result);
            }

            return resultList;
        }

        public async Task<AmountReceiveDTO> GetByIdAsync(Guid id)
        {
            var receivedData = await _data.GetByIdAsync(id);
            if (receivedData == null) return null;

            decimal totalReceived = await _data.GetTotalAmountReceivedByPOIdAsync(receivedData.POId);

            return _mapper.Map<AmountReceiveDTO>(receivedData, opts =>
                opts.Items["TotalAmountReceived"] = totalReceived);
        }

        public async Task<AmountReceiveDTO> CreateAsync(AddAmountReceiveDTO input)
        {
            var existingPO = await _data.GetPODetailByIdAsync(input.POId);
            if (existingPO == null)
            {
                throw new Exception($"PO Number {input.POId} does not exist in PODetails.");
            }
            decimal poValue = existingPO.POValue ?? 0;
            decimal totalAmountReceived = await _data.GetTotalAmountReceivedByPOIdAsync(input.POId);
            decimal balanceAmount = poValue - totalAmountReceived - input.Amountreceived;
            if (balanceAmount < 0)
            {
                throw new Exception($"Cannot receive {input.Amountreceived}. Exceeds PO Value. Remaining balance: {poValue - totalAmountReceived}");
            }

            var amount = _mapper.Map<AmountReceive>(input);
            amount.PODetail = existingPO; 
            amount = await _data.CreateAsync(amount);
            var result = _mapper.Map<AmountReceiveDTO>(amount);
            result.BalanceAmount = balanceAmount;

            return result;
        }

        public async Task<AmountReceiveDTO> UpdateAsync(Guid id, AddAmountReceiveDTO input)
        {
            var amount = await _data.GetByIdAsync(id);
            if (amount == null) return null;

            _mapper.Map(input, amount);
            amount = await _data.UpdateAsync(amount);

            return _mapper.Map<AmountReceiveDTO>(amount);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var amount = await _data.GetByIdAsync(id);
            if (amount == null) return false;

            await _data.DeleteAsync(amount);
            return true;
        }
    }
}
