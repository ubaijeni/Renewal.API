using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Renewal.Services.DTOs;
using Renewal.Services.Interfaces;

namespace Renewal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBranches()
        {
            var branches = await _branchService.GetAllBranchesAsync();
            return Ok(branches);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBranchById(Guid id)
        {
            var branch = await _branchService.GetBranchByIdAsync(id);
            if (branch == null)
                return NotFound("Branch not found.");

            return Ok(branch);
        }

        [HttpPost]
        public async Task<IActionResult> AddBranch([FromBody] AddBranchDTO branchDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdBranch = await _branchService.AddBranchAsync(branchDTO);

            if (createdBranch == null) // Branch already exists
            {
                return Conflict("Branch with the same name already exists.");
            }

            return CreatedAtAction(nameof(GetBranchById), new { id = createdBranch.BranchID }, createdBranch);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBranch(Guid id, [FromBody] UpdateBranchDTO branchDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _branchService.UpdateBranchAsync(branchDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(Guid id)
        {
            await _branchService.DeleteBranchAsync(id);
            return NoContent();
        }
    }
}

