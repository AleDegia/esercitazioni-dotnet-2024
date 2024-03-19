using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;  // IActionResult e Controller
using Microsoft.AspNetCore.Mvc.RazorPages;   // PageModel
using WebAppProdotti.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RazorWebApp.Pages
{
    public class ProdottoDettaglio : PageModel
    {
        public Prodotto2 Prodotto { get; set; }
        public void OnGet(string nome)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
            var prodotti = JsonConvert.DeserializeObject<List<Prodotto2>>(json);
            Prodotto = prodotti.FirstOrDefault(p => p.Nome == nome);
        }
    }
}