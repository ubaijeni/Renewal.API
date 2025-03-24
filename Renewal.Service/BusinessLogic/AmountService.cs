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
            return _mapper.Map<List<AmountReceiveDTO>>(receivedData);
        }

        public async Task<AmountReceiveDTO> GetByIdAsync(Guid id)
        {
            var receivedData = await _data.GetByIdAsync(id);
            return _mapper.Map<AmountReceiveDTO>(receivedData);
        }

        public async Task<AmountReceiveDTO> CreateAsync(AddAmountReceiveDTO input)
        {
            // 🔹 Step 1: Check if PO exists in PODetails
            var existingPO = await _data.GetPODetailByIdAsync(input.POId);
            if (existingPO == null)
            {
                throw new Exception($"PO Number {input.POId} does not exist in PODetails.");
            }

            // 🔹 Step 2: Ensure POValue is not null
            decimal poValue = existingPO.POValue ?? 0;

            // 🔹 Step 3: Get the total received amount for this PO
            decimal totalAmountReceived = await _data.GetTotalAmountReceivedByPOIdAsync(input.POId);

            // 🔹 Step 4: Calculate the Balance Amount
            decimal balanceAmount = poValue - totalAmountReceived - input.Amountreceived;

            // 🔹 Step 5: Ensure balance amount is not negative
            if (balanceAmount < 0)
            {
                throw new Exception($"Cannot receive {input.Amountreceived}. Exceeds PO Value. Remaining balance: {poValue - totalAmountReceived}");
            }

            // 🔹 Step 6: Map DTO to AmountReceive Model
            var amount = _mapper.Map<AmountReceive>(input);
            amount.PODetail = existingPO; // Set the PO relationship correctly

            // 🔹 Step 7: Insert the new amount record
            amount = await _data.CreateAsync(amount);

            // 🔹 Step 8: Return DTO with updated Balance Amount
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
