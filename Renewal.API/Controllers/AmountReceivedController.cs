using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Renewal.Service.DTO;
using Renewal.Service.Interfaces;

namespace Renewal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmountReceivedController : ControllerBase
    {
        private readonly IAmountService _amountService;

        public AmountReceivedController(IAmountService amountService)
        {
            _amountService = amountService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var amount = await _amountService.GetAsync();
            return Ok(amount);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var amount = await _amountService.GetByIdAsync(id);
            if (amount == null)
                return NotFound();
            return Ok(amount);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddAmountReceiveDTO request)
        {
            var response = await _amountService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = response.POId }, response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AddAmountReceiveDTO request)
        {
            var updatedamount = await _amountService.UpdateAsync(id, request);
            if (updatedamount == null)
                return NotFound();
            return Ok(updatedamount);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var isDeleted = await _amountService.DeleteAsync(id);
            if (!isDeleted)
                return NotFound();
            return Ok(isDeleted);
        }
    }
}
