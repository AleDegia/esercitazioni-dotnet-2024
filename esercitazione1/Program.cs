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
        string pathJsonProdottiEPrezzi = @"prodottiEprezzi.json";
        string json = null;
        string file2;
        string file4;
        dynamic obj = null;
        dynamic obj2 = null;
        string nomeUtente = null;
        string password = null;
        string utenteLoggato = null;
        string passwordUtenteLoggato;
        bool utenteEsistente = false;

        if (File.Exists(pathJsonUtentiEPassword))
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

                if (File.Exists(pathJsonUtentiEPassword))
                {
                    // Controllo se l'utente esiste già.
                    string filex = File.ReadAllText(pathJsonUtentiEPassword);
                    obj = JsonConvert.DeserializeObject(filex)!;
                    int cont = 0;
                    foreach (var jsonElement in obj)
                    {
                        cont++;  //conto i cicli
                        if (jsonElement.nomeutente == nomeUtente)
                        {
                            System.Console.WriteLine("Quest'utente esiste già");
                            utenteEsistente = true;
                            AzzeraListe(nomiUtenti, passwords); // Chiamata alla funzione per azzerare le liste, al posto del codice qua sotto
                            // nomiUtenti=new List<string>();
                            // passwords=new List<string>();
                            break;
                        }
                        else
                        {

                            if (cont == obj.Count)  //se non è stato trovato un utente con quel nome, confermo la registrazione ed esco
                            {
                                System.Console.WriteLine("registrazione avvenuta con successo!");
                                break;
                            }
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
                    if (utenteEsistente == false)
                    {
                        file2 = File.ReadAllText(pathJsonUtentiEPassword);
                        file2 = file2.Remove(file2.Length - 2, 2);
                        File.WriteAllText(pathJsonUtentiEPassword, file2);
                        File.AppendAllText(pathJsonUtentiEPassword, ",\n");
                    }
                }

                if (utenteEsistente == false)
                {
                    for (int i = 0; i < nomiUtenti.Count; i++)
                    {
                        File.AppendAllText(pathJsonUtentiEPassword, JsonConvert.SerializeObject(new { nomeutente = nomiUtenti[i], passwordUtente = passwords[i] }));
                    }
                    File.AppendAllText(pathJsonUtentiEPassword, "]\n");
                    AzzeraListe(nomiUtenti, passwords); // Chiamata alla funzione per azzerare le liste, al posto del codice qua sotto
                }
                else { utenteEsistente = false; }
            }

            // Login dell'utente.
            else if (scelta == "2")
            {
                System.Console.WriteLine("Inserisci il nome utente");
                nomeUtente = Console.ReadLine().Trim();
                System.Console.WriteLine("Inserisci la password");
                password = Console.ReadLine().Trim();

                // Controllo delle credenziali dell'utente (se il file esiste)
                if (File.Exists(pathJsonUtentiEPassword))
                {
                    string filex = File.ReadAllText(pathJsonUtentiEPassword);
                    obj = JsonConvert.DeserializeObject(filex)!;
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
                    System.Console.WriteLine("\n!!Passord o nome utente errato\n");
                }
                else
                {
                    System.Console.WriteLine("non sei ancora iscritto, iscriviti!");
                    continue;
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


        //aggiungo nel json i prodotti e prezzi del dictionary
        if (!File.Exists(pathJsonProdottiEPrezzi))
        {
            // Crea il file se non esiste.
            File.Create(pathJsonProdottiEPrezzi).Close();
            File.AppendAllText(pathJsonProdottiEPrezzi, "[\n");

            file4 = File.ReadAllText(pathJsonProdottiEPrezzi);
            file4 = file4.Remove(file4.Length - 1, 1);
            File.WriteAllText(pathJsonProdottiEPrezzi, file4);
            //ciclo nel dictionary
            for (int i = 0; i < prodottiAcquistabili.Count; i++)
            {
                File.AppendAllText(pathJsonProdottiEPrezzi, JsonConvert.SerializeObject(new { nomeProdotto = prezziProdotti.Keys.ElementAt(i), prezzoProdotto = prezziProdotti.Values.ElementAt(i) }));
                if (i + 1 != prodottiAcquistabili.Count)
                {
                    File.AppendAllText(pathJsonProdottiEPrezzi, ",\n");
                }
            }
            File.AppendAllText(pathJsonProdottiEPrezzi, "]");
        }


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
        int contator = 1;
        obj2 = JsonConvert.DeserializeObject(File.ReadAllText(pathJsonProdottiEPrezzi))!;
        //itero i prodotti disponibili tramite il json
        foreach (dynamic jsonElement in obj2)
        {
            System.Console.Write(contator + ") " + jsonElement.nomeProdotto + ": " + jsonElement.prezzoProdotto + "$, ");
            contator++;
        }
        System.Console.WriteLine("? ");


        //prende il balance dal json facendo un operazione di sottrazione
        if (File.Exists(pathAcquistiUtenteLoggato))
        {
            obj = JsonConvert.DeserializeObject(File.ReadAllText(pathAcquistiUtenteLoggato))!;
            foreach (var jsonElement in obj)
            {
                if (balance >= 0 && jsonElement == obj[obj.Count - 1])
                {
                    balancePrimaDelCalcolo = balance;
                    //balance = balance - Convert.ToDecimal(jsonElement.prezzoDiAcquisto);
                    balance = Convert.ToDecimal(jsonElement.bilancio);
                }
            }

            if (balance >= 0)
            {
                System.Console.WriteLine("Il tuo balance è di " + balance);
            }
            else
            {
                balance = balancePrimaDelCalcolo;     //per non farlo andare sotto 0
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
                    File.AppendAllText(nomeFile, "\n]\n");
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

        string input = null;
        while (true)
        {
            System.Console.WriteLine("Vuoi acquistare altro? (y/n)");
            input = Console.ReadLine().ToLower().Trim();
            if (input == "y")
            {
                goto Rifacciamo;
            }
            else if (input != "y" && input != "n")
            {
                System.Console.WriteLine("input non valido");
                continue;
            }
            break;
        }

        if (File.Exists(pathAcquistiUtenteLoggato))
        {
            obj = JsonConvert.DeserializeObject(File.ReadAllText(pathAcquistiUtenteLoggato))!;
            while (true)
            {
                System.Console.WriteLine("Vuoi vedere i tuoi acquisti? (y/n)");
                input = Console.ReadLine().ToLower().Trim();
                if (input == "y")
                {
                    //itero nel json
                    foreach (var jsonElement in obj)
                    {
                        System.Console.WriteLine("prodotto: " + jsonElement.oggettoAcquistato + " ,prezzo: " + jsonElement.prezzoDiAcquisto);
                    }
                }
                else if (input != "y" && input != "n")
                {
                    System.Console.WriteLine("input non valido");
                    continue;
                }
                break;
            }
        }
    }


    // Funzione per azzerare le liste nomiUtenti e passwords
    static void AzzeraListe(List<string> lista1, List<string> lista2)
    {
        lista1.Clear();
        lista2.Clear();
    }
}