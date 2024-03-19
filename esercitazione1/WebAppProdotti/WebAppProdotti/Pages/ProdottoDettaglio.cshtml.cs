using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Pages;


    public class ProdottoDettaglioModel : PageModel
    {
        // aggiungi un campo privato per l'oggetto ILogger
        private readonly ILogger<ProdottoDettaglioModel> _logger;
        // aggiungi un costruttore per l'oggetto ILogger
        public ProdottoDettaglioModel(ILogger<ProdottoDettaglioModel> logger)
        {
            _logger = logger;
        }
        public Prodotto Prodotto { get; set; }
        public void OnGet(string nome, string dettaglio, decimal prezzo)
        {
           /* Prodotto = new Prodotto { Nome = nome, Prezzo = prezzo, Dettaglio=dettaglio };
            // aggiungi un log
            _logger.LogInformation("Dettaglio prodotto visualizzato");
            */
            var json = System.IO.File.ReadAllText("./wwwroot/listaJson.json");
            var Prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
            Prodotto = Prodotti.FirstOrDefault(p => p.Nome == nome);

        }
    }
