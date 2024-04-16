// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MvcIdentityQuiz.Areas.Identity.Pages.Account
{
	public class RegisterModel : PageModel
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;
		private readonly IUserStore<IdentityUser> _userStore;
		private readonly IUserEmailStore<IdentityUser> _emailStore;
		private readonly ILogger<RegisterModel> _logger;
		private readonly IEmailSender _emailSender;

		public RegisterModel(
			UserManager<AppUser> userManager,
	SignInManager<AppUser> signInManager,
	ILogger<RegisterModel> logger,
	IEmailSender emailSender)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_logger = logger;
			_emailSender = emailSender;
		}

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		[BindProperty]
		public InputModel Input { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public string ReturnUrl { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public IList<AuthenticationScheme> ExternalLogins { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public class InputModel
		{
			/// <summary>
			///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
			///     directly from your code. This API may change or be removed in future releases.
			/// </summary>
			[Required]
			[EmailAddress]
			[Display(Name = "Email")]
			public string Email { get; set; }

			/// <summary>
			///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
			///     directly from your code. This API may change or be removed in future releases.
			/// </summary>
			[Required]
			[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			[DataType(DataType.Password)]
			[Display(Name = "Password")]
			public string Password { get; set; }

			/// <summary>
			///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
			///     directly from your code. This API may change or be removed in future releases.
			/// </summary>
			[DataType(DataType.Password)]
			[Display(Name = "Confirm password")]
			[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
			public string ConfirmPassword { get; set; }

			[Required]
			[Display(Name = "Nome")]
			public string Nome { get; set; }


			[Required]
			[Display(Name = "Stato Attivo")]
			public bool Stato { get; set; }



		}
		
		// metodo per la creazione di un codice di 8 caratteri in automatico numeri ed caratteri maiuscoli ed minuscoli 
		public string SetCodice()
		{
			string Codice = "";
			Random random = new Random();
			for (int i = 0; i < 8; i++)
			{
				int casuale = random.Next(0, 3);
				switch (casuale)
				{
					case 0:
						Codice += (char)random.Next(48, 58);
						break;
					case 1:
						Codice += (char)random.Next(65, 91);
						break;
					case 2:
						Codice += (char)random.Next(97, 123);
						break;
				}
			}
			return Codice;
		}
		
		public async Task OnGetAsync(string returnUrl = null)
		{
			ReturnUrl = returnUrl;
			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
		}

		public async Task<IActionResult> OnPostAsync(string returnUrl = null)

		{
			returnUrl = returnUrl ?? Url.Content("~/");
			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
			if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = Input.Email, Email = Input.Email };
                var result = _userManager.CreateAsync(user, Input.Password).Result;

                if (result.Succeeded)
                {
                    // Creare un'istanza di Utente per memorizzare le informazioni aggiuntive
                    var userDetails = new Utente
                    {
                        Nome = Input.Nome,
                        Password = Input.Password,
                        Record = 0, // O qualsiasi valore predefinito desiderato
                        Punteggi = new int[0] // O qualsiasi valore predefinito desiderato
                    };

                    // Aggiungi l'utente al ruolo "User"
                    await _userManager.AddToRoleAsync(user, "User");
                    //aggiung l'utente al json degli utenti
                    var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
                    List<Utente>? utenti = JsonConvert.DeserializeObject<List<Utente>>(json);     //creo lista utenti coi dati del json
                    utenti.Add(userDetails);
      
                    System.IO.File.WriteAllText("wwwroot/json/utenti.json", JsonConvert.SerializeObject(utenti, Formatting.Indented));

                    // Effettuiamo l'accesso automatico dell'utente appena registrato, senza mantenere l'accesso persistente
                    _signInManager.SignInAsync(user, isPersistent: false).Wait();
                    return RedirectToPage("/Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Se si verifica un errore, ricarica il form con i dati forniti
            return Page();
		}
	}
}