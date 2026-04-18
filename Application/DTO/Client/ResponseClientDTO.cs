using Application.DTO.Appointment;
using Domain;

namespace Application.DTO.Client;

public class ResponseClientDTO
{
    public string Name { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string? Email { get; set; }
    
    public int Age { get; set; }
    
    public List<ResponseAppointmentDTO>? Appointments { get; set; }
    
}