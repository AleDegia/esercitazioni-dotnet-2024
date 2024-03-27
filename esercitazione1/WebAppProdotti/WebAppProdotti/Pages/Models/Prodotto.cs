using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppProdotti.Pages;

public class Prodotto
{
    public string Nome {get; set;}
    public decimal Prezzo {get; set;}
    public string Dettaglio {get; set;}
}