using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Pages;

namespace WebAppProdotti.Pages;


public class ProdottiModel : PageModel
{
    public IEnumerable<Prodotto> Prodotti {get; set;}
    private readonly ILogger<ProdottiModel> _logger;

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(decimal? maxPrezzo, decimal? minPrezzo, int? pageIndex)
    {
        Prodotti = new List<Prodotto>
        {
            new Prodotto {Nome = "Prodotto 1", Prezzo = 100, Dettaglio = "ciao 1"},
            new Prodotto {Nome = "Prodotto 2", Prezzo = 200, Dettaglio = "ciao 2"},
            new Prodotto {Nome = "Prodotto 3", Prezzo = 300, Dettaglio = "ciao 3"},
            new Prodotto {Nome = "Prodotto 4", Prezzo = 100, Dettaglio = "ciao 4"},
            new Prodotto {Nome = "Prodotto 5", Prezzo = 200, Dettaglio = "ciao 5"},
            new Prodotto {Nome = "Prodotto 6", Prezzo = 300, Dettaglio = "ciao 6"},
            new Prodotto {Nome = "Prodotto 7", Prezzo = 100, Dettaglio = "ciao 7"},
            new Prodotto {Nome = "Prodotto 8", Prezzo = 200, Dettaglio = "ciao 8"},
            new Prodotto {Nome = "Prodotto 9", Prezzo = 300, Dettaglio = "ciao 9"},
            new Prodotto {Nome = "Prodotto 10", Prezzo = 100, Dettaglio = "ciao 10"},
        };
        if(minPrezzo.HasValue)
        {
            Prodotti = Prodotti.Where(p => p.Prezzo >= minPrezzo);
            _logger.LogInformation($"minPrezzo: {minPrezzo}", minPrezzo);
        }
        if(maxPrezzo.HasValue)
        {
            Prodotti = Prodotti.Where(p => p.Prezzo <= maxPrezzo);
            _logger.LogInformation($"maxPrezzo: {maxPrezzo}", maxPrezzo);
        }
        // _logger.LogInformation("Prodotti filtrati per prezzo");
        Prodotti = Prodotti.Skip(((pageIndex ?? 1)-1)*2).Take(5);
    }
}

