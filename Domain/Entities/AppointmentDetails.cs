namespace Domain;

public class AppointmentDetails
{
    public int AppointmentId { get; set; }
    
    public string Description { get; set; } = null!;
    
    public DateTime AppointmentAt  { get; set; }
    
    public decimal Price { get; set; }
    

    public Appointment Appointment { get; set; } = new();
}