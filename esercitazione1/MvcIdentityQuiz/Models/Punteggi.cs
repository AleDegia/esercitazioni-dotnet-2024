using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace MvcIdentityQuiz.Models;

public class PunteggiModel
{
public Utente? Utente { get; set; }

public List <int> Punteggi { get; set; }

public int Record {get; set;}
}