namespace Application.DTO.Client;

public class UpdateClientDTO
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string? Email { get; set; }
    
    public int Age { get; set; }
}