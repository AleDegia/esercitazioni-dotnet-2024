using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using WebAppProdotti.Pages;



public class ProdottoDettaglioModel : PageModel
{
    public Prodotto Prodotto {get; set;}
    public void OnGet(string nome, string dettaglio, decimal prezzo)
    {
        Prodotto = new Prodotto {Nome = nome, Prezzo = prezzo, Dettaglio = dettaglio};
    }
}
