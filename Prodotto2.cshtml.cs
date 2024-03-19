using Microsoft.AspNetCore.Mvc;  // IActionResult e Controller
using Microsoft.AspNetCore.Mvc.RazorPages;   // PageModel
using WebAppProdotti.Models;
using System.Collections.Generic;



namespace RazorWebApp.Pages
{
    public class ProdottoModel2 : PageModel
    {
        public IEnumerable<Prodotto2> Prodotti { get; set; }     //collezione di oggetti prodotto
        public int numeroPagine { get; set; }                   //numero pagine

        //Questo è il metodo OnGet che viene chiamato quando si richiede la pagina. Prende tre parametri opzionali: minPrezzo, maxPrezzo, e pageIndex.
        public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)   //la OnGet riceve questi valori dal form della cshtml
        {
            Prodotti = new List<Prodotto2>   //aggiungo dei prodotti alla lista
            {
                new Prodotto2 { Nome = "Prodotto 1", Prezzo = 100, Dettaglio="Dettaglio 1"},
                new Prodotto2 { Nome = "Prodotto 2", Prezzo = 200, Dettaglio="Dettaglio 2"},
                new Prodotto2 { Nome = "Prodotto 3", Prezzo = 300, Dettaglio="Dettaglio 3"},
                new Prodotto2 { Nome = "Prodotto 4", Prezzo = 400, Dettaglio="Dettaglio 4"},
                new Prodotto2 { Nome = "Prodotto 5", Prezzo = 500, Dettaglio="Dettaglio 5"},
                new Prodotto2 { Nome = "Prodotto 6", Prezzo = 600, Dettaglio="Dettaglio 6"},
                new Prodotto2 { Nome = "Prodotto 7", Prezzo = 700, Dettaglio="Dettaglio 7"},
                new Prodotto2 { Nome = "Prodotto 8", Prezzo = 800, Dettaglio="Dettaglio 8"},
                new Prodotto2 { Nome = "Prodotto 9", Prezzo = 900, Dettaglio="Dettaglio 9"},
                new Prodotto2 { Nome = "Prodotto 10", Prezzo = 1000, Dettaglio="Dettaglio 10"},
                new Prodotto2 { Nome = "Prodotto 11", Prezzo = 1100, Dettaglio="Dettaglio 11"}
            };
            if (minPrezzo.HasValue)
            {
                Prodotti = Prodotti.Where(p => p.Prezzo >= minPrezzo);  //prendo p(il prodotto) quando p.Prezzo >= minPrezzo
            }
            if (maxPrezzo.HasValue)
            {
                Prodotti = Prodotti.Where(p => p.Prezzo <= maxPrezzo);
            }
            //Qui viene calcolato il numero totale di pagine necessarie per visualizzare tutti i prodotti. Questo viene fatto dividendo il numero totale di prodotti per 5 (il numero di prodotti visualizzati per pagina) e arrotondando per eccesso usando Math.Ceiling.
            numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 5.0);
            Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 5).Take(5);
            // Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 5).Take(5);
            // numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 2.0);
        }
    }
}