using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppDa0.Pages;


    public class DettaglioPersonaModel : PageModel
    {
        // il logger serve per usare il _logger.LogInformation("testo prova") per visualizzare a console.
        private readonly ILogger<DettaglioPersonaModel> _logger;
        // aggiungi un costruttore per l'oggetto ILogger
        public DettaglioPersonaModel(ILogger<DettaglioPersonaModel> logger)
        {
            _logger = logger;
        }
        public Persona Persona { get; set; }

        public void OnGet(string nome)   //il parametro deve avere lo stesso nome del asp-route-.. senno non viene trovato a cosa passare il valore       
        {
            var json = System.IO.File.ReadAllText("wwwroot/persone.json");
            var personeList = JsonConvert.DeserializeObject<List<Persona>>(json);   //converto da json a lista/collection
            Persona = personeList.FirstOrDefault(p => p.Nome == nome);     //Cerca la prima persona nella lista che ha il campo Nome uguale al valore del parametro Nome e assegna il risultato trovato alla proprietà Persona..
        }

    }