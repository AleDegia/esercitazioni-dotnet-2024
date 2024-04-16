using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcIdentityQuiz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Newtonsoft.Json;

namespace MvcIdentityQuiz.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {

        // IndexViewModel model = new IndexViewModel { }; //oggetto che serve a passare i dati alla vista

        return View();
    }

    [HttpGet]
    public IActionResult Partita()
    {

    // quest'oggetto serve per passare i dati del model alla view
    var model = new PartitaModel
    { };
    var json = System.IO.File.ReadAllText("wwwroot/json/domande.json");
    var domande = JsonConvert.DeserializeObject<List<Domanda>>(json)!;
    model.Domande = domande;
    // foreach (var domanda in domande)
    // {
    // System.Console.WriteLine(domanda.Id);
    // System.Console.WriteLine(domanda.TestoDomanda);
    // System.Console.WriteLine(domanda.Opzioni);
    // }


        return View(model);
    }


<<<<<<< HEAD
    
=======
    [HttpPost]
public IActionResult PunteggiPost(List<string> risposte )
{
    var model = new PartitaModel{};
    
    var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
    var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);

    string nomeUtenteDaCercare =  User.Identity.Name;

    
    // Trova il primo utente con il nome specificato
    var utente = utenti.FirstOrDefault(u => u.Nome == nomeUtenteDaCercare);
    model.Utente = utente;
    if (utente != null)
{
      // Ora puoi accedere ai punteggi dell'utente trovato
    model.Punteggi = utente.Punteggi;
} else
{
    model.Punteggi=[1,2,3,4];
}

string tipo = "singola";
        
       string Nome = model.Nome;
List<string> ru = model.ScelteUtente;
tipo = "singola";

// Set values in ViewData
ViewData["Tipo"] = tipo;
ViewData["Nome"] = Nome;
ViewData["Ru"] = ru;

return View(model);
}
>>>>>>> 3a604f090cf949c1c534cad82e633700f2fac7d0



    [HttpGet]
    public IActionResult PartitaMultipla()
    {

        // quest'oggetto serve per passare i dati del model alla view
        var model = new PartitaMultiplaModel
        { };
        var json = System.IO.File.ReadAllText("wwwroot/json/domandemultiple.json");
        var domande = JsonConvert.DeserializeObject<List<Domanda>>(json)!;
        model.Domande = domande;


        return View(model);
    }

    [HttpGet]
<<<<<<< HEAD
    public IActionResult Punteggi(string nome)
    {
        var model = new PunteggiModel{};
      var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
      var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
      model.Utente = utenti.FirstOrDefault(u => u.Nome == nome);

      return View(model);
    }


    [HttpGet]
    
=======
    public IActionResult Punteggi(string Nome, List<string> ScelteUtente, string tipo)
    {
        var model = new PunteggiModel{};
        var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
    var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
     var Utente = utenti.FirstOrDefault(u => u.Nome == Nome);
        var verificas = new List<Verifica>();
    int punteggio = 0;
    @ViewData["tipo"] = tipo;
    
    if (tipo == "multipla")
    {
      var domandejson = System.IO.File.ReadAllText("wwwroot/json/domandemultiple.json");
      var Domande = JsonConvert.DeserializeObject<List<Domanda>>(domandejson);
      int numeroDomande = Domande.Count;
      string risp = "opzione";
      
      int e = 0;
    foreach (string rispostaUtente in ScelteUtente) // prendo tutte le caselle, quelle vuote hanno scritto "Nada"
    {
      e++;
      for (int o = 1; o <= numeroDomande; o++) // mi da il numero della domanda
      {
        var Domanda = Domande.FirstOrDefault(dmd => dmd.Id == o);
        int numeroOpzioni = Domanda.Opzioni.Length;
        for (int lettera = 0; lettera < numeroOpzioni; lettera++) // mi seleziona la lettera dell'opzione
        {
          risp = o + "opzione" + lettera;
          if (rispostaUtente == risp)
          {
            int numeroRisposteGiuste = Domanda.Risposte.Length;
            int counter = 0;
            foreach (string rispostaGiusta in Domanda.Risposte)
            {
              if (Domanda.Opzioni[lettera] == rispostaGiusta)
              {
                var giusta = new Verifica { Id = e, DomandaId=o, RisposteGiuste = Domanda.Risposte, RispostaUtente = Domanda.Opzioni[lettera], Uguali = true };
                verificas.Add(giusta);
                punteggio++;
              }
              else
              {
                counter++;
              }
            }
            if (counter == numeroRisposteGiuste)
            {
              var sbagliata = new Verifica { Id = e, DomandaId=o, RisposteGiuste = Domanda.Risposte, RispostaUtente = Domanda.Opzioni[lettera], Uguali = false };
              verificas.Add(sbagliata);
              punteggio--;
            }
          }
        }
      }
    }
    
    }
    else 
    {
      var domandejson = System.IO.File.ReadAllText("wwwroot/json/domande.json");
      var Domande = JsonConvert.DeserializeObject<List<Domanda>>(domandejson);
      int lunghezza = ScelteUtente.Count;
      for (int n = 0; n < lunghezza; n++)
      {
        var domanda = Domande.FirstOrDefault(d => d.Opzioni.Contains(ScelteUtente[n]));
        if (domanda.Risposte.Contains(ScelteUtente[n]))
        {
          verificas.Add(new Verifica { Id = n + 1, RispostaUtente = ScelteUtente[n], RisposteGiuste = domanda.Risposte, Uguali = true });
          punteggio++;
        }
        else
        {
          verificas.Add(new Verifica { Id = n + 1, RispostaUtente = ScelteUtente[n], RisposteGiuste = domanda.Risposte, Uguali = false });
        }
      }
    }
  
    List<Verifica> Verifiche = verificas;
    int record = model.Utente.Record;
    if (punteggio > record)
    {
      record = punteggio;
    }

    int vecchiPunteggi = model.Utente.Punteggi.Length;
    int[] scores = new int[vecchiPunteggi + 1];

    for (int s = 0; s < vecchiPunteggi; s++)
    {
      scores[s] = model.Utente.Punteggi[s];
    }

    scores[vecchiPunteggi] = punteggio;
    model.Utente.Punteggi = scores;
    model.Utente.Record = record;
    System.IO.File.WriteAllText("wwwroot/json/utenti.json", JsonConvert.SerializeObject(utenti, Formatting.Indented));
  
return View();
    }
>>>>>>> 3a604f090cf949c1c534cad82e633700f2fac7d0

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


