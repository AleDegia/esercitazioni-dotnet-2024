using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QuizIdentity2.Pages;

public class ClassificaModel : PageModel
{
  public IEnumerable<Utente> Utenti { get; set; }

    public void OnGet()
    {
      var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
      var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
      Utenti = utenti.OrderByDescending(u => u.Record);
    }

}