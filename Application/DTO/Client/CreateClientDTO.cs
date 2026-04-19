namespace Application.DTO.Client;

public class CreateClientDTO
{
    public string Name { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string? Email { get; set; }
    
    public int Age { get; set; }
}