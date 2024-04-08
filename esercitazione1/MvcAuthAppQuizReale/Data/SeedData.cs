
using Microsoft.AspNetCore.Identity;
public class SeedData{
    public static async Task InitializeAsync(UserManager<AppUser> userManager, 
    RoleManager<IdentityRole> roleManager)
    {
        //Definisce un array di nomi di ruoli (roleNames) che devono essere creati se non esistono nel sistema.
        string[] roleNames = {"Admin", "Fornitore", "User"};
        //Itera attraverso l'array dei nomi dei ruoli e controlla se ogni ruolo esiste già. 
        foreach (var roleName in roleNames)
        {
            if(!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        //Creazione dell utente admin se non esiste
        if(await userManager.FindByEmailAsync("admin@admin.com")== null)
        {
            var adminUser = new AppUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                Nome = "Admin",
                CodiceFornitore = "12345678",   //genera un codice fornitore univoco per ogni fornitore
                EmailConfirmed = true //accettazione in automatico
            };
            await userManager.CreateAsync(adminUser, "AdminPass1!");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
        else
        {
            var adminUser = await userManager.FindByEmailAsync("fsfsfs@fsf.com");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}