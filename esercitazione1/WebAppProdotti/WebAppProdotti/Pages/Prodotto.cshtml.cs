using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace WebAppProdotti.Pages
{
    public class ProdottoModel : PageModel
    {
        public IEnumerable<Prodotto> Prodotti { get; set; }
        public int numeroPagine { get; set; }
        public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)
        {
            var json = System.IO.File.ReadAllText("./wwwroot/listajson.json");    //legge dal file json
            Prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);         //da json a oggetti Prodotto
            if (minPrezzo.HasValue) //Se sono forniti minPrezzo e/o maxPrezzo, la lista dei prodotti viene filtrata in modo che contenga solo i prodotti che rientrano nell'intervallo di prezzo specificato.
            {
                //p è il parametro, rappresenta un singolo prodotto nella sequenza
                Prodotti = Prodotti.Where(p => p.Prezzo >= minPrezzo); 
            }
            if (maxPrezzo.HasValue)
            {
                Prodotti = Prodotti.Where(p => p.Prezzo <= maxPrezzo);
            }
            //calcolo numero di pagine per avere 5 prodotti a pagina
            numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 5.0); 
            //null coalescing se pageindex è != da null viene usato il suo valore, altrimenti viene usato 1
            Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 5).Take(5); //skip salta 
        }
    }
}

//((pageIndex ?? 1) - 1) * 5: Questo calcola l'indice del primo elemento che deve essere incluso nella pagina
// corrente, moltiplicando l'indice della pagina per il numero di elementi desiderati per pagina (in questo caso 5).

//Prodotti.Skip(...) Questo metodo viene utilizzato per saltare un numero specificato di elementi nella sequenza 
//Prodotti. In questo caso, salta gli elementi che si trovano prima del primo elemento della pagina corrente.