using System.Diagnostics.Contracts;

class Program //roulette
{ 
    static void Main()
    {

        int vittorie = 0;
        int sconfitte = 0;

        //----------------------------------------

        double balance=100.0;
        double importoScommessa=0;
        //int punteggio = 0;
        int quantitaNumeriScelti = 0;
        double probabilitaVittoria = (10 * quantitaNumeriScelti) ;
        int contatore = 0;
        string numeroScelto=null;
        int [] numeriArray = new int[0];
        
        

        while (true)
        {


            double percentualeVittorie = CalcolaPercentuale(vittorie, vittorie + sconfitte);
            double percentualeSconfitte = CalcolaPercentuale(sconfitte, vittorie + sconfitte);

            Console.WriteLine($"Percentuale di vittorie: {Math.Round(percentualeVittorie,2)}%");
            Console.WriteLine($"Percentuale di sconfitte: {Math.Round(percentualeSconfitte,2)}%");
    

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
            
            while(true) //ciclo che mi richiede l'importo finchè non è valido, ovvero minore del mio saldo
            {
                try
                {
                    System.Console.WriteLine("Scegli l'importo da scommettere");
                    importoScommessa = Convert.ToDouble(Console.ReadLine());
                    if(importoScommessa<=balance)
                    {
                        break;
                    }
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine("formato non valido");
                }
            }

            //sottraggo l'importo dal balance
            balance -= importoScommessa;

             while(true){
            try{
            Console.WriteLine("Scegli su quali numeri scommettere da 1 a 10 (inserisci i numeri separati da virgole):");
            numeroScelto = Console.ReadLine();
            
            
            

            // Divido la stringa usando il carattere ','
            string[] numeriStringa = numeroScelto.Split(',');


            // Creo un array di interi per memorizzare i numeri e memorizzo la quantita di numeri che gioco 
            //x calcolare poi il payout correttamente
            numeriArray = new int[numeriStringa.Length];

            quantitaNumeriScelti = numeriArray.Length;
            
            //per ogni stringa di numeriStringa la metto nell'array numeriString convertita in int
            for(int i=0; i<numeriStringa.Length; i++)
            {
                numeriArray[i] =  Int32.Parse(numeriStringa[i]);
                //Console.WriteLine(numeriArray[i]);
            }
            break;
            }//chisura try
            catch
            {
                System.Console.WriteLine("formato non valido");
            }
            
             }
            //paragono i numeri scelti col numero estratto col random
            foreach(int numero in numeriArray)
            {
                contatore++;
                if(numero==numeroDaInd)
                {
                    vittorie++;
                    System.Console.WriteLine("è uscito il " + numeroDaInd);
                    double percentualeGuadagno = 10.0/quantitaNumeriScelti;
                    
                    double guadagno = importoScommessa * percentualeGuadagno;
                    balance += guadagno;
                    System.Console.WriteLine("Hai vinto " + guadagno);
                    contatore=0;
                    break;
                }   
                //se per tutti i numeri che ho scelto non è uscito il num da indovinare
                else if (quantitaNumeriScelti == contatore){
                    sconfitte++;
                    System.Console.WriteLine("è uscito il numero " + numeroDaInd);
                    System.Console.WriteLine("Hai perso :(");
                    quantitaNumeriScelti=0;
                    contatore=0; //riporto il contatore a 0 senno poi non entra 
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
            {Console.Clear();}
        }
    }
}