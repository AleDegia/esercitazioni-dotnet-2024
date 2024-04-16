using Microsoft.AspNetCore.Identity; 

public class SeedData
{
    // Metodo principale per inizializzare il database con dati di seeding
	public static async Task InitializeAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
	{
		// Creazione dei ruoli se non esistono
		string[] roleNames = { "Admin", "User" };
		foreach (var roleName in roleNames)
		{
             // Verifica se il ruolo esiste già nel database
			if (!await roleManager.RoleExistsAsync(roleName))
			{
                // Se il ruolo non esiste, crea il ruolo (IdentityRole è una classe fornita dal framework ASP.NET Core Identity. Rappresenta un ruolo all'interno del sistema di autenticazione e autorizzazione.)
				await roleManager.CreateAsync(new IdentityRole(roleName));
			}
		}

		// Creazione dell'utente Admin se non esiste (se non trova sta mail nel database lo crea)
		if (await userManager.FindByEmailAsync("fdfdf@∂fdf.com") == null)
	  {
		  var adminUser = new AppUser
		  {
			  UserName = "admin@admin.com",
			  Email = "admin@admin.com",
			  Nome = "Admin",
			//   EmailConfirmed = true // Accettazione in automatico
		  };
          //   // Creazione dell'utente con una password predefinita e lo aggiunge al ruolo Admin
		  await userManager.CreateAsync(adminUser, "AdminPass1!"); //crea la password
		  await userManager.AddToRoleAsync(adminUser, "Admin"); //aggiunge al ruolo admin
	  }
	  else
	  {
        // Se l'utente Admin esiste già, lo aggiunge al ruolo Admin
		  var adminUser = await userManager.FindByEmailAsync("fdfdf@∂fdf.com");
		  await userManager.AddToRoleAsync(adminUser, "Admin");
	  }
		
	}
}