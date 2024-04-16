using Microsoft.AspNetCore.Identity; 

public class AppUser : IdentityUser
{
    public string? Nome { get; set; }
    
    public bool Stato { get; set; }
}