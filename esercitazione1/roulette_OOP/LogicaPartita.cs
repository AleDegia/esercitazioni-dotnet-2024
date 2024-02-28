

public class LogicaPartita
{
    private int numeroGenerato;
    
    public int NumeroGenerato
    {
        get { return numeroGenerato; }
        set { numeroGenerato = value; }
    }

    Gioco gioco = new Gioco();
    Random random = new Random();
    public void generaNumeroCasuale()
    {
        numeroGenerato = random.Next(1,10);
    }

    // Metodo per calcolare la percentuale
    public double CalcolaPercentuale(int parte, int totale)
    {
        if (totale == 0)
        {
            return 0.0; // Gestione caso in cui il totale è zero per evitare divisione per zero
        }

        return ((double)parte / totale) * 100;
    }

    public void VerificaImporto(Giocatore giocatore1)
    {
        while (true) //ciclo che mi richiede l'importo finchè non è valido, ovvero minore del mio saldo
        {
            try
            {
                
                System.Console.WriteLine("Scegli l'importo da scommettere");
                gioco.ImportoScommessa = Convert.ToDouble(Console.ReadLine());
                if (gioco.ImportoScommessa <= giocatore1.Balance)
                {
                    break;
                }
                else 
                {
                    System.Console.WriteLine("Non hai abbastanza soldi, prova con un importo che possiedi");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("formato non valido");
            }
        }
    }

    public void sottraiImportoScommessa(Giocatore giocatore1, Gioco gioco)
    {
        //sottraggo l'importo dal balance
        giocatore1.Balance -= gioco.ImportoScommessa;
    }

    public void ScegliTipoScommessa(Giocatore giocatore1)
    {
        Label:
            try
            {

                System.Console.WriteLine("Che tipo di puntata vuoi fare? 1:pari o dispari, 2: prima metà/seconda metà, 3: numero singoli");
                giocatore1.Scelta = Int32.Parse(Console.ReadLine());

                switch (giocatore1.Scelta)
                {
                    case 1: //se il valore della variabile dentro le parentesi tonde dello switch è quello scritto dopo il case, esegue, altrimenti passa al prossimo case
                        System.Console.WriteLine($"pari o dispari? 1:pari, 2:dispari");
                        giocatore1.Scelta2 = Int32.Parse(Console.ReadLine());
                        
                        switch (giocatore1.Scelta2)
                        {
                            case 1:
                                System.Console.WriteLine("scelta fatta!");
                                break;
                            case 2:
                                System.Console.WriteLine("scelta fatta!");
                                break;
                        }
                        break;
                    case 2:
                        System.Console.WriteLine($"prima metà(1 a 5) o seconda metà(6 a 10)? 1:prima, 2:seconda");
                        giocatore1.Scelta2 = Int32.Parse(Console.ReadLine());
                        switch (giocatore1.Scelta2)
                        {
                            case 1:
                                System.Console.WriteLine("scelta fatta!");
                                break;
                            case 2:
                                System.Console.WriteLine("scelta fatta!");
                                break;
                        }
                        break;
                    case 3:
                        break;
                    default:
                        System.Console.WriteLine("input non valido");
                        goto Label;
                }
            }
            catch
            {
                System.Console.WriteLine("input non valido");
                System.Console.WriteLine();
                goto Label;
            }
    }

    public void sceltaNumeriDaScommettere(Giocatore giocatore1)  //scelta è scelta, scelta 1 è scelta2
    {
        while (true)
            {
                try
                {
                    //verifico quale scelta è stata fatta e assegno il valore alla stringa numeroScelto
                    if (giocatore1.Scelta2 == 3)
                    {
                        Console.WriteLine("Scegli su quali numeri scommettere da 1 a 10 (inserisci i numeri separati da virgole):");
                        gioco.NumeroScelto = Console.ReadLine();
                    }

                    if (giocatore1.Scelta == 1 && giocatore1.Scelta2 == 1)
                    {
                        gioco.NumeroScelto = "2,4,6,8,10";
                    }
                    else if (giocatore1.Scelta == 1 && giocatore1.Scelta2 == 2)
                    {
                        gioco.NumeroScelto = "1,3,5,7,9";
                    }

                    if (giocatore1.Scelta == 2 && giocatore1.Scelta2 == 1)
                    {
                        gioco.NumeroScelto = "1,2,3,4,5";
                    }
                    else if (giocatore1.Scelta == 2 && giocatore1.Scelta2 == 2)
                    {
                        gioco.NumeroScelto = "6,7,8,9,10";
                    }

                    // Divido la stringa usando il carattere ','
                    string[] numeriStringa = gioco.NumeroScelto.Split(',');

                    // Creo un array di interi per memorizzare i numeri e memorizzo la quantita di numeri che gioco 
                    //x calcolare poi il payout correttamente
                    gioco.ArrayNumeriScelti = new int[numeriStringa.Length];

                    gioco.QuantitaNumeriScelti = gioco.ArrayNumeriScelti.Length;

                    //per ogni stringa di numeriStringa la metto nell'array numeriString convertita in int
                    for (int i = 0; i < numeriStringa.Length; i++)
                    {
                        gioco.ArrayNumeriScelti[i] = Int32.Parse(numeriStringa[i]);
                        //Console.WriteLine(numeriArray[i]);
                    }
                    break;
                }//chisura try
                catch
                {
                    System.Console.WriteLine("formato non valido");

                }

            }
    }
}