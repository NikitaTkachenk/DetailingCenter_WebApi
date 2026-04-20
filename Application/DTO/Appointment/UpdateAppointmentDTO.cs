using Application.DTO.AppointmentDetails;

namespace Application.DTO.Appointment;

public class UpdateAppointmentDTO
{
    public string Name { get; set; } = null!;

    public UpdateAppointmentDetailsDTO AppointmentDetails { get; set; } = null!;
}