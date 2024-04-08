using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser
{
    public string Nome {get;set;}
    public string CodiceFornitore {get;set;}
    public bool StatoAttivo {get;set;}
}