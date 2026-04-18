namespace Domain;

public class Appointment
{
    public int Id { get; set; }
    
    public int ClientId { get; set; }
    
    public string Name { get; set; } = null!;
    
    
    public AppointmentDetails AppointmentDetails { get; set; } = new();
    
    public Client Client { get; set; } = new();
}