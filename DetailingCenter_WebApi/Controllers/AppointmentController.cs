using Application.DTO.Appointment;
using Application.Filters;
using Application.Interfaces.IServices;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace DetailingCenter_WebApi.Controllers;

[ApiController]
[Route("api/appointments")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _service;
    
    public AppointmentController(IAppointmentService  appointmentService)
    {
        _service = appointmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] AppointmentFilter filter)
    {
        var appointment = await _service.GetAllAsync(filter);
        return Ok(appointment);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var appointment = await _service.GetByIdAsync(id);
        return Ok(appointment);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody]CreateAppointmentDTO appointment)
    {
        await _service.CreateAsync(appointment);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody]UpdateAppointmentDTO appointment)
    {
        await _service.UpdateAsync(id, appointment);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _service.DeleteByIdAsync(id);
        return NoContent();
    }
}