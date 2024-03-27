using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgettoRazorQuiz;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ProgettoRazorQuiz.Pages
{
    public class PartitaModel : PageModel
    
    {
        public string Username { get; set; }
        public Domanda domanda {get;set;}
        public List<Domanda> Domande { get; set; }


        public List<string> Risposte { get; set; } // Dizionario per associare l'ID della domanda alla risposta
        public string mod ="";

        public void OnGet(string username, string modalita)
        {
            Username = username;
            var json="";
            System.Console.WriteLine(modalita);
            
            if(modalita=="facile")
            {
            // Legge il contenuto del file JSON degli utenti.
            json = System.IO.File.ReadAllText("wwwroot/domandeFacili.json");
            mod=modalita;
            }
            else if(modalita=="media")
            {
                json = System.IO.File.ReadAllText("wwwroot/domandeNormali.json");
                mod=modalita;
            }
            else if(modalita=="difficile")
            {
                json = System.IO.File.ReadAllText("wwwroot/domandeDifficili.json");
                mod=modalita;
            }

            // Deserializza il JSON in una lista di Domande (ogni riga del JSON verrà assegnata a un oggetto Domanda. Ad esempio: l primo oggetto Domanda nella lista avrà Id uguale a 1, Domand uguale a "Qual è la capitale dell'Italia?", e così via.)
            Domande = JsonConvert.DeserializeObject<List<Domanda>>(json);
            
        }

        
        public IActionResult OnPost( List<string> Risposte, string username)
        {
            
            return RedirectToPage("/Punteggio", new { risposte = Risposte , username = username});
        }
    }
}