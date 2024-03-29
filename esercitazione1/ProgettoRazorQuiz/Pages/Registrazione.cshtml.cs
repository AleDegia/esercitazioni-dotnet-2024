using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgettoRazorQuiz;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using ProgettoRazorQuiz.Models;

namespace ProgettoRazorQuiz.Pages
{
    public class RegistrazioneModel : PageModel
    {
        [BindProperty]
        public Utente Utente { get; set; } // Definisce una proprietà Utente che verrà utilizzata per il binding dei dati del modulo HTML.

        [BindProperty]
        public bool NomeEsistente { get; set; } // Indica se il nome utente esiste già.

        public string ClasseBordo { get; set; } = ""; // Variabile per la classe CSS "border border-primary".

        public Punteggio Punteggio {get; set;}


        //TempData è una raccolta di dati che persiste solo fino alla successiva richiesta HTTP. In pratica, consente di passare dati temporanei tra azioni del controller (o pagine Razor) durante le richieste HTTP.
        public void OnGet()//quando carico la pagina Registrazione.cshtml
        {
            //serve a dire che ClasseBordo è "" se non è ancora stato inizializzato ( Si tenta di recuperare il valore associato alla chiave "ClasseBordo" da TempData. Se questa chiave non è presente o il suo valore è nullo, viene restituito null)
            ClasseBordo = TempData["ClasseBordo"]?.ToString() ?? ""; // ?? (null-coalescing) restituisce il valore a sinistra se non è nullo
            NomeEsistente = TempData.ContainsKey("NomeEsistente") ? (bool)TempData["NomeEsistente"] : false;
        }

        public IActionResult OnPost(string username, string password)//quando submitto i dati col form
        {
            NomeEsistente = false; // Inizializza la variabile a false.
            ClasseBordo = "border border-primary"; // Imposta la classe di bordo.
            

            TempData["ClasseBordo"] = ClasseBordo; // Salva la classe di bordo nei dati temporanei.

            // Legge il contenuto del file JSON degli utenti.
            var json = System.IO.File.ReadAllText("wwwroot/users.json");
            var jsonPunteggi = System.IO.File.ReadAllText("wwwroot/punteggiUsers.json");

            // Deserializza il JSON in una lista di Utente, o inizializza una nuova lista se il JSON è vuoto.
            var users = JsonConvert.DeserializeObject<List<Utente>>(json) ?? new List<Utente>();
            var punteggi = JsonConvert.DeserializeObject<List<Punteggio>>(jsonPunteggi);

            // Controlla se il nome utente esiste già nella lista degli utenti.
            foreach (var user in users)
            {
                if (user.Nome == username)
                {
                    NomeEsistente = true; // Imposta la variabile a true se il nome utente esiste già.
                    break; // Esce dal ciclo una volta trovato un nome utente corrispondente.
                }
            }

            TempData["NomeEsistente"] = NomeEsistente;

            // Se il nome utente non esiste già, aggiunge un nuovo utente alla lista.
            if (!NomeEsistente)
            {
                var nuovoUtente = new Utente
                {
                    Nome = username,
                    Password = password
                };

                users.Add(nuovoUtente); // Aggiunge il nuovo utente alla lista degli utenti.

                // Serializza la lista aggiornata degli utenti in formato JSON.
                var jsonAggiornato = JsonConvert.SerializeObject(users, Formatting.Indented);

                // Scrive il JSON aggiornato nel file degli utenti.
                System.IO.File.WriteAllText("wwwroot/users.json", jsonAggiornato);

                var userInPunteggio = new Punteggio
                {
                    nome = username,
                    punteggio = 0
                };

                punteggi.Add(userInPunteggio);
                
                // Serializza la lista aggiornata degli utenti in formato JSON.
                var jsonAggiornatoPunteggi = JsonConvert.SerializeObject(punteggi, Formatting.Indented);

                // Scrive il JSON aggiornato nel file degli utenti.
                System.IO.File.WriteAllText("wwwroot/punteggiUsers.json", jsonAggiornatoPunteggi);

                // Reindirizza l'utente alla pagina di login.
                return RedirectToPage("Login");
            }
            else
            {
                // Se il nome utente esiste già, reindirizza l'utente alla pagina di registrazione con la classe di bordo.
                return RedirectToPage("/Registrazione", new { classeBordo = TempData["ClasseBordo"] });
            }
        }
    }
}
