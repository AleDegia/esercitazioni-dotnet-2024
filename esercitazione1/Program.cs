﻿using Newtonsoft.Json; // libreria .NET per la serializzazione e la deserializzazione di dati JSON.

class Program
{
    static void Main()
    {
        //le liste sono fuori dal while perchè sennò ad ogni ciclo vengono ricreate perdendo i dati
        List<string> nomiUtenti = new List<string>();
        List<string> passwords = new List<string>();
        Boolean flag = false;
        string utenteRegistrato = null;
        string passwordUtenteRegistrato = null;
        // dynamic obj = JsonConvert.DeserializeObject(file2)!;
        string pathJsonUtentiEPassword = @"utentiEpassword.json"; //il file deve essere nella stessa cartella del programma
        string json = File.ReadAllText(pathJsonUtentiEPassword); //legge il file
        string file2 = pathJsonUtentiEPassword;
        dynamic obj = JsonConvert.DeserializeObject(json)!;
        string utenteLoggato;
        string passwordUtenteLoggato;

        while (true)
        {

            System.Console.WriteLine("premi 1 per registrarti o premi 2 per fare il login");
            string scelta = Console.ReadLine();
            if (scelta == "1")
            {

                System.Console.WriteLine("Inserisci il nome utente");
                string nomeUtente = Console.ReadLine();
                nomiUtenti.Add(nomeUtente);
                System.Console.WriteLine("Inserisci una password");
                string password = Console.ReadLine();
                passwords.Add(password);
                System.Console.WriteLine("registrazione avvenuta con successo!");
                utenteRegistrato = nomeUtente;
                passwordUtenteRegistrato = password;

                //metto in un file json gli utenti registrati e le password

                if (!File.Exists(pathJsonUtentiEPassword))
                {
                    File.Create(pathJsonUtentiEPassword).Close(); //crea il file
                    File.AppendAllText(pathJsonUtentiEPassword, "[\n"); //scrive la riga nel file
                }
                else
                {
                    file2 = File.ReadAllText(pathJsonUtentiEPassword);
                    file2 = file2.Remove(file2.Length - 1, 1); //vai indietro di 1 posizioni e cancella un carettere
                    File.WriteAllText(pathJsonUtentiEPassword, file2);
                    File.AppendAllText(pathJsonUtentiEPassword, ",\n"); //scrive la riga nel file
                }
                for (int i = 0; i < nomiUtenti.Count; i++)
                {
                    File.AppendAllText(pathJsonUtentiEPassword, JsonConvert.SerializeObject(new { nomeutente = nomiUtenti[i], passwordUtente = passwords[i] })); //scrive la riga nel file
                }

                File.AppendAllText(pathJsonUtentiEPassword, "]"); //scrive la riga nel file

            }
            else if (scelta == "2")
            {
                System.Console.WriteLine("Inserisci il nome utente");
                string nomeUtente = Console.ReadLine();

                //utenteLoggato=nomeUtente;
                System.Console.WriteLine("Inserisci la password");
                string password = Console.ReadLine();


                //controllo se nella lista di nomi c'è il nome utente inserito, e controllo se è allo stesso indice 
                //della password in lista password per capire se sono abbinati. 
                //(in scelta uno faccio inserire nome utente e password insieme perciò dovranno essere allo stesso indice nelle rispettive liste)
                
                for (int i = 0; i < obj.Count; i++)
                {

                    if (obj[i].nomeutente == nomeUtente && obj[i].passwordUtente == password)
                    {
                        System.Console.WriteLine("Login avvenuto con successo " + utenteRegistrato + "\n");
                        System.Console.WriteLine("Ora hai accesso agli acquisti");
                        utenteLoggato=nomeUtente;
                        passwordUtenteLoggato=password;
                        flag = true;
                        break;
                    }
                }
                if (flag == true)
                {
                    break;
                }
            }
            if (flag == true)
            {
                break;
            }
        }
       

        List<string> prodottiAcquistabili = new List<string>();
        prodottiAcquistabili.Add("gaming mouse");
        prodottiAcquistabili.Add("monitor");
        prodottiAcquistabili.Add("joypad");

        // Mappa dei prezzi associati agli oggetti
        Dictionary<string, decimal> prezziProdotti = new Dictionary<string, decimal>();

        prezziProdotti["gaming mouse"] = 50.99m; 
        prezziProdotti["monitor"] = 199.99m;    
        prezziProdotti["joypad"] = 29.99m;     
        decimal balance = 30;

            Rifacciamo:
            System.Console.Write("Cosa vuoi acquistare tra: ");
            foreach(string prodotto in prodottiAcquistabili)
            {
                System.Console.Write(prodotto + ", ");
            }
            System.Console.WriteLine("? (1, 2 o 3) (il tuo balance di default è 30)");
            string prodottoScelto = Console.ReadLine();
            while(prodottoScelto!= "1" && prodottoScelto!="2" && prodottoScelto!="3")
            {
                System.Console.WriteLine("scelta non valida");
                goto Rifacciamo;
            }
            
            // if(prezziProdotti.Keys==prodottiAcquistabili[Int32.Parse(prodottoScelto -1)])
            // {
            //     System.Console.WriteLine("acquisto avvenuto correttamente");

            // }
            // else
            // {
            //     System.Console.WriteLine("non hai pecunia");
            // }

    }
}

