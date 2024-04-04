using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QuizIdentity2.Pages;

public class ValidazioneDoppiaModel : PageModel
{
  public Utente Utente { get; set; }
  public IEnumerable<VerificaDoppia> Giuste { get; set; }

  public int Punteggio;

  public void OnGet(string nome, List<string> ru)
  {
    var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
    var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
    Utente = utenti.FirstOrDefault(u => u.Nome == nome);

    var domandejson = System.IO.File.ReadAllText("wwwroot/json/domandedoppie.json");
    var Domande = JsonConvert.DeserializeObject<List<Domanda>>(domandejson);


    List<string> risposteGiuste = new List<string>();
    List<string> rg1 = new List<string>();
    List<string> rg2 = new List<string>();
    foreach (var domanda in Domande)
    {
      // string id = "domanda" + domanda.Id;
      // risposteGiuste.Add(id);
      int p = 0;
      foreach (string rispostaG in domanda.Risposte)
      {
        risposteGiuste.Add(rispostaG);
        p++;
        bool pari = p%2 == 0;
        if (pari)
        {
          rg2.Add(rispostaG);
        }
        else
        {
          rg1.Add(rispostaG);
        }
      }
    }



    int salto = 0;
    string runo;
    string rdue;
    string risposta;


    int numeroDomande = 3;
    string risp = "opzione";
    string[] opzioni = ["A", "B", "C"];
    int numeroOpzioni = opzioni.Length;
    int boxes = numeroDomande * numeroOpzioni; // 9
    
    int punteggio = 0;
    int posizione = 0;
    string[] rispUtente = new string[boxes]; 



    foreach (string r in ru) // per 9 volte prendo una r
    {
      int counter = 0;

      for (int o = 1; o <= numeroDomande; o++) // per 3 volte prendo un numero
      {
        for (int vocale = 0; vocale < numeroOpzioni; vocale++)
        {
          risp = o + "opzione" + opzioni[vocale];
          if (r == risp)
          {
            var Domanda = Domande.FirstOrDefault(dmd => dmd.Id == o);
            rispUtente[counter] = Domanda.Opzioni[vocale];
            posizione = counter + 1;
          }
            counter++;
        }
      }

        if (posizione < 9) // se quelli dopo non sono stati selezionati diventano valore nada
        {
          for (int v = posizione; v < 9; v++) // anche se compili il form al contrario non sovrascrivi i valori
          {
            rispUtente[v] = "Nada"; // perchè diventa Nada solo quando fai submit, e li prende in ordine
          }
        }

    }

      var verificas = new List<VerificaDoppia>();

      for (int i = 0; i < numeroDomande; i++)
      {
        runo = rg1[i];
        rdue = rg2[i];
        {
          for (int e = salto; e < salto + numeroOpzioni; e++)
          {
            risposta = rispUtente[e];

            if (risposta != null && risposta != "Nada")
            {
              if (risposta == runo || risposta == rdue)
              {
                var giusta = new VerificaDoppia { Id = e + 1, RisposteGiuste = [runo, rdue], RispostaUtente = risposta, Uguali = true };
                verificas.Add(giusta);
                punteggio++;
              }
              else
              {
                var giusta = new VerificaDoppia { Id = e + 1, RisposteGiuste = [runo, rdue], RispostaUtente = risposta, Uguali = false };
                verificas.Add(giusta);
                punteggio--;
              }
            }
          }
          salto = salto + numeroOpzioni;
        }
      }

      /* 
          salto = 0
          0,1,2 
          e < 3 
          salto = 3
          3,4,5 
          e < 6
          salto = 6
          6,7,8
          e < 9
       */

      Giuste = verificas;
      int record = Utente.Record;
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

      Punteggio = punteggio;

      scores[vecchiPunteggi] = punteggio;
      Utente.Punteggi = scores;
      Utente.Record = record;
      System.IO.File.WriteAllText("wwwroot/json/utenti.json", JsonConvert.SerializeObject(utenti, Formatting.Indented));
    }

  }




