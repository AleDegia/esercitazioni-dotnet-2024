using System.Diagnostics.Contracts;
using System.Reflection.Emit;

class Program //roulette , da implementare switch per puntare su pari e dispari, e implementare lo 0, usare funzioni asincrone x timer di chiusura puntate e inizio roultette, anche un rigioca ultima puntata fatta.
{
    static void Main()
    {

        int vittorie = 0;
        int sconfitte = 0;

        //----------------------------------------

        double balance = 100.0;
        double importoScommessa = 0;
        int scelta = 0;
        int scelta1 = 0;

        //int punteggio = 0;
        int quantitaNumeriScelti = 0;
        double probabilitaVittoria = (10 * quantitaNumeriScelti);
        int contatore = 0;
        string numeroScelto = null;
        int[] numeriArray = new int[0];



        while (true)
        {

            double percentualeVittorie = CalcolaPercentuale(vittorie, vittorie + sconfitte);
            double percentualeSconfitte = CalcolaPercentuale(sconfitte, vittorie + sconfitte);

            Console.WriteLine($"Percentuale di vittorie: {Math.Round(percentualeVittorie, 2)}%");
            Console.WriteLine($"Percentuale di sconfitte: {Math.Round(percentualeSconfitte, 2)}%");


            // Metodo per calcolare la percentuale
            static double CalcolaPercentuale(int parte, int totale)
            {
                if (totale == 0)
                {
                    return 0.0; // Gestione caso in cui il totale è zero per evitare divisione per zero
                }

                return ((double)parte / totale) * 100;
            }

            /////////////////////////////


            Random random = new Random();
            int numeroDaInd = random.Next(1, 11);
            Console.WriteLine("\nIndovina il numero sorteggiato");

            while (true) //ciclo che mi richiede l'importo finchè non è valido, ovvero minore del mio saldo
            {
                try
                {
                    System.Console.WriteLine("Scegli l'importo da scommettere");
                    importoScommessa = Convert.ToDouble(Console.ReadLine());
                    if (importoScommessa <= balance)
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

            //sottraggo l'importo dal balance
            balance -= importoScommessa;

        Label:
            try
            {

                System.Console.WriteLine("Che tipo di puntata vuoi fare? 1:pari o dispari, 2: prima metà/seconda metà, 3: numero singoli");
                scelta1 = Int32.Parse(Console.ReadLine());

                switch (scelta1)
                {
                    case 1: //se il valore della variabile dentro le parentesi tonde dello switch è quello scritto dopo il case, esegue, altrimenti passa al prossimo case
                        System.Console.WriteLine($"pari o dispari? 1:pari, 2:dispari");
                        scelta = Int32.Parse(Console.ReadLine());
                        
                        switch (scelta)
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
                        scelta = Int32.Parse(Console.ReadLine());
                        switch (scelta)
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

            while (true)
            {
                try
                {
                    //verifico quale scelta è stata fatta e assegno il valore alla stringa numeroScelto
                    if (scelta1 == 3)
                    {
                        Console.WriteLine("Scegli su quali numeri scommettere da 1 a 10 (inserisci i numeri separati da virgole):");
                        numeroScelto = Console.ReadLine();
                    }

                    if (scelta1 == 1 && scelta == 1)
                    {
                        numeroScelto = "2,4,6,8,10";
                    }
                    else if (scelta1 == 1 && scelta == 2)
                    {
                        numeroScelto = "1,3,5,7,9";
                    }

                    if (scelta1 == 2 && scelta == 1)
                    {
                        numeroScelto = "1,2,3,4,5";
                    }
                    else if (scelta1 == 2 && scelta == 2)
                    {
                        numeroScelto = "6,7,8,9,10";
                    }

                    // Divido la stringa usando il carattere ','
                    string[] numeriStringa = numeroScelto.Split(',');

                    // Creo un array di interi per memorizzare i numeri e memorizzo la quantita di numeri che gioco 
                    //x calcolare poi il payout correttamente
                    numeriArray = new int[numeriStringa.Length];

                    quantitaNumeriScelti = numeriArray.Length;

                    //per ogni stringa di numeriStringa la metto nell'array numeriString convertita in int
                    for (int i = 0; i < numeriStringa.Length; i++)
                    {
                        numeriArray[i] = Int32.Parse(numeriStringa[i]);
                        //Console.WriteLine(numeriArray[i]);
                    }
                    break;
                }//chisura try
                catch
                {
                    System.Console.WriteLine("formato non valido");

                }

            }

            //. . . 
            System.Console.Write(". ");
            Thread.Sleep(500);
            System.Console.Write(". ");
            Thread.Sleep(500);
            System.Console.Write(". \n");
            Thread.Sleep(500);

            //paragono i numeri scelti col numero estratto col random
            foreach (int numero in numeriArray)
            {
                contatore++;
                if (numero == numeroDaInd)
                {
                    vittorie++;
                    System.Console.WriteLine("è uscito il " + numeroDaInd);
                    double percentualeGuadagno = 10.0 / quantitaNumeriScelti;

                    double guadagno = importoScommessa * percentualeGuadagno;
                    balance += guadagno;
                    System.Console.Write("Hai vinto ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine(guadagno);
                    Console.ResetColor(); //resetto colore caratteri
                    contatore = 0;
                    break;
                }
                //se per tutti i numeri che ho scelto non è uscito il num da indovinare
                else if (quantitaNumeriScelti == contatore)
                {
                    sconfitte++;
                    System.Console.WriteLine("è uscito il numero " + numeroDaInd);
                    System.Console.WriteLine("Hai perso :(");
                    quantitaNumeriScelti = 0;
                    contatore = 0; //riporto il contatore a 0 senno poi non entra 
                    break;
                }

                //vedo se per ogni numero quanti perdono. Se il numero delle perdite è = al numero dei numeri scommessi,
                //vado effettivamente a levare l'importo scommesso dal balance
                // else if(numero!=numeroDaInd)
                // {
                //     int conteggioNumeri = 0;
                //     conteggioNumeri++;
                //     if(conteggioNumeri==quantitaNumeriScelti)
                //     {
                //         System.Console.WriteLine("è uscito il " + numeroDaInd);
                //         System.Console.WriteLine("hai perso :(");
                //         double perdita = importoScommessa;
                //         balance -= perdita;
                //     }
                // }
            }


            System.Console.WriteLine();
            System.Console.WriteLine("balance attuale " + balance);
            System.Console.WriteLine("");

            Console.WriteLine("Vuoi continuare? (s/n)");
            string risposta = Console.ReadLine()!;
            if (risposta == "n")
            {
                break;
            }
            else
            { Console.Clear(); }
        }
    }
}