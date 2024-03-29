using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgettoRazorQuiz;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ProgettoRazorQuiz.Pages
{
    public class ModalitaModel : PageModel
    
    {
        public string Username { get; set; }

        public void OnGet(string username)
        {
            Username = username;
        

            // Legge il contenuto del file JSON degli utenti.
            var json = System.IO.File.ReadAllText("wwwroot/domandeFacili.json");

            // Deserializza il JSON in una lista di Domande
            var domandeFacili = JsonConvert.DeserializeObject<List<Domanda>>(json);
        }

    }
}