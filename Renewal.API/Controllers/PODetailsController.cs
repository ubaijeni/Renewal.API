using Microsoft.AspNetCore.Mvc;
using Renewal.DataHub.Models.Domain;
using Renewal.Service.DTO;
using Renewal.Service.Interfaces;
using System;
using System.Text;
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
            [FromQuery] Guid? clientId = null,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null, [FromQuery] string? ClientName = null)
        {
            var poDetails = await _poDetailsService.GetAllPODetailsAsync(
         includeDeleted, clientId, startDate, endDate, ClientName); // 

            return Ok(poDetails);
        }

        // GET: api/PODetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPODetail(Guid id)
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
        public async Task<IActionResult> UpdatePODetail(Guid id, [FromBody] UpdatePODetailsDto updatePODetailsDto)
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
        [HttpGet("export")]
        public async Task<IActionResult> ExportPODetails(
    [FromQuery] bool includeDeleted = false,
    [FromQuery] int? PONumber = null,
    [FromQuery] Guid? clientId = null,
    [FromQuery] DateTime? startDate = null,
    [FromQuery] DateTime? endDate = null,
    [FromQuery] string? clientName = null,
    [FromQuery] string format = "csv") // Default export format is CSV
        {
            var poDetails = await _poDetailsService.GetAllPODetailsAsync(
                includeDeleted, clientId, startDate, endDate, clientName, PONumber);

          
                var csvData = GenerateCSV(poDetails);
                return File(new System.Text.UTF8Encoding().GetBytes(csvData), "text/csv", "PODetails.csv");
            
        }
        private string GenerateCSV(List<PODetailsDto> poDetails)
        {
            var csv = new StringBuilder();
            csv.AppendLine("POId,ClientName,IsActive");

            foreach (var detail in poDetails)
            {
                csv.AppendLine($"{detail.POId},{detail.PONumber},{detail.ClientName ?? "N/A"},{detail.IsActive}");
            }

            return csv.ToString();
        }


    }
}