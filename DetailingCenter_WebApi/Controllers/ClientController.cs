using Application.DTO.Client;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DetailingCenter_WebApi.Controllers;

[ApiController]
[Route("client")]
public class ClientController : ControllerBase
{
    
    private readonly IClientService _clientService;
    
    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("all")]
    public Task<IEnumerable<ResponseClientDTO>> GetAllAsync()
    {
        return _clientService.GetAllAsync();
    }
}