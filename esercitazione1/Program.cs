class Program
{

    static void Main()
    {
        
        

        int numeroGiocatori = 0;
        int[] posizioneGiocatori = new int[6];
        //chiedo in quanti si è a giocare
        while (true)
        {
            try
            {
                System.Console.WriteLine("In quanti siete a giocare? Si gioca al massimo in 6");
                numeroGiocatori = Int32.Parse(Console.ReadLine());
                //se ci sono + di 6 giocatori non si può iniziare a giocare e ritorna all'inizio del while
                if (numeroGiocatori > 6)
                {
                    System.Console.WriteLine("Si gioca al massimo in 6.");
                    continue;
                }
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse {numeroGiocatori}");
            }
        }

        Dado d1 = new Dado();
        Dado d2 = new Dado();
        int risultatoLancio1 = d1.Lancia();
        int risultatoLancio2 = d2.Lancia();

        string[] nomiGiocatori = new string[6];
        int[] abilita = new int[2];
        Dictionary<string, int> abilitaGiocatori = new Dictionary<string, int>();
        // Dictionary<int, string> associazioneTurniNomi = new Dictionary<int, string>();
        int[] caselle = new int[56];
        int contatore = 1;


        //assegno i nomi dei giocatori alla rispettive variabili nell'array uno ad uno grazie al ciclo
        for (int i = 0; i < numeroGiocatori; i++)
        {
            System.Console.WriteLine($"Inserisci il nome del giocatore {contatore}");
            string nomeGiocatoreInput = Console.ReadLine();
            nomiGiocatori[i] = nomeGiocatoreInput;
            System.Console.WriteLine($"Scegli l'abilità che vuoi usare");
            System.Console.WriteLine("digita 1 per Controllo, 2 per ...");
            int abilitaScelta = Int32.Parse(Console.ReadLine());
            // associazioneTurniNomi.Add(i+1,nomiGiocatori[i]);
            contatore++;

            switch (abilitaScelta)
            {
                case 1:
                    System.Console.WriteLine($"{nomiGiocatori[i]} ha scelto 'Controllo' ");
                    abilitaGiocatori.Add(nomiGiocatori[i], 1);
                    continue;
                case 2:
                    System.Console.WriteLine($"{nomiGiocatori[i]} ha scelto 'Abilita2' ");
                    abilitaGiocatori.Add(nomiGiocatori[i], 2);
                    continue;
            }
        }
        

        int[] turnoGiocatore = { 1, 2, 3, 4, 5, 6 };
        int turno = 1;
        // int dado1;
        // int dado2;

        Random random = new Random();


        System.Console.WriteLine("\n INIZIAMO! \n");

        while (true)
        {

            for (int i = 0; i < numeroGiocatori; i++)  //ciclo per eseguire le istruzioni in base al turno del giocatore
            {

                //se il nome giocatore che usa l'abilità è il nome giocatore in pos i di nomiGiocatori vuol dire che è il suo turno
                if (abilitaGiocatori.ContainsValue(1) && abilitaGiocatori.ContainsKey(nomiGiocatori[i]) && turnoGiocatore[i] == turno)
                {
                //--------------------------------------------------------------
                // METODO LOGICA CONTROLLO

                // doppioNumero:
                    // dado1 = random.Next(1, 7);//escono numeri da 1 a 6
                    // dado2 = random.Next(1, 7);//escono numeri da 1 a 6

                    // //. . . 
                    // System.Console.Write(". ");
                    // Thread.Sleep(500);
                    // System.Console.Write(". ");
                    // Thread.Sleep(500);
                    // System.Console.Write(". \n \n");
                    // Thread.Sleep(500);

                    // posizioneGiocatori[i] = posizioneGiocatori[i] + dado1 + dado2; //aggiorno la posizione del giocatore che gioca

                    // System.Console.WriteLine($"{nomiGiocatori[i]} ha fatto {dado1} e {dado2}");
                    // System.Console.WriteLine("posizione aggiornata: casella numero " + posizioneGiocatori[i]);
                    // Thread.Sleep(1000);

                    // if (dado1 == dado2)
                    // {
                    //     System.Console.WriteLine("doppio numero! tiri di nuvo :)");
                    //     goto doppioNumero;
                    // }

                    logicaControllo(posizioneGiocatori,posizioneGiocatori[i], i, nomiGiocatori, risultatoLancio1, risultatoLancio2);

                    //comportamento controllo
                    System.Console.WriteLine("vuoi atterrare di 1 avanti o no? y/n");
                    string input = Console.ReadLine();
                    if (input == "y")
                    {
                        posizioneGiocatori[i] += 1;
                        System.Console.WriteLine("ora sei nella casella " + posizioneGiocatori[i]);
                    }

                    //mega switch
                    int maxNumber = 0;
                    switch (posizioneGiocatori[i])
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            
                            break;
                        case 4:  //muoviti una posizione davanti al primo in classifica
                            maxNumber = 0;
                            foreach(var posGiocatore in posizioneGiocatori)
                            {
                                if(posGiocatore>maxNumber)
                                {
                                    maxNumber=posGiocatore;
                                }
                            }
                            posizioneGiocatori[i] = maxNumber + 1;
                            System.Console.WriteLine("\nEFFETTO CASELLA:\n");
                            System.Console.WriteLine("\n Voli davanti al primo!!! \n");
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8: //teletrasporto: ti sposti alla casella 14
                            posizioneGiocatori[i] = 14;
                            System.Console.WriteLine("\nEFFETTO CASELLA:\n");
                            System.Console.WriteLine("\n Vai avanti fino alla casella 14 \n");
                            break;
                        case 9:
                            break;
                        case 10: //randomic: ti sposti su un mupltiplo di 2 a caso inferiore o = a 30
                            while(true)
                            {
                                int randomicnumber =random.Next(4,31);
                                posizioneGiocatori[i]=randomicnumber;
                                if(randomicnumber%2==0)
                                {
                                    break;
                                }
                            }
                            System.Console.WriteLine("\nEFFETTO CASELLA:\n");
                            System.Console.Write("\n Estrazione di un mupltiplo di 2 a caso inferiore o = a 30");
                            Thread.Sleep(500);
                            System.Console.Write(".");
                            Thread.Sleep(500);
                            System.Console.Write(".");
                            Thread.Sleep(500);
                            System.Console.WriteLine(".");
                            Thread.Sleep(500);
                            System.Console.WriteLine("è uscito il " + posizioneGiocatori[i] + "!!!");
                            break;
                        case 11:
                            break;
                        case 12:
                            break;
                        case 13:
                            break;
                        case 14:
                            break;
                        case 15:
                            break;
                        case 16:
                            break;
                        case 17:
                            break;
                        case 18:
                            break;
                        case 19:
                            break;
                        case 20:
                            break;
                        case 21:
                            break;
                    }

                    //implemento la visualizzazione grafica del gioco nel txt
                    string filePath = "C:/Users/DOTNET/Documents/Corso-Dotnet-2024/CORSO-DOTNET-2024/esercitazioni-dotnet-2024/esercitazione1/fileDadi.csv";

                    //legge tutte le righe del file e salva ogni riga come stringa in 1 cella
                    string[] lines = File.ReadAllLines(filePath);

                    int contatorePerFile = 0;

                    foreach (string line in lines)
                    {
                        contatorePerFile++;

                        //se la riga contiene il numero relativo alla posizione del giocatore, aggiungo il nome del giocatore alla riga
                        if (line.Contains(posizioneGiocatori[i].ToString()))
                        {
                            // Rimuovo il nome del giocatore dalla posizione precedente se è presente
                            for (int j = 0; j < lines.Length; j++)
                            {
                                //la funzione replace cerca il nome del giocatore (nomiGiocatori[i] e lo sostituisce con una linea vuota)
                                lines[j] = lines[j].Replace(nomiGiocatori[i], string.Empty);
                            }

                            //aggiungo il nome del giocatore nella posizione aggiornata
                            lines[contatorePerFile - 1] += nomiGiocatori[i];
                            break;
                        }
                    }
                    File.WriteAllLines(filePath, lines);
                    contatorePerFile = 0;

                    if (i + 1 == numeroGiocatori) //se i giocatori hanno giocato tutti, rinizio il ciclo di giocate dal primo
                    {
                        System.Console.WriteLine($"quando sei pronto per tirare {nomiGiocatori[0]} premi un tasto");
                        Console.ReadKey(true);
                        System.Console.WriteLine();
                        continue;
                    }
                    System.Console.WriteLine($"quando sei pronto per tirare {nomiGiocatori[i + 1]} premi un tasto");
                    Console.ReadKey(true);
                    System.Console.WriteLine();
                }
                else
                {

                // doppioNumero:
                //     dado1 = random.Next(1, 7);//escono numeri da 1 a 6
                //     dado2 = random.Next(1, 7);//escono numeri da 1 a 6

                //     //. . . 
                //     System.Console.Write(". ");
                //     Thread.Sleep(500);
                //     System.Console.Write(". ");
                //     Thread.Sleep(500);
                //     System.Console.Write(". \n \n");
                //     Thread.Sleep(500);

                //     posizioneGiocatori[i] = posizioneGiocatori[i] + dado1 + dado2; //aggiorno la posizione del giocatore che gioca

                //     System.Console.WriteLine($"{nomiGiocatori[i]} ha fatto {dado1} e {dado2}");
                //     System.Console.WriteLine("posizione aggiornata: casella numero " + posizioneGiocatori[i]);
                //     //posizioneGiocatore1 = posizioneGiocatore1+dado1+dado2;
                //     //System.Console.WriteLine($"{nomeGiocatore1} ");
                //     Thread.Sleep(1000);

                //     if (dado1 == dado2)
                //     {
                //         System.Console.WriteLine("doppio numero! tiri di nuvo :)");
                //         goto doppioNumero;
                //     }
                logicaControllo(posizioneGiocatori,posizioneGiocatori[i], i, nomiGiocatori, risultatoLancio1, risultatoLancio2 );

                    //prima di andare avanti aggiorno la posizione in base a ciò che dice la posizione che viene fuori
                    //dalla somma dei dadi con quello che dice di fare la casella su cui capito
                     int maxNumber = 0;
                    switch (posizioneGiocatori[i])
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            
                            break;
                        case 4:  //muoviti una posizione davanti al primo in classifica
                            maxNumber = 0;
                            foreach(var posGiocatore in posizioneGiocatori)
                            {
                                if(posGiocatore>maxNumber)
                                {
                                    maxNumber=posGiocatore;
                                }
                            }
                            posizioneGiocatori[i] = maxNumber + 1;
                            System.Console.WriteLine("\nEFFETTO CASELLA:\n");
                            System.Console.WriteLine("\n Voli davanti al primo!!! \n");
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8: //teletrasporto: ti sposti alla casella 14
                            posizioneGiocatori[i] = 14;
                            System.Console.WriteLine("\nEFFETTO CASELLA:\n");
                            System.Console.WriteLine("\n Vai avanti fino alla casella 14 \n");
                            break;
                        case 9:
                            break;
                        case 10: //randomic: ti sposti su un mupltiplo di 2 a caso inferiore o = a 30
                            while(true)
                            {
                                int randomicnumber =random.Next(4,31);
                                posizioneGiocatori[i]=randomicnumber;
                                if(randomicnumber%2==0)
                                {
                                    break;
                                }
                            }
                            System.Console.WriteLine("\nEFFETTO CASELLA:\n");
                            System.Console.Write("\n Estrazione di un mupltiplo di 2 a caso inferiore o = a 30");
                            Thread.Sleep(500);
                            System.Console.Write(".");
                            Thread.Sleep(500);
                            System.Console.Write(".");
                            Thread.Sleep(500);
                            System.Console.WriteLine(".");
                            Thread.Sleep(500);
                            System.Console.WriteLine("è uscito il " + posizioneGiocatori[i] + "!!!");
                            break;
                        case 11:
                            break;
                        case 12:
                            break;
                        case 13:
                            break;
                        case 14:
                            break;
                        case 15:
                            break;
                        case 16:
                            break;
                        case 17:
                            break;
                        case 18:
                            break;
                        case 19:
                            break;
                        case 20:
                            break;
                        case 21:
                            break;
                    }


                    //implemento la visualizzazione grafica del gioco nel txt
                    string filePath = "C:/Users/DOTNET/Documents/Corso-Dotnet-2024/CORSO-DOTNET-2024/esercitazioni-dotnet-2024/esercitazione1/fileDadi.csv";

                    //legge tutte le righe del file e salva ogni riga come stringa in 1 cella
                    string[] lines = File.ReadAllLines(filePath);

                    //mette/sposta il nome del giocatore nella casella in cui è arrivato
                    int contatorePerFile = 0;

                    foreach (string line in lines)
                    {
                        contatorePerFile++;

                        //se la riga contiene il numero relativo alla posizione del giocatore, aggiungo il nome del giocatore alla riga
                        if (line.Contains(posizioneGiocatori[i].ToString()))
                        {
                            // Rimuovo il nome del giocatore dalla posizione precedente se è presente
                            for (int j = 0; j < lines.Length; j++)
                            {
                                //la funzione replace cerca il nome del giocatore (nomiGiocatori[i]) e lo sostituisce con una linea vuota)
                                lines[j] = lines[j].Replace(nomiGiocatori[i], string.Empty);
                            }

                            //aggiungo il nome del giocatore nella posizione aggiornata
                            lines[contatorePerFile - 1] += nomiGiocatori[i];
                            break;
                        }
                    }
                    File.WriteAllLines(filePath, lines);
                    contatorePerFile = 0;


                    if (i + 1 == numeroGiocatori) //se i giocatori hanno giocato tutti, rinizio il ciclo di giocate dal primo
                    {
                        System.Console.WriteLine($"quando sei pronto per tirare {nomiGiocatori[0]} premi un tasto");
                        Console.ReadKey(true);
                        System.Console.WriteLine();
                        continue;
                    }
                    System.Console.WriteLine($"quando sei pronto per tirare {nomiGiocatori[i + 1]} premi un tasto");
                    Console.ReadKey(true);
                    System.Console.WriteLine();
                }
            }
            // break;
        }
    }

    public static void lancioDadi()
    {
        Random random = new Random();
        int dado1 = random.Next(1, 7);//escono numeri da 1 a 6
        int dado2 = random.Next(1, 7);//escono numeri da 1 a 6
    }

    public static void logicaControllo(int[] posizioneGiocatori, int posizioneGiocatorePosI, int i, string[] nomiGiocatori, int risultatoLancio1, int risultatoLancio2)
    {
        doppioNumero:
        Random random = new Random();
        // Dado dado1 = new Dado();
        // Dado dado2 = new Dado();
        // int risultatoLancio1 = dado1.Lancia();//escono numeri da 1 a 6
        // int risultatoLancio2 = dado2.Lancia();//escono numeri da 1 a 6

        //. . . 
        System.Console.Write(". ");
        Thread.Sleep(500);
        System.Console.Write(". ");
        Thread.Sleep(500);
        System.Console.Write(". \n \n");
        Thread.Sleep(500);

        posizioneGiocatori[i] = posizioneGiocatorePosI + risultatoLancio1 + risultatoLancio2; //aggiorno la posizione del giocatore che gioca

        System.Console.WriteLine($"{nomiGiocatori[i]} ha fatto {risultatoLancio1} e {risultatoLancio2}");
        System.Console.WriteLine("posizione aggiornata: casella numero " + posizioneGiocatori[i]);
        Thread.Sleep(1000);

        if (risultatoLancio1 == risultatoLancio2)
        {
            System.Console.WriteLine("doppio numero! tiri di nuvo :)");
            goto doppioNumero;
        }
    }
}

