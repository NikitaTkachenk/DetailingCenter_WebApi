using Application.DTO.AppointmentDetails;

namespace Application.DTO.Appointment;

public class CreateAppointmentDTO
{
    public int ClientId { get; set; }
    
    public string Name { get; set; } = null!;
    
    public CreateAppointmentDetailsDTO AppointmentDetails { get; set; } = null!;
}