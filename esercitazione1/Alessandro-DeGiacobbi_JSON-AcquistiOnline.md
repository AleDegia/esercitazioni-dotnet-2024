## APP ACQUISTI ONLINE

L'obiettivo del programma è quello di permttere a degli utenti di simulare l'acquisto di un prodotto tramite un sito web, previo login, e visualizzare il proprio bilancio ed il proprio storico degli acquisti.
Un primo json permetterà di storare i nomi degli utenti e le rispettive password per poi permettere l'accesso al sito tramite il login.
I successivi json verranno creati dinamicamente in base a quale utente è loggato, e serviranno a contenere i dati degli acquisti e del bilancio di quello specifico utente. Grazie a questi json qualsiasi utente già registrato potrà vedere i propri acquisti ed il proprio saldo.

## PUBBLICO TARGET
- L'applicazione è pensata per permettere a degli utenti di fare acquisti online e tracciare i propri ordini ed il proprio saldo.

### DEFINIZIONE REQUISITI E ANALISI
- [x] l'applicazione deve permettere ad un utente di registrarsi e fare il login     
- [x] l'applicazione deve chiedere all'utente se deve registrarsi o se deve fare il login    V
- [x] l'applicazione deve mettere in un file json il nome degli gli utenti registrati e le password prendendoli dalle rispettive liste   V
- [x] l'applicazione deve permettere il login verificando se nel json chiave e valore corrispondono V
- [x] l'applicazione deve permettere l'acquisto solo agli utenti loggati (e permettere il logout)
- [x] l'applicazione deve proporre una lista di acquisti possibili
- [x] l'applicazione deve far partire l'acquisto solo se il saldo è ok (e aggiornare il balance per ogni utente)
- [x] l'applicazione deve fare un json per ogni utente che colleghi un utente specifico ai suoi acquisti
- [x] l'applicazione deve ogni acquisto contiene: data, oggetto comprato, importo speso
- [x] l'applicazione deve far vedere tutti gli acquisti fatti da un determinato utente se l'utente è loggato

## SVILUPPO DEI COMPONENTI

- [x] Creare un progetto console per l'applicazione.

## Test e Debugging:

-  [ ] Esegui il debugging per individuare e risolvere i bug.
-  [ ] Controllare la leggebilità di prompt. 

## DOCUMENTAZIONE

- [x] Documentare il codice e l'architettura dell'applicazione.
- [ ] Documentare i test unitari.
- [ ] Documentare la fase di Beta Testing.
- [ ] Documentare la fase di post Beta Testing.


# BETA TESTING
> 1. Obiettivi
- Il programma deve fare quello per cui è programmato
- Non devono verificarsi eccezioni durante l'esecuzione del programma
- Gli output devono essere sensati in realzione con ciò che l'utente sta richiedendo/facendo
- L'inserimento di dati non corretti deve esser gestito in maniera sensata


## POST BETA TEST

<details>
<summary>Raccolta feedback</summary>
<details>

<summary> 

> BUG

- se chiedo di voler comprare il monitor giustamente mi dice che non ho pecunia ma dopo se non voglio più fare acquisti (premo tasto n) mi da l'errore System.IO.FileNotFoundException
- mi esce lo stesso errore anche quando mi chiede se voglio acquistare altro e schiaccio un qualsiasi tasto che non sia y o n 


> CONSIGLI

- potresti inserire Password errata o nome utente errato se sbaglio a inserire i miei dati (aggiungo io, potrei rimandare al login se uno sbaglia il login e non alla richiesta di iscrizione o login di nuovo)
   - ho aggiunto una stringa che stampi "nome utente o password errato" prima di far ripartire il ciclo 
- potresti inserire un listino prezzi prima di iniziare gli acquisti così so già quanto viene a costare ciò che voglio comprare per gestire al meglio le spese 
   - oltre a dire il nome dei vari prodotti mando a schermo il prezzo di quel prodotto con nomeDictionary[nomeProdotto]
- potresti inserire l'opzione dell'annullo acquisto 
- potresti inserire l'opzione elimina account
</summary>



## RISOLUZIONE

- veniva fato un readAll del json ma se un utente non acquista non viene generato il json contenete gli acquisti dell' utente, perciò provavo ad accedere al file anche se non esisteva. Ho aggiunto un controllo per verificare se il file esiste in modo da eseguire questa parte di codice solamente se il file effettivamente c'è.
- ho aggiunto una stringa che stampi "nome utente o password errato" prima di far ripartire il ciclo 
- oltre a dire il nome dei vari prodotti mando a schermo il prezzo di quel prodotto con nomeDictionary[nomeProdotto]
- mi sono accorto che anche io se invece che premere y/n premo un altra cosa mi esegue n, ho fatto percio dei cicli why fancendo un elseif non viene premuto ne y ne n manda a schermo il messaggio "input non valido" e riesegui il ciclo


> ECCEZIONI

- [x] stringhe
- [ ] numeri maggiori o minori

> BUG

- [ ] bug punteggio

Miglioramenti
- [x] esplicitare il range di numeri tra i quali indovinare
- [x] togliere True e False dai messaggi in console
</details>
</details>

</details>

## backtest per giada

- a "inserisci l'anno di uscita" assicurati che non si possano scrivere cose che non siano degli int, e anni che non siano superiori all'anno corrente o minori di un certo anno
(al momento se inserisco una lettera o 3000 ad es, lo prende e va avanti)

- se ad "assegna un voto" inserisco una lettera mi genera:
     Unhandled exception. System.FormatException: The input string 'g' was not in a correct format.
   at System.Number.ThrowFormatException[TChar](ReadOnlySpan`1 value)
   at System.Int32.Parse(String s)
   at Program.Main(String[] args) in C:\Users\DOTNET\Documents\Corso-Dotnet-2024\CORSO-DOTNET-2024\esercitazioni-dotnet-2024\esercitazione1\Program.cs:line 25

- ad "assegna un voto" sarebbe bene specificare all'utente se da 1 a 10 o cosa, altrimenti potrei anche mettere 90 come voto ad es..

- a "Vuoi inserire un altro videogioco?" se invece che s o n premo un altra lettera la prende come fosse una s e riparte a chiedermi le info per il nuovo videogioco da inserire

- Dopo aver inserito il primo videogioco se premo s mi chiede le info per il secondo videogioco ma poi non mi permette + di inserire una recensione
(questo però solo se metto info sbagliate, tipo mettendo 2 a ogni domanda. se le info sono giuste invece da nuovamente la possibilita di inserire una recensione) 
(a volte lo fa anche alla prima se ad esempio inserisco sempre 2 a tutto, si ferma dopo "assegna un voto")
(penso il problema sia che se esiste già un json con quel nome del videogioco si ferma dopo "assegna un voto")

- Se inserisco come titolo del videogioco un nome che è già presente come file json non viene aggiunta la mia recensione al json (ad es, se il json del gioco con titolo "2" è {"nome":"2","anno":"2","voto":"2"}, ora dando come titolo 2, anno 333 e voto 8, questo record non verrà aggiunto al file json, perciò attualmente se un gioco è gia stato recensito una volta poi le recensioni di altri utenti riguardanti quel gioco non vengono prese.)

- A "Vuoi darci più informazioni riguardo al videogioco" e a "Vuoi aggiungere una recensione personale?" se inserisco qualsiasi cosa che non sia o s o n lo prendo come n (ad es se inserisco un numero..)

- A "Vuoi darci più informazioni riguardo al videogioco" se premo s appaiono le varie opzioni da 1 a 5 e cosi via, ma se inserisco un opzione non valida, tipo 58, la prende comunque per buona e va avanti. Questo accade per tutte e 3 le domande a scelta multipla.


## suggerimenti per giada

sarebbe figo vedere anche una classifica dei giochi con le recensioni migliori o dei giochi con maggiori recensioni



## CODICE

```c#
using Newtonsoft.Json; // Libreria per la gestione dei dati JSON.

class Program
{
    static void Main()
    {
        // Inizializzazione delle variabili e liste.
        List<string> nomiUtenti = new List<string>();
        List<string> passwords = new List<string>();
        Boolean flag = false;
        string utenteRegistrato = null;
        string passwordUtenteRegistrato = null;

        // Percorso del file JSON contenente i nomi utenti e le password.
        string pathJsonUtentiEPassword = @"utentiEpassword.json";
        string json;
        string file2;
        dynamic obj = null;
        string nomeUtente = null;
        string password = null;
        string utenteLoggato = null;
        string passwordUtenteLoggato;

        if(File.Exists(pathJsonUtentiEPassword))
        {
        json = File.ReadAllText(pathJsonUtentiEPassword);
        file2 = pathJsonUtentiEPassword;
        obj = JsonConvert.DeserializeObject(json)!;
        }
        

        // Ciclo principale del programma.
        while (true)
        {
            // Richiesta all'utente di registrarsi o effettuare il login.
            System.Console.WriteLine("premi 1 per registrarti o premi 2 per fare il login");
            string scelta = Console.ReadLine();

            // Registrazione dell'utente.
            if (scelta == "1")
            {
                // Inserimento del nome utente e della password.
                System.Console.WriteLine("Inserisci il nome utente");
                nomeUtente = Console.ReadLine();
                nomiUtenti.Add(nomeUtente);
                System.Console.WriteLine("Inserisci una password");
                password = Console.ReadLine();
                passwords.Add(password);

                if(File.Exists(pathJsonUtentiEPassword)){
                // Controllo se l'utente esiste già.
                foreach (var jsonElement in obj)
                {
                    if (jsonElement.nomeutente == nomeUtente)
                    {
                        System.Console.WriteLine("Quest'utente esiste già");
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("registrazione avvenuta con successo!");
                        break;
                    }
                }
                }
                else
                {
                    System.Console.WriteLine("registrazione avvenuta con successo!");
                }

                // Salvo le informazioni dell'utente registrato.
                utenteRegistrato = nomeUtente;
                passwordUtenteRegistrato = password;

                // Salvataggio dei dati nel file JSON.
                if (!File.Exists(pathJsonUtentiEPassword))
                {
                    // Crea il file se non esiste.
                    File.Create(pathJsonUtentiEPassword).Close();
                    File.AppendAllText(pathJsonUtentiEPassword, "[\n");
                }
                else
                {
                    file2 = File.ReadAllText(pathJsonUtentiEPassword);
                    file2 = file2.Remove(file2.Length - 1, 1);
                    File.WriteAllText(pathJsonUtentiEPassword, file2);
                    File.AppendAllText(pathJsonUtentiEPassword, ",\n");
                }

                for (int i = 0; i < nomiUtenti.Count; i++)
                {
                    File.AppendAllText(pathJsonUtentiEPassword, JsonConvert.SerializeObject(new { nomeutente = nomiUtenti[i], passwordUtente = passwords[i] }));
                }

                File.AppendAllText(pathJsonUtentiEPassword, "]");
                obj = JsonConvert.DeserializeObject(File.ReadAllText(pathJsonUtentiEPassword))!;
            }

            // Login dell'utente.
            else if (scelta == "2")
            {
                System.Console.WriteLine("Inserisci il nome utente");
                nomeUtente = Console.ReadLine();
                System.Console.WriteLine("Inserisci la password");
                password = Console.ReadLine();

                // Controllo delle credenziali dell'utente.
                for (int i = 0; i < obj.Count; i++)
                {
                    if (obj[i].nomeutente == nomeUtente && obj[i].passwordUtente == password)
                    {
                        System.Console.WriteLine("Login avvenuto con successo " + utenteRegistrato + "\n");
                        System.Console.WriteLine("Ora hai accesso agli acquisti");
                        utenteLoggato = nomeUtente;
                        passwordUtenteLoggato = password;
                        flag = true;
                        break;
                    }
                }
                if (flag == true)
                {
                    break;
                }
            }
            else //se inserisco qualcosa di diverso da 1 o 2
            {
                System.Console.WriteLine("input non valido");
            }
            if (flag == true)
            {
                break;
            }
        }

        // Definizione dei prodotti acquistabili e dei relativi prezzi.
        List<string> prodottiAcquistabili = new List<string>();
        prodottiAcquistabili.Add("gaming mouse");
        prodottiAcquistabili.Add("monitor");
        prodottiAcquistabili.Add("joypad");

        Dictionary<string, decimal> prezziProdotti = new Dictionary<string, decimal>();
        prezziProdotti["gaming mouse"] = 50.99m;
        prezziProdotti["monitor"] = 199.99m;
        prezziProdotti["joypad"] = 29.99m;
        decimal balance = 100;
        decimal balancePrimaDelCalcolo = 0;

        string parteTestoFissa = "acquisti";
        string nomeFile = $"{parteTestoFissa}_{utenteLoggato}.json";
        string pathAcquistiUtenteLoggato = @$"{nomeFile}";

        // Gestione degli acquisti.
        if (File.Exists(pathAcquistiUtenteLoggato))
        {
            obj = JsonConvert.DeserializeObject(File.ReadAllText(pathAcquistiUtenteLoggato))!;
        }

    // Richiesta all'utente di scegliere un prodotto.
    Rifacciamo:
        System.Console.Write("Cosa vuoi acquistare tra: ");
        //itero i prodotti disponibili
        foreach (string prodotto in prodottiAcquistabili)
        {
            System.Console.Write(prodotto + ", ");
        }
        System.Console.Write("? (1, 2 o 3) ");
        
        //prende il balance dal json facendo un operazione di sottrazione
        if (File.Exists(pathAcquistiUtenteLoggato))
        {
            foreach (var jsonElement in obj)
            {
                if(balance>=0)
                {
                balancePrimaDelCalcolo = balance;
                balance = balance - Convert.ToDecimal(jsonElement.prezzoDiAcquisto);
                }
            }
            if(balance >= 0)
            {
            System.Console.WriteLine("il tuo balance è di " + balance + ")");
            }
            else
            {
                balance = balancePrimaDelCalcolo;
                System.Console.WriteLine("il tuo balance è di " + balance + ")");
            }
        }
        else 
        {
            System.Console.WriteLine("il tuo balance è di " + balance);
        }
        string prodottoScelto = Console.ReadLine();
        while (prodottoScelto != "1" && prodottoScelto != "2" && prodottoScelto != "3")
        {
            System.Console.WriteLine("scelta non valida");
            goto Rifacciamo;
        }

        // Acquisto del prodotto scelto.
        int contatore = 0;
        string nomeProdottoScelto = null;
        decimal prezzoDacquisto = 0;
        string file3 = null;


        // Ciclo su ogni coppia chiave-valore nel dizionario dei prezzi dei prodotti.
        foreach (KeyValuePair<string, decimal> entry in prezziProdotti)
        {
            contatore++;

            // Se il contatore è uguale al prodotto scelto e il prezzo è minore o uguale al balance.
            if (contatore == Int32.Parse(prodottoScelto) && entry.Value <= balance)
            {
                // Effettua l'acquisto.
                System.Console.WriteLine("acquisto avvenuto correttamente");
                balance = balance - entry.Value;

                // Salva il nome e il prezzo del prodotto acquistato.
                nomeProdottoScelto = entry.Key;
                prezzoDacquisto = entry.Value;

                // Definisce il nome del file e il percorso per il salvataggio degli acquisti.
                parteTestoFissa = "acquisti";
                nomeFile = $"{parteTestoFissa}_{utenteLoggato}.json";
                pathAcquistiUtenteLoggato = @$"{nomeFile}";
                file3 = pathAcquistiUtenteLoggato;

                // Se il file non esiste, lo crea e aggiunge il primo acquisto.
                if (!File.Exists(nomeFile))
                {
                    File.Create(nomeFile).Close();
                    File.AppendAllText(nomeFile, "[\n");
                    File.AppendAllText(pathAcquistiUtenteLoggato, JsonConvert.SerializeObject(new { nomeutente = $"{utenteLoggato}", oggettoAcquistato = nomeProdottoScelto, prezzoDiAcquisto = prezzoDacquisto, bilancio = balance }));
                    File.AppendAllText(nomeFile, "]\n");
                    System.Console.WriteLine("Il tuo bilancio attuale è di " + balance);
                    break;
                }
                // Se il file esiste, aggiunge l'acquisto al file esistente.
                else
                {
                    file3 = File.ReadAllText(file3);
                    file3 = file3.Remove(file3.Length - 2, 1);
                    File.WriteAllText(pathAcquistiUtenteLoggato, file3);
                    File.AppendAllText(pathAcquistiUtenteLoggato, ",\n");
                    File.AppendAllText(pathAcquistiUtenteLoggato, JsonConvert.SerializeObject(new { nomeutente = $"{utenteLoggato}", oggettoAcquistato = nomeProdottoScelto, prezzoDiAcquisto = prezzoDacquisto, bilancio = balance }));
                    File.AppendAllText(nomeFile, "]\n");
                    obj = JsonConvert.DeserializeObject(File.ReadAllText(pathAcquistiUtenteLoggato))!;
                    balance = obj[obj.Count - 1].bilancio;
                    System.Console.WriteLine("Il tuo bilancio attuale è di " + obj[obj.Count - 1].bilancio);
                }
            }
            // Se il prezzo è maggiore del balance.
            else if (contatore == Int32.Parse(prodottoScelto) && entry.Value > balance)
            {
                System.Console.WriteLine("non hai pecunia");
            }
        }


        System.Console.WriteLine("Vuoi acquistare altro? (y/n)");
        string input = Console.ReadLine();
        if (input == "y")
        {
            goto Rifacciamo;
        }

        
        obj = JsonConvert.DeserializeObject(File.ReadAllText(pathAcquistiUtenteLoggato))!;
        System.Console.WriteLine("Vuoi vedere i tuoi acquisti? (y/n)");
        input = Console.ReadLine();
        if (input == "y")
        {
            //itero nel json
            foreach (var jsonElement in obj)
            {
                System.Console.WriteLine("prodotto: " + jsonElement.oggettoAcquistato + " ,prezzo: " + jsonElement.prezzoDiAcquisto);
            }
        }
    }
}
```


