using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebAppProdotti.Pages;

public class ModificaPrezzoModel : PageModel
{
    public Prodotto Prodotto {get;set;}

    public void OnGet(string nome)
    {
        var json = System.IO.File.ReadAllText("wwwroot/listaJson.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        Prodotto = prodotti.FirstOrDefault(p => p.Nome == nome) ;
    }

    public IActionResult OnPost(decimal prezzo, string nome)
    {
        var json = System.IO.File.ReadAllText("wwwroot/listaJson.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        var prodotto = prodotti.FirstOrDefault(p => p.Nome == nome);
        prodotto.Prezzo = prezzo;
        // Prodotto.Dettaglio = dettaglio;

        System.IO.File.WriteAllText("wwwroot/listaJson.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        return RedirectToPage("Prodotti");
    }

}