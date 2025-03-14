using Microsoft.AspNetCore.Mvc;
using Renewal.Service.DTO;
using Renewal.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Renewal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PODetailsController : ControllerBase
    {
        private readonly IPODetailsService _poDetailsService;

        public PODetailsController(IPODetailsService poDetailsService)
        {
            _poDetailsService = poDetailsService;
        }

        // GET: api/PODetails
        [HttpGet]
        public async Task<IActionResult> GetAllPODetails(
            [FromQuery] bool includeDeleted = false,
            [FromQuery] int? clientId = null,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            var poDetails = await _poDetailsService.GetAllPODetailsAsync(
                includeDeleted, clientId, startDate, endDate);
            return Ok(poDetails);
        }

        // GET: api/PODetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPODetail(int id)
        {
            var poDetail = await _poDetailsService.GetPODetailByIdAsync(id);
            if (poDetail == null)
                return NotFound();

            return Ok(poDetail);
        }

        // POST: api/PODetails
        [HttpPost]
        public async Task<IActionResult> CreatePODetail([FromBody] CreatePODetailsDto createPODetailsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var poDetail = await _poDetailsService.CreatePODetailAsync(createPODetailsDto);
                return CreatedAtAction(nameof(GetPODetail), new { id = poDetail.POId }, poDetail);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while creating the PO Detail");
            }
        }

        // PUT: api/PODetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePODetail(int id, [FromBody] UpdatePODetailsDto updatePODetailsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var poDetail = await _poDetailsService.UpdatePODetailAsync(id, updatePODetailsDto);
                if (poDetail == null)
                    return NotFound();

                return Ok(poDetail);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while updating the PO Detail");
            }
        }

        // DELETE: api/PODetails/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePODetail(int id)
        {
            var result = await _poDetailsService.DeletePODetailAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}