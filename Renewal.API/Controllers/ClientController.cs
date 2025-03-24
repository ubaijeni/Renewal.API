using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Renewal.Service.DTO;
using Renewal.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renewal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clients = await _clientService.GetAsync();
            return Ok(clients);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddClientDTO request)
        {
            var response = await _clientService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = response.ClientId }, response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AddClientDTO request)
        {
            var updatedClient = await _clientService.UpdateAsync(id, request);
            if (updatedClient == null)
                return NotFound();
            return Ok(updatedClient);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var isDeleted = await _clientService.DeleteAsync(id);
            if (!isDeleted)
                return NotFound();
            return Ok(isDeleted);
        }
    }
}
