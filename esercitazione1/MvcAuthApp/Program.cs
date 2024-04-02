using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcAuthApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() //per abilitare i ruoli (aggiunto io)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

//Crea un'istanza dell'applicazione
var app = builder.Build();

//aggiunto io (creo nuovo ambito di servizio tramite il metodo CreateScope())
using (var scope = app.Services.CreateScope())  
{
    //Viene ottenuto il provider di servizi all'interno dell'ambito di servizio appena creato e viene assegnato alla variabile services. Questo fornisce accesso ai servizi registrati all'interno di quell'ambito di servizio.
    var services = scope.ServiceProvider;

    try
    {
        // Risolvi il RoleManager dal provider di servizi. iene richiesto al provider di servizi di restituire un'istanza del servizio RoleManager<IdentityRole>. 
	    // RoleManager<IdentityRole> è una classe fornita da ASP.NET Identity che gestisce i ruoli degli utenti nell'applicazione.
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        //Chiamata al metodo per assicurare che i ruoli esistano NEL DATABASE
        await ApplicationDbInitializer.EnsureRolesAsync(roleManager);
    }
    catch(Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Un errore è avvenuto durante la creazione dei ruoli");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await SeedAdminUser(userManager, roleManager);  //chiamo la funzione 
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


async Task SeedAdminUser(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
{
    //assicurati che il ruolo admin esista
    if(!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    //Crea l'utente admin se non esiste
    if(await userManager.FindByNameAsync("info2@admin.com")==null)
    {
        var user = new IdentityUser
        {
            UserName = "info2@admin.com",
            Email = "info2@admin.com",
            EmailConfirmed = true,
        };

        var result = await userManager.CreateAsync(user, "Admin123!");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}


public static class ApplicationDbInitializer
{
    public static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        var roles = new List<string> {"Admin", "User"};
        foreach(var role in roles)
        {
            if(!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}

