using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QuizIdentity2.Pages;

public class ValidazioneModel : PageModel
{
  public Utente Utente { get; set; }
  public IEnumerable<Verifica> Verifiche { get; set; }

  public void OnGet(string nome, string[] ru, int numOpz)
  {
    var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
    var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
    Utente = utenti.FirstOrDefault(u => u.Nome == nome);
    var domandejson = System.IO.File.ReadAllText("wwwroot/json/domande.json");
    var Domande = JsonConvert.DeserializeObject<List<Domanda>>(domandejson);
    var verificas = new List<Verifica>();
    int punteggio = 0;

    int lunghezza = ru.Length;
    int counter = 0;
    int numeroRisposte = 1;



    for (int n = 0; n < lunghezza; n++)
    {
        var domanda = Domande.FirstOrDefault(d => d.Opzioni.Contains(ru[n]));
        if (domanda.Risposte.Contains(ru[n]))
        {
          verificas.Add(new Verifica { Id = n + 1, RispostaUtente = ru[n], RispostaGiusta = ru[n], Uguali = true });
          punteggio++;
        }
        else
        {
          verificas.Add(new Verifica { Id = n + 1, RispostaUtente = ru[n], RispostaGiusta = domanda.Risposte[0], Uguali = false });
        }
    }

    int record = Utente.Punteggi.Max();

    if (punteggio > record)
    {
      record = punteggio;
    }

    int vecchiPunteggi = Utente.Punteggi.Length;
    int[] scores = new int[vecchiPunteggi + 1];

    for (int s = 0; s < vecchiPunteggi; s++)
    {
      scores[s] = Utente.Punteggi[s];
    }

    scores[vecchiPunteggi] = punteggio;
    Utente.Punteggi = scores;
    Utente.Record = record;

    System.IO.File.WriteAllText("wwwroot/json/utenti.json", JsonConvert.SerializeObject(utenti, Formatting.Indented));

    Verifiche = verificas;
  }

}


