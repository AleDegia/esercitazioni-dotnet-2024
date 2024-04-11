using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcAuthAppQuizReale3.Data;
//va messo anche questo
using MvcAuthAppQuizReale3.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//messo AppUser al posto di IdentityUser (per l'entità utente personalizzata)
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
//aggiungo ruoli
.AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();//indica di utilizzare AppUser come classe per l'entità utente personalizzata.

var app = builder.Build();

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//aggiunto, Hai definito una route personalizzata con il nome "user" che instrada le richieste con il percorso "User/{email}" alla controller "Users" e all'azione "Index"
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "user",
		pattern: "User/{email}",
		defaults: new { controller = "Users", action = "Index" });
});

//tutte le richieste che non corrispondono a route specifiche verranno instradate alla controller "Home" e all'azione "Index".
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// Seeding del database aggiunto
using (var scope = app.Services.CreateScope())
{
	var serviceProvider = scope.ServiceProvider;
	try
	{
		var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
		var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
		await SeedData.InitializeAsync(userManager, roleManager);
	}
	catch (Exception ex)
	{
		var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
		logger.LogError(ex, "Un errore è avvenuto durante il seeding del database.");
	}
}


app.Run();
