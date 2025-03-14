using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Renewal.Service.DTO;
using Renewal.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Renewal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RenewalController : ControllerBase
    {
        private readonly IRenewalValueService _renewalService;

        public RenewalController(IRenewalValueService renewalService)
        {
            _renewalService = renewalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var renewals = await _renewalService.GetAsync();
            return Ok(renewals);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var renewal = await _renewalService.GetByIdAsync(id);
            if (renewal == null) return NotFound();
            return Ok(renewal);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRenewalValueDTO request)
        {
            var response = await _renewalService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = response.RENEWALID }, response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AddRenewalValueDTO request)
        {
            var renewal = await _renewalService.UpdateAsync(id, request);
            if (renewal == null) return NotFound();
            return Ok(renewal);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var success = await _renewalService.DeleteAsync(id);
            if (!success) return NotFound();
            return Ok(success);
        }
    }
}
