using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgettoRazorQuiz;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

using ProgettoRazorQuiz.Pages;



    public class LoginModel : PageModel
    {
        [BindProperty]
        public Utente Utente { get; set; } // Definisce una proprietà Utente che verrà utilizzata per il binding dei dati del modulo HTML.

        [BindProperty]
        public bool NomeEsistente { get; set; } // Indica se il nome utente esiste già.
        public bool PasswordGiusta {get;set;}

        public string ClasseBordo { get; set; } = ""; // Variabile per la classe CSS "border border-primary".
        

        //TempData è una raccolta di dati che persiste solo fino alla successiva richiesta HTTP. In pratica, consente di passare dati temporanei tra azioni del controller (o pagine Razor) durante le richieste HTTP.
        public void OnGet()
        {
            ClasseBordo = TempData["ClasseBordo"]?.ToString() ?? ""; // ?? (null-coalescing) restituisce il valore a sinistra se non è nullo
            if(TempData["NomeEsistente"]!=null)
            {
            NomeEsistente=(bool)TempData["NomeEsistente"];
            }
            else{
            NomeEsistente= true;
            }

            if(TempData["PasswordGiusta"]!=null)
            {
            PasswordGiusta=(bool)TempData["PasswordGiusta"];
            }
            else{
            PasswordGiusta= true;   
            }
        }

        public IActionResult OnPost(string username, string password)
        {
           
            NomeEsistente = false; // Inizializza la variabile a false.
            PasswordGiusta =false;
            ClasseBordo = "border border-primary"; // Imposta la classe di bordo.
            

            TempData["ClasseBordo"] = ClasseBordo; // Salva la classe di bordo nei dati temporanei.

            // Legge il contenuto del file JSON degli utenti.
            var json = System.IO.File.ReadAllText("wwwroot/users.json");

            // Deserializza il JSON in una lista di Utente, o inizializza una nuova lista se il JSON è vuoto.
            var users = JsonConvert.DeserializeObject<List<Utente>>(json) ?? new List<Utente>();

            // Controlla se il nome utente esiste già e se la password è quella di quell'utente li
            foreach (var user in users)
            {
                if (user.Nome == username && user.Password ==password)
                {
                    PasswordGiusta=true;
                    //In your case, you want to pass the username parameter to the "Modalita" page. By using new { username = username }, you're creating an anonymous object with a property named username, and you're setting its value to the username variable that you have in your method's scope.
                    return RedirectToPage("/Modalita", new { username = username });
                }
            }
            foreach (var user in users)
            {
                if (user.Nome == username)
                {   
                    System.Console.WriteLine("alua?");
                    NomeEsistente=true;
                    TempData["NomeEsistente"] = NomeEsistente;
                }
                if (user.Password == password)
                {   
                    PasswordGiusta=true;
                    TempData["PasswordGiusta"] = PasswordGiusta;
                }
            }
            TempData["NomeEsistente"] = NomeEsistente;
            TempData["PasswordGiusta"] = PasswordGiusta;
            
            return RedirectToPage("/Login", new { classeBordo = TempData["ClasseBordo"] });

            
        }
    }



