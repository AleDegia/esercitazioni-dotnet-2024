using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace MvcIdentityQuiz.Models;

public class PartitaModel
{

[BindProperty]
  public List<string> ScelteUtente { get; set; }
  public string Nome { get; set; }
  public IEnumerable<Domanda> Domande { get; set; }

  public Utente Utente{ get; set; }
  public int[] Punteggi { get; set; }

  public int[] Record {get; set; }

}