using Application.DTO.Client;
using Application.Filters;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace DetailingCenter_WebApi.Controllers;

[ApiController]
[Route("api/clients")]
public class ClientController : ControllerBase
{
    
    private readonly IClientService _clientService;
    
    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync([FromQuery]ClientFilter filter)
    {
        var clients = await _clientService.GetAllAsync(filter);
        return Ok(clients);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var client = await _clientService.GetByIdAsync(id);
        
        if(client == null) 
            return NotFound("Client not found");
        return Ok(client);
    }

    [HttpPost]
    public async Task<IActionResult> CreateClientAsync(CreateClientDTO newClient)
    {
        await _clientService.AddAsync(newClient);
        return NoContent();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClientAsync(int id, UpdateClientDTO updatedClient)
    {
        await _clientService.UpdateAsync(id, updatedClient);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClientAsync(int id)
    {
        await _clientService.DeleteByIdAsync(id);
        return NoContent();
    }
}