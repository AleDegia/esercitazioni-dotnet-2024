using Microsoft.AspNetCore.Identity; 
namespace MvcAuthAppQuizReale3.Models;

public class SeedData
{
// Metodo principale per inizializzare il database con dati di seeding
public static async Task InitializeAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
{
    // Creazione dei ruoli se non esistono
    string[] roleNames = { "Admin", "Fornitore", "Cliente" };
    foreach (var roleName in roleNames)
    {
        // Verifica se il ruolo esiste già nel database
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            // Se il ruolo non esiste, crea il ruolo (IdentityRole è una classe fornita dal framework ASP.NET Core Identity. Rappresenta un ruolo all'interno del sistema di autenticazione e autorizzazione.)
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    // Creazione dell'utente Admin se non esiste (se non trova sta mail lo crea)
    if (await userManager.FindByEmailAsync("fdfdf@∂fdf.com") == null)
    {
        // creazione del nuovo utente amministratore (oggetto utente coi suoi campi e in + gli do passw e ruolo)
        var adminUser = new AppUser
        {
            UserName = "admin@admin.com",
            Email = "admin@admin.com",
            Nome = "Admin",
            Codice = "12345678", // Genera un codice fornitore univoco per ogni fornitore
            EmailConfirmed = true // Accettazione in automatico
        };
        // Creazione dell'utente con una password predefinita e lo aggiunge al ruolo Admin
        await userManager.CreateAsync(adminUser, "AdminPass1!");
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
    else
    {
        // Se l'utente Admin esiste già, lo aggiunge al ruolo Admin
        var adminUser = await userManager.FindByEmailAsync("fdfdf@∂fdf.com");
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}
}