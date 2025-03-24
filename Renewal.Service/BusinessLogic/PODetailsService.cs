using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Renewal.DataHub.Repositories;
using Renewal.Service.DTO;
using Renewal.Service.Interfaces;
using Renewal.Service.Mappings;

namespace Renewal.Service.BusinessLogic
{
    public class PODetailsService : IPODetailsService
    {
        private readonly IPODetailsRepository _poDetailsRepository;

        public PODetailsService(IPODetailsRepository poDetailsRepository)
        {
            _poDetailsRepository = poDetailsRepository;
        }

        public async Task<List<PODetailsDto>> GetAllPODetailsAsync(
            bool includeDeleted = false,
            Guid? clientId = null,
            DateTime? startDate = null,
            DateTime? endDate = null,string? clientName = null, int? PONumber = null)
        {
            // ✅ Call the repository method (avoid direct querying in service)
            var poDetails = await _poDetailsRepository.GetAllPODetailsAsync(
                includeDeleted, clientId, startDate, endDate, clientName);

            return poDetails.Select(PODetailsMapper.ToDto).ToList(); // ✅ Correct Mapping
        }

        public async Task<PODetailsDto> GetPODetailByIdAsync(Guid id)
        {
            var poDetail = await _poDetailsRepository.GetPODetailByIdAsync(id);
            return poDetail != null ? PODetailsMapper.ToDto(poDetail) : null;
        }

        public async Task<PODetailsDto> CreatePODetailAsync(CreatePODetailsDto createPODetailsDto)
        {
            var poDetail = PODetailsMapper.ToEntity(createPODetailsDto);
            var createdPODetail = await _poDetailsRepository.CreatePODetailAsync(poDetail);
            return PODetailsMapper.ToDto(createdPODetail);
        }

        public async Task<PODetailsDto> UpdatePODetailAsync(Guid id, UpdatePODetailsDto updatePODetailsDto)
        {
            var existingPODetail = await _poDetailsRepository.GetPODetailByIdAsync(id);
            if (existingPODetail == null)
                return null;

            PODetailsMapper.UpdateEntityFromDto(existingPODetail, updatePODetailsDto);

            var updatedPODetail = await _poDetailsRepository.UpdatePODetailAsync(existingPODetail);
            return PODetailsMapper.ToDto(updatedPODetail);
        }

        public async Task<bool> DeletePODetailAsync(int id)
        {
            return await _poDetailsRepository.DeletePODetailAsync(id);
        }
    }
}
