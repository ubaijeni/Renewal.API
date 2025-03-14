using Renewal.Services.DTOs;

namespace Renewal.Services.Interfaces
{
    public interface IBranchService
    {
        Task<IEnumerable<BranchDTO>> GetAllBranchesAsync();
        Task<BranchDTO> GetBranchByIdAsync(Guid branchId);
        Task<BranchDTO> AddBranchAsync(AddBranchDTO branchDTO);
        Task UpdateBranchAsync(UpdateBranchDTO branchDTO);
        Task DeleteBranchAsync(Guid branchId);
    }
}
