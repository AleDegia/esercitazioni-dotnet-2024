using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;
using RazorWebApp.Pages;
using System.Collections.Generic;

namespace RazorWebApp.Pages
{
    public class ProdottoModel : PageModel
    {
        public IEnumerable<Prodotto> Prodotti { get; set; }
        public void OnGet()
        {
            Prodotti = new List<Prodotto>
            {
                new Prodotto { Nome = "Prodotto 1", Prezzo = 100 },
                new Prodotto { Nome = "Prodotto 2", Prezzo = 200 },
                new Prodotto { Nome = "Prodotto 3", Prezzo = 300 }
            };
        }
    }
}