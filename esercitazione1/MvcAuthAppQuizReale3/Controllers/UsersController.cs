using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MvcAppunt.Models;
using MvcAppunt.Data;
using System.Linq;

public class UsersController : Controller
{

	private readonly ApplicationDbContext _context;
	private readonly UserManager<AppUser> _userManager;

	public UsersController(ApplicationDbContext context, UserManager<AppUser> userManager)
	{
		_context = context;
		_userManager = userManager;
	}

	// metodo per visualizzare i dettagli di un fornitore
	[Authorize] //solo gli utenti loggati possono accederci
	public IActionResult Index(string email) //Prende un parametro email che rappresenta l'email dell'utente che si desidera visualizzare.
	{
        //trova il primo utente nel database la cui email corrisponde a quella fornito.
		var fornitore = _context.Users.FirstOrDefault(u => u.Email == email);
		if (fornitore == null)
		{
            //Se l'utente non viene trovato, restituisce una risposta HTTP 404 (NotFound).
			return NotFound();
		}
        //Altrimenti, restituisce la vista Index passando l'utente trovato come modello.
		return View(fornitore);
	}

	// metodo per attivare/disattivare un fornitore
	[Authorize(Roles = "Admin")]    //solo gli utenti con ruolo 'Admin'possono accedere al metodo
	[HttpPost]
    //id che rappresenta l'ID dell'utente di cui si desidera attivare o disattivare lo stato.
	public async Task<IActionResult> ToggleActive(string id)
	{
        /*UserManager<AppUser> fornisce una serie di metodi utili per interagire con gli utenti nel sistema, 
        come la ricerca, la creazione, l'aggiornamento e la rimozione degli utenti. Utilizzando _userManager, 
        hai accesso a tutti questi metodi senza dover implementare manualmente la logica per gestire gli utenti.*/
		var fornitore = await _userManager.FindByIdAsync(id);
		if (fornitore == null)
		{
			return NotFound();
		}

		fornitore.Stato = !fornitore.Stato;
		await _userManager.UpdateAsync(fornitore);

		return RedirectToAction(nameof(Index), new { email = fornitore.Email });
	}

}