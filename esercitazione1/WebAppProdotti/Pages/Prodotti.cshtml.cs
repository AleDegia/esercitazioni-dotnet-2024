using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppProdotti.Pages;


public class ProdottiModel : PageModel
{
    public IEnumerable<Prodotto> Prodotti {get; set;}
    // private readonly ILogger<ProdottoModel> _logger;

    // public ProdottoModel(ILogger<ProdottoModel> logger)
    // {
    //     _logger = logger;
    // }

    public void OnGet()
    {
        Prodotti = new List<Prodotto>
        {
            new Prodotto {Nome = "Prodotto 1", Prezzo = 100, Dettaglio = "ciao"},
            new Prodotto {Nome = "Prodotto 2", Prezzo = 200, Dettaglio = "ciao"},
            new Prodotto {Nome = "Prodotto 3", Prezzo = 300, Dettaglio = "ciao"}
        };
    }
}

