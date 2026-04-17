namespace Domain;

public class Client
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string? Email { get; set; }
    
    public int Age { get; set; }

    
    public List<Appointment>? Appointments { get; set; } = new();
}