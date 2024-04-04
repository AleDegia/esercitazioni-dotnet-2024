
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QuizIdentity2.Pages;

public class PartitaModel : PageModel
{
  [BindProperty]
  public List<string> ScelteUtente { get; set; }
  public Utente Utente { get; set; }
  public IEnumerable<Domanda> Domande { get; set; }

    private readonly ILogger<PartitaModel> _logger;

    public PartitaModel(ILogger<PartitaModel> logger)
    {
        _logger = logger;
    }


    public void OnGet(string nome)
    {
      var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
      var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
      Utente = utenti.FirstOrDefault(u => u.Nome == nome); // il nostro utente selezionato
      var domandejson = System.IO.File.ReadAllText("wwwroot/json/domande.json"); 
      Domande = JsonConvert.DeserializeObject<List<Domanda>>(domandejson);
    }


    public IActionResult OnPost(string nome)
  {
    return RedirectToPage("Validazione", new { nome, ru = ScelteUtente }); 
  }



}