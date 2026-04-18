using Application.DTO.AppointmentDetails;
using Domain;

namespace Application.DTO.Appointment;

public class ResponseAppointmentDTO
{
    public string Name { get; set; } = null!;
    
    public ResponseAppointmentDetailsDTO AppointmentDetails { get; set; } = new();
    
}