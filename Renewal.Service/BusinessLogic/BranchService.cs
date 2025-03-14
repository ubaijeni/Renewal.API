using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Renewal.DataHub.Models.Domain;
using Renewal.DataHub.Models.Repository;
using Renewal.Services.DTOs;
using Renewal.Services.Interfaces;
using Renewal.DataHub.Models.Domain;
using Renewal.DataHub.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renewal.Services.BusinessLogic
{
    public class BranchService : IBranchService
    {
        private readonly IBranchData _branchData;
        private readonly IMapper _mapper;

        public BranchService(IBranchData branchData, IMapper mapper)
        {
            _branchData = branchData;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BranchDTO>> GetAllBranchesAsync()
        {
            var branches = await _branchData.GetAllBranchesAsync();
            return _mapper.Map<IEnumerable<BranchDTO>>(branches);
        }
        public async Task<BranchDTO> GetBranchByIdAsync(Guid branchId)
        {
            var branch = await _branchData.GetBranchByIdAsync(branchId);
            return _mapper.Map<BranchDTO>(branch);
        }
        public async Task<BranchDTO?> AddBranchAsync(AddBranchDTO branchDTO)
        {
            bool branchExists = await _branchData.BranchExistsAsync(branchDTO.BranchName);

            if (branchExists)
            {
                return null; 
            }

            // Use AutoMapper to map DTO to Entity
            var branch = _mapper.Map<Branch>(branchDTO);
            branch.UpdatedDate = DateTime.UtcNow; // Ensure the date is set

            await _branchData.AddBranchAsync(branch);

            // Map back to DTO before returning
            return _mapper.Map<BranchDTO>(branch);
        }
        public async Task UpdateBranchAsync(UpdateBranchDTO branchDTO)
        {
            var branch = _mapper.Map<Branch>(branchDTO);
            await _branchData.UpdateBranchAsync(branch);
        }
        public async Task DeleteBranchAsync(Guid branchId)
        {
            await _branchData.DeleteBranchAsync(branchId);
        }
    }
}