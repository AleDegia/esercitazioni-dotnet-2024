using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace MvcIdentityQuiz.Models;

public class PartitaMultiplaModel
{
  public string Nome { get; set; }
  public IEnumerable<Domanda> Domande { get; set; }
}