using Renewal.DataHub.Models.Domain;

namespace Renewal.DataHub.Models.Repository
{
    public interface IBranchData
    {
        Task<IEnumerable<Branch>> GetAllBranchesAsync();
        Task<Branch> GetBranchByIdAsync(Guid branchId);
        Task<bool> AddBranchAsync(Branch branch);
        Task<bool> BranchExistsAsync(string branchName);
        Task UpdateBranchAsync(Branch branch);
        Task DeleteBranchAsync(Guid branchId);
    }
}
