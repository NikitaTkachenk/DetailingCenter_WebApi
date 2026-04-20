namespace Application.DTO.AppointmentDetails;

public class UpdateAppointmentDetailsDTO
{
    public string Description { get; set; } = null!;
    
    public DateTime AppointmentAt  { get; set; }
    
    public decimal Price { get; set; }
}