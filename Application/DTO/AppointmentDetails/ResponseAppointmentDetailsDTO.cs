namespace Application.DTO.AppointmentDetails;

public class ResponseAppointmentDetailsDTO
{
    public string Description { get; set; } = null!;
    
    public DateTime AppointmentAt  { get; set; }
    
    public decimal Price { get; set; }
}