using Microsoft.EntityFrameworkCore;
using Renewal.DataHub.Models.Domain;

namespace Renewal.DataHub.Models.Repository
{
    public class BranchData:IBranchData
    {
        private readonly PettyCashDbContext _context;
        public BranchData(PettyCashDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Branch>> GetAllBranchesAsync()
        {
            return await _context.Branches.ToListAsync();
        }
        public async Task<bool> BranchExistsAsync(string branchName)
        {
            return await _context.Branches
                .AnyAsync(b => b.BranchName.ToLower() == branchName.ToLower());
        }
        public async Task<Branch> GetBranchByIdAsync(Guid branchId)
        {
            return await _context.Branches.FindAsync(branchId);
        }
        public async Task<bool> AddBranchAsync(Branch branch)
        {
            // Check if a branch with the same name already exists
            bool branchExists = await _context.Branches
                .AnyAsync(b => b.BranchName.ToLower() == branch.BranchName.ToLower());

            if (branchExists)
            {
                return false; // Indicating that branch already exists
            }

            // If no duplicate found, proceed with adding the branch
            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();
            return true; // Successfully added
        }
        public async Task UpdateBranchAsync(Branch branch)
        {
            _context.Branches.Update(branch);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteBranchAsync(Guid branchId)
        {
            var branch = await _context.Branches.FindAsync(branchId);
            if (branch != null)
            {
                _context.Branches.Remove(branch);
                await _context.SaveChangesAsync();
            }
        }

    }
}
