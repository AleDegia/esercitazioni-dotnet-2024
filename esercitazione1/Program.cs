class Program
{
    
    static void Main()
    {
        int numeroGiocatori = 0;
    int [] posizioneGiocatori = new int [6];
        //chiedo in quanti si è a giocare
        while (true)
        {
            try
            {
                System.Console.WriteLine("In quanti siete a giocare? Si gioca al massimo in 6");
                numeroGiocatori = Int32.Parse(Console.ReadLine());
                //se ci sono + di 6 giocatori non si può iniziare a giocare e ritorna all'inizio del while
                if(numeroGiocatori>6)
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

        string [] nomiGiocatori = new string [6];
        int[] abilita = new int[2];
        Dictionary<string, int> abilitaGiocatori = new Dictionary<string, int>();
        // Dictionary<int, string> associazioneTurniNomi = new Dictionary<int, string>();
        int[] caselle = new int[56];
        int contatore = 1;


        //assegno i nomi dei giocatori alla rispettive variabili nell'array uno ad uno grazie al ciclo
        for(int i=0; i<numeroGiocatori; i++)
        {
            System.Console.WriteLine($"Inserisci il nome del giocatore {contatore}");
            string nomeGiocatoreInput = Console.ReadLine();
            nomiGiocatori[i] = nomeGiocatoreInput;
            System.Console.WriteLine($"Scegli l'abilità che vuoi usare");
            System.Console.WriteLine("digita 1 per Controllo, 2 per ...");
            int abilitaScelta =  Int32.Parse(Console.ReadLine());
            // associazioneTurniNomi.Add(i+1,nomiGiocatori[i]);
            contatore++;

            switch(abilitaScelta)
            {
                case 1:
                    System.Console.WriteLine($"{nomiGiocatori[i]} ha scelto 'Controllo' ");
                    abilitaGiocatori.Add(nomiGiocatori[i],1);
                    continue;
                case 2:
                    System.Console.WriteLine($"{nomiGiocatori[i]} ha scelto 'Abilita2' ");
                    abilitaGiocatori.Add(nomiGiocatori[i],2);
                    continue;
            }
        }


        int[] turnoGiocatore = {1,2,3,4,5,6};
        int turno=1;
        int dado1;
        int dado2;

        Random random = new Random();
        

        System.Console.WriteLine("\n INIZIAMO! \n");

        while(true)
        {  
            
            for(int i=0; i<numeroGiocatori; i++)  //ciclo per eseguire le istruzioni in base al turno del giocatore
            {   
                
                //se il nome giocatore che usa l'abilità è il nome giocatore in pos i di nomiGiocatori vuol dire che è il suo turno
                if(abilitaGiocatori.ContainsValue(1) && abilitaGiocatori.ContainsKey(nomiGiocatori[i]) && turnoGiocatore[i] == turno)
                {
                //--------------------------------------------------------------
                // METODO LOGICA CONTROLLO

                doppioNumero2:
                dado1 = random.Next(1, 7);//escono numeri da 1 a 6
                dado2 = random.Next(1, 7);//escono numeri da 1 a 6
                
                //. . . 
                System.Console.Write(". ");
                Thread.Sleep(500);
                System.Console.Write(". ");
                Thread.Sleep(500);
                System.Console.Write(". \n \n");
                Thread.Sleep(500);

                posizioneGiocatori[i] = posizioneGiocatori[i] +dado1+dado2; //aggiorno la posizione del giocatore che gioca
                
                System.Console.WriteLine($"{nomiGiocatori[i]} ha fatto {dado1} e {dado2}");
                System.Console.WriteLine("posizione aggiornata: casella numero " + posizioneGiocatori[i]);
                //posizioneGiocatore1 = posizioneGiocatore1+dado1+dado2;
                //System.Console.WriteLine($"{nomeGiocatore1} ");
                Thread.Sleep(1000);

                if(dado1==dado2)
                {
                    System.Console.WriteLine("doppio numero! tiri di nuvo :)");
                    goto doppioNumero2;
                }
                
                System.Console.WriteLine("vuoi atterrare di 1 avanti o no? y/n");
                string input = Console.ReadLine();
                if(input=="y")
                {
                    posizioneGiocatori[i]+=1;
                    System.Console.WriteLine("ora sei nella casella " + posizioneGiocatori[i]);
                }

                if(i+1==numeroGiocatori) //se i giocatori hanno giocato tutti, rinizio il ciclo di giocate dal primo
                {
                    System.Console.WriteLine($"quando sei pronto per tirare {nomiGiocatori[0]} premi un tasto");
                    Console.ReadKey(true);
                    System.Console.WriteLine();
                    continue;
                }
                System.Console.WriteLine($"quando sei pronto per tirare {nomiGiocatori[i+1]} premi un tasto");
                Console.ReadKey(true);
                System.Console.WriteLine();
                } 
                else 
                {


                doppioNumero:
                dado1 = random.Next(1, 7);//escono numeri da 1 a 6
                dado2 = random.Next(1, 7);//escono numeri da 1 a 6
                
                //. . . 
                System.Console.Write(". ");
                Thread.Sleep(500);
                System.Console.Write(". ");
                Thread.Sleep(500);
                System.Console.Write(". \n \n");
                Thread.Sleep(500);

                posizioneGiocatori[i] = posizioneGiocatori[i] +dado1+dado2; //aggiorno la posizione del giocatore che gioca
                
                System.Console.WriteLine($"{nomiGiocatori[i]} ha fatto {dado1} e {dado2}");
                System.Console.WriteLine("posizione aggiornata: casella numero " + posizioneGiocatori[i]);
                //posizioneGiocatore1 = posizioneGiocatore1+dado1+dado2;
                //System.Console.WriteLine($"{nomeGiocatore1} ");
                Thread.Sleep(1000);

                if(dado1==dado2)
                {
                    System.Console.WriteLine("doppio numero! tiri di nuvo :)");
                    goto doppioNumero;
                }

                //implemento la visualizzazione grafica del gioco nel txt
                string filePath = "C:/Users/DOTNET/Documents/Corso-Dotnet-2024/CORSO-DOTNET-2024/esercitazioni-dotnet-2024/esercitazione1/fileDadi.csv";
                string filePath2 ="C:/Users/DOTNET/Documents/Corso-Dotnet-2024/CORSO-DOTNET-2024/esercitazioni-dotnet-2024/esercitazione1/fileDadi2.csv";

                //legge tutte le righe del file e salva ogni riga come stringa in 1 cella
                string[] lines = File.ReadAllLines(filePath2); 
                
                //mette/sposta il nome del giocatore nella casella in cui è arrivato
                 int contatorePerFile = 0;
                 foreach(string line in lines)
                 {
                    contatorePerFile++;
                    //se la linea è formata da numero e nomeGiocatore corrente ma il giocatore si trova in una posizione diversa (percio se la riga è stata formata il giro prima e non è aggiornata al nuovo punteggio, uso replace per levare il nome)
                    if(line.Contains(posizioneGiocatori[i].ToString())&& posizioneGiocatori[i]!=contatorePerFile)
                    {
                        lines[contatorePerFile] = lines[contatorePerFile].Replace(nomiGiocatori[i], string.Empty);
                    }
                    //se la riga contiene il numero relativo alla posizione del giocatore, aggiungo il nome del giocatore alla riga
                    if(line.Contains(posizioneGiocatori[i].ToString()))
                    {
                       lines[contatorePerFile] += nomiGiocatori[i];
                       break;
                    }

                 }
                 File.WriteAllLines(filePath, lines);
                            

                if(i+1==numeroGiocatori) //se i giocatori hanno giocato tutti, rinizio il ciclo di giocate dal primo
                {
                    System.Console.WriteLine($"quando sei pronto per tirare {nomiGiocatori[0]} premi un tasto");
                    Console.ReadKey(true);
                    System.Console.WriteLine();
                    continue;
                }
                System.Console.WriteLine($"quando sei pronto per tirare {nomiGiocatori[i+1]} premi un tasto");
                Console.ReadKey(true);
                System.Console.WriteLine();
            }}
        // break;
        }
    }

    public static void logicaControllo(int[] posizioneGiocatori, int i, string[] nomiGiocatori, int numeroGiocatori)
    {
        doppioNumero:
                Random random = new Random();
                int dado1 = random.Next(1, 7);//escono numeri da 1 a 6
                int dado2 = random.Next(1, 7);//escono numeri da 1 a 6
                
                //. . . 
                System.Console.Write(". ");
                Thread.Sleep(500);
                System.Console.Write(". ");
                Thread.Sleep(500);
                System.Console.Write(". \n \n");
                Thread.Sleep(500);

                posizioneGiocatori[i] = posizioneGiocatori[i] +dado1+dado2; //aggiorno la posizione del giocatore che gioca
                
                System.Console.WriteLine($"{nomiGiocatori[i]} ha fatto {dado1} e {dado2}");
                System.Console.WriteLine("posizione aggiornata: casella numero " + posizioneGiocatori[i]);
                //posizioneGiocatore1 = posizioneGiocatore1+dado1+dado2;
                //System.Console.WriteLine($"{nomeGiocatore1} ");
                Thread.Sleep(1000);

                if(dado1==dado2)
                {
                    System.Console.WriteLine("doppio numero! tiri di nuvo :)");
                    goto doppioNumero;
                }

                if(i+1==numeroGiocatori) //se i giocatori hanno giocato tutti, rinizio il ciclo di giocate dal primo
                {
                    System.Console.WriteLine($"quando sei pronto per tirare {nomiGiocatori[0]} premi un tasto");
                    Console.ReadKey(true);
                    System.Console.WriteLine();
                    // continue;
                }
                System.Console.WriteLine($"quando sei pronto per tirare {nomiGiocatori[i+1]} premi un tasto");
                Console.ReadKey(true);
                System.Console.WriteLine();
    }
}