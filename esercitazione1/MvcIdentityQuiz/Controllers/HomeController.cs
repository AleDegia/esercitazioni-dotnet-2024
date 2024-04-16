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
    public IActionResult Punteggi(string nome)
    {
        var model = new PunteggiModel{};
      var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
      var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
      model.Utente = utenti.FirstOrDefault(u => u.Nome == nome);

      return View(model);
    }


    [HttpGet]
    

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


