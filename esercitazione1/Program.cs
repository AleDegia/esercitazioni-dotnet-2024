

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
        Dictionary<int, string> abilitaGiocatori = new Dictionary<int, string>();
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
                    abilitaGiocatori.Add(1,nomiGiocatori[i]);
                    continue;
                case 2:
                    System.Console.WriteLine($"{nomiGiocatori[i]} ha scelto 'Abilita2' ");
                    abilitaGiocatori.Add(2,nomiGiocatori[i]);
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
                if(abilitaGiocatori.ContainsKey(1) && abilitaGiocatori.ContainsValue(nomiGiocatori[i]) && turnoGiocatore[i] == turno)
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
                string filePath = "C:/Users/DOTNET/Documents/Corso-Dotnet-2024/CORSO-DOTNET-2024/esercitazioni-dotnet-2024/esercitazione1/fileDadi.txt";

                try
                {
                    // Apri il file in lettura utilizzando StreamReader
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string riga;
                        int numeroRiga = 1;

                        using (StreamWriter writer = new StreamWriter(filePath))
                        {

                        // Leggi ogni riga fino a quando raggiungi la fine del file
                        while ((riga = reader.ReadLine()) != null)
                        {
                            
                            // Esegui le operazioni desiderate con la riga letta
                            if(numeroRiga == posizioneGiocatori[i] && riga.Contains(posizioneGiocatori[i].ToString()))
                            {
                                 writer.WriteLine(" StringaAggiuntaAllaRiga" + riga);
                            }
                        }
                        }
                    }
                }
                catch (Exception e)
                {
                    // Gestisci l'eccezione
                    Console.WriteLine("Si è verificato un errore durante la lettura del file: " + e.Message);
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


