namespace Application.DTO.AppointmentDetails;

public class CreateAppointmentDetailsDTO
{
    public string Description { get; set; } = null!;
    
    public decimal Price { get; set; }
}