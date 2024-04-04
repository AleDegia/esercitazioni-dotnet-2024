using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QuizIdentity2.Pages;

public class PartitaDoppiaModel : PageModel
{

    private readonly ILogger<PartitaDoppiaModel> _logger;

    public PartitaDoppiaModel(ILogger<PartitaDoppiaModel> logger)
    {
        _logger = logger;
    }

  public Utente Utente { get; set; }
  public IEnumerable<Domanda> DomandeDoppie { get; set; }

    public void OnGet(string nome)
    {
      var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
      var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
      Utente = utenti.FirstOrDefault(u => u.Nome == nome); 
      var domandejson = System.IO.File.ReadAllText("wwwroot/json/domandedoppie.json"); 
      DomandeDoppie = JsonConvert.DeserializeObject<List<Domanda>>(domandejson);
    }

    public IActionResult OnPost(string nome)
  {
      var domandejson = System.IO.File.ReadAllText("wwwroot/json/domandedoppie.json"); 
      var domande = JsonConvert.DeserializeObject<List<Domanda>>(domandejson);

      int numeroDomande = domande.Count;
      string[] opzioni = ["A", "B", "C"]; 
      int numOpz = opzioni.Length;
      string risp = "opzione";

      int boxes = numeroDomande * numOpz;

      var risposteUtente = new List<string>();

      for (int o = 1; o <= numeroDomande; o++)
      {
        foreach (string vocale in opzioni)
        {
          risp = o + "opzione" + vocale;
          risposteUtente.Add(Request.Form[risp]);
        }
      }

      string input = string.Join(", ", risposteUtente);

     input = input.Trim();

        // Dividi la stringa in base alle virgole
        string[] elements = input.Split(',');

        // Crea un nuovo array di stringhe con 9 posti
        string[] result = new string[boxes];

        // Copia gli elementi dalla stringa originale al nuovo array
        for (int i = 0; i < elements.Length; i++)
        {
            // Se l'elemento è vuoto, assegna "Null", altrimenti assegna l'elemento stesso
            result[i] = string.IsNullOrWhiteSpace(elements[i]) ? "Nada" : elements[i].Trim();
        }

     _logger.LogInformation($"Valori di ScelteUtente: {string.Join(", ", risposteUtente)}");
     _logger.LogInformation($"Valori di ScelteUtente: {string.Join(", ", result)}");
    
      return RedirectToPage("ValidazioneDoppia", new { nome, ru = result, numOpz}); 
  }

}
