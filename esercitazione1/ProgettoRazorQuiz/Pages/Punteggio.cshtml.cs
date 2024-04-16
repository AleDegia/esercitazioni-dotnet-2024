using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgettoRazorQuiz;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using ProgettoRazorQuiz.Models;

namespace ProgettoRazorQuiz.Pages;
public class PunteggioModel : PageModel
{
    public Risposta risposta { get; set; }
    public string Username { get; set; }
    public List<string> Risposte { get; set; }
    public string Mod { get; set; }
    public int Score { get; set; } = 0;
    public List<string> rispCorretteList { get; set; }
    public List<Punteggio> punteggiUsers { get; set; }

    public Punteggio punteggio { get; set; }
    public int HighScore { get; set; }

    public List<int> ultimi5ScoreUtente { get; set; }


    public void OnGet(List<string> risposte, string username, string modalita)
    {
        punteggio = new Punteggio(); // Initialize punteggio
        risposta = new Risposta();
        Username = username;
        // Mod = mod;
        if (risposte != null)
        {
            Risposte = risposte;
        }
        System.Console.WriteLine("modalita:" + modalita);
        Mod = modalita;

        if (Mod == "difficile")
        {

            // Legge il contenuto del file JSON delle risposte aperte (deve farlo solo se si stanno giocando domande aperte..)
            var rispCorrettejson = System.IO.File.ReadAllText("wwwroot/risposteAperte.json");

            // Deserializza il JSON in una lista di Risposte (non posso mettere stringhe perchè il json ha id in numero e poi la stringa, percio servono degli oggetti Risposta con id e contenuto)
            var rispCorrette = JsonConvert.DeserializeObject<List<Risposta>>(rispCorrettejson);
            //recupero le stringhe nella lista di oggetti Risposta rispCorrette
            rispCorretteList = new List<string>();
            for (int i = 0; i < Risposte.Count; i++)
            {
                rispCorretteList.Add(rispCorrette[i].risposta);
            }


            //Leggo contenuto del file json punteggio
            var punteggioUsersjson = System.IO.File.ReadAllText("wwwroot/punteggiUsers.json");

            punteggiUsers = JsonConvert.DeserializeObject<List<Punteggio>>(punteggioUsersjson);


            //recupero dal json il punteggio precedente per quello user, verifico se il punteggio precedente è < di questo e se si aggiorno il dato col nuovo highscore
            //se fa highscore mostrare mess di highscore
            //mostro la posizione in classifica dell'utente?

            for (int i = 0; i < Risposte.Count; i++)
            {
                if (Risposte[i] == rispCorretteList[i])
                {
                    Score = Score + 1;
                }

            }


            //per ogni oggetto Punteggio con nomeUtente e punteggio relativo,
            foreach (var punteggioUserLoggato in punteggiUsers)
            {
                // se il nome in punteggio è quello dell'utente loggato
                if (punteggioUserLoggato.nome == Username)
                {
                    // Controlla se lo Score attuale di quell oggetto Punteggio è maggiore del punteggio salvato per quell'utente
                    if (Score > punteggioUserLoggato.punteggio)
                    {
                        punteggioUserLoggato.punteggio = Score;
                        // Serializza la lista con gli score in formato JSON avendo in caso aggiornato quello dell'utente
                        var jsonAggiornato = JsonConvert.SerializeObject(punteggiUsers, Formatting.Indented);
                        System.IO.File.WriteAllText("wwwroot/punteggiUsers.json", jsonAggiornato);
                    }
                }
            }


            //creo i json dinamici per avere i singoli punteggi dell'utente per ogni giocata
            var jsonObject = new Punteggio
            {
                nome = Username,
                punteggio = Score
            };

            // var userInPunteggio = new Punteggio
            //     {
            //         nome = username,
            //         punteggio = 0
            //     };

            // Converto l'oggetto JSON in una stringa json
            string json = JsonConvert.SerializeObject(jsonObject);

            string directoryPath = "wwwroot/punteggiSingoliUtenti";
            string nomeFile = $"{Username}_punteggiSingoli.json";
            string filePath = Path.Combine(directoryPath, nomeFile);

            if (!System.IO.File.Exists(filePath))
            {
                // Crea il file
                try
                {
                    // Puoi inizializzare il file con dei dati predefiniti, ad esempio un oggetto JSON vuoto
                    string defaultJsonData = "[]";

                    // Crea il file con i dati predefiniti
                    System.IO.File.WriteAllText(filePath, defaultJsonData);

                    Console.WriteLine("File creato con successo.");
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("errore file");
                }
            }

            //leggo il file
            var punteggiSingoloUtenteJson = System.IO.File.ReadAllText($"wwwroot/punteggiSingoliutenti/{Username}_punteggiSingoli.json");

            // Scrivo la stringa json su un file
            var punteggiUserSingolo = JsonConvert.DeserializeObject<List<Punteggio>>(punteggiSingoloUtenteJson);
            punteggiUserSingolo.Add(jsonObject); //aggiungo il punteggio appena fatto



            // Serializza la lista aggiornata in formato JSON
            string updatedJsonData = JsonConvert.SerializeObject(punteggiUserSingolo);

            // Scrivi i dati serializzati nel file
            System.IO.File.WriteAllText(filePath, updatedJsonData);

            ultimi5ScoreUtente = new List<int>();

            if (punteggiUserSingolo != null)
            {
                //per ogni punteggio dell'utente prendo gli ultimi 5 per mostrarli nella view
                for (int i = 0; i < punteggiUserSingolo.Count; i++)
                {
                    if (i >= (punteggiUserSingolo.Count - 5))
                    {
                        ultimi5ScoreUtente.Add(punteggiUserSingolo[i].punteggio);
                    }
                }
            }



            // - assegno il punteggio massimo di quell utente alla var highscore leggendolo dal json PunteggiUsers (cosi lo uso nella view)
            var highScoreJson = System.IO.File.ReadAllText($"wwwroot/punteggiUsers.json");
            var listaOggetti = JsonConvert.DeserializeObject<List<Punteggio>>(highScoreJson);
            foreach (var ogg in listaOggetti)
            {
                HighScore = ogg.punteggio;
            }
        }//chiusura dell if modalità
        else if (Mod == "facile")
        {
            var domandeFacilijson = System.IO.File.ReadAllText("wwwroot/domandeFacili.json");
            List<Domanda> domande = JsonConvert.DeserializeObject<List<Domanda>>(domandeFacilijson);
            rispCorretteList = new List<string>();

            foreach (var domanda in domande)
            {
                rispCorretteList.Add(domanda.Risposta);     //metto qui le risposte corrette
                System.Console.WriteLine(domanda.Risposta);
            }

            // prendo le risposte dell'utente
            for(int i=0; i<domande.Count; i++)
            {
                if(rispCorretteList[i]==Risposte[i])
                {
                     Score = Score + 1;
                }
            }

            //Leggo contenuto del file json punteggio
            var punteggioUsersjson = System.IO.File.ReadAllText("wwwroot/punteggiUsers.json");

            punteggiUsers = JsonConvert.DeserializeObject<List<Punteggio>>(punteggioUsersjson);

            //per ogni oggetto Punteggio con nomeUtente e punteggio relativo,
            foreach (var punteggioUserLoggato in punteggiUsers)
            {
                // se il nome in punteggio è quello dell'utente loggato
                if (punteggioUserLoggato.nome == Username)
                {
                    // Controlla se lo Score attuale di quell oggetto Punteggio è maggiore del punteggio salvato per quell'utente
                    if (Score > punteggioUserLoggato.punteggio)
                    {
                        punteggioUserLoggato.punteggio = Score;
                        // Serializza la lista con gli score in formato JSON avendo in caso aggiornato quello dell'utente
                        var jsonAggiornato = JsonConvert.SerializeObject(punteggiUsers, Formatting.Indented);
                        System.IO.File.WriteAllText("wwwroot/punteggiUsers.json", jsonAggiornato);
                    }
                }
            }

            //creo i json dinamici per avere i singoli punteggi dell'utente per ogni giocata
            var jsonObject = new Punteggio
            {
                nome = Username,
                punteggio = Score
            };


            // Converto l'oggetto JSON in una stringa json
            string json = JsonConvert.SerializeObject(jsonObject);

            string directoryPath = "wwwroot/punteggiSingoliUtenti";
            string nomeFile = $"{Username}_punteggiSingoli.json";
            string filePath = Path.Combine(directoryPath, nomeFile);

            if (!System.IO.File.Exists(filePath))
            {
                // Crea il file
                try
                {
                    // Puoi inizializzare il file con dei dati predefiniti, ad esempio un oggetto JSON vuoto
                    string defaultJsonData = "[]";

                    // Crea il file con i dati predefiniti
                    System.IO.File.WriteAllText(filePath, defaultJsonData);

                    Console.WriteLine("File creato con successo.");
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("errore file");
                }
            }

            //leggo il file
            var punteggiSingoloUtenteJson = System.IO.File.ReadAllText($"wwwroot/punteggiSingoliutenti/{Username}_punteggiSingoli.json");

            // Scrivo la stringa json su un file
            var punteggiUserSingolo = JsonConvert.DeserializeObject<List<Punteggio>>(punteggiSingoloUtenteJson);
            punteggiUserSingolo.Add(jsonObject); //aggiungo il punteggio appena fatto



            // Serializza la lista aggiornata in formato JSON
            string updatedJsonData = JsonConvert.SerializeObject(punteggiUserSingolo);

            // Scrivi i dati serializzati nel file
            System.IO.File.WriteAllText(filePath, updatedJsonData);

            ultimi5ScoreUtente = new List<int>();

            if (punteggiUserSingolo != null)
            {
                //per ogni punteggio dell'utente prendo gli ultimi 5 per mostrarli nella view
                for (int i = 0; i < punteggiUserSingolo.Count; i++)
                {
                    if (i >= (punteggiUserSingolo.Count - 5))
                    {
                        ultimi5ScoreUtente.Add(punteggiUserSingolo[i].punteggio);
                    }
                }
            }
        }
    }
}


