using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebAppProdotti.Pages;

// namespace WebAppProdotti.Pages;

public class AggiungiProdottoModel : PageModel
{
    public void OnGet()
    {

    }

    //in questo metodo leggo il json e lo converto in lista prodotti, ci aggiungo il prodotto e riconverto in json
    public IActionResult OnPost(string nome, decimal prezzo, string dettaglio)
    {
        var json = System.IO.File.ReadAllText("wwwroot/listaJson.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        prodotti.Add(new Prodotto {Nome = nome, Prezzo = prezzo, Dettaglio = dettaglio});   
        //salva il file json formattato
        System.IO.File.WriteAllText("wwwroot/listaJson.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        return RedirectToPage("Prodotti");
    }
}