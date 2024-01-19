//implementare: numero di tentativi quando indoviniamo, se inseriamo numero + alto o basso ci da suggerimenti dicendoci se il numero è + alto o + basso
//input utente per fargli mettere una moneta
//ricalcolare ogni volta il numero di monete presenti nella macchinetta

class Program //quando arrivi a un tot di punteggio, o inizia nuova partita, statistiche personali, guadagno se indovino
{ //a ogni giro 2 numeri a caso danno x4
    static void Main()
    {
        double balance=100;
        int importoScommessa=0;
        //int punteggio = 0;
        int quantitaNumeriScelti = 0;
        double probabilitaVittoria = (10 * quantitaNumeriScelti) ;
        //double probabilitaSconfitta = (quantitaNumeriScelti - 1.0) / quantitaNumeriScelti;
        

        while (true)
        {
            Random random = new Random();
            int numeroDaInd = random.Next(1, 11);
            Console.WriteLine("Indovina il numero sorteggiato");
            int tentativi = 0;
            
            while(true) //ciclo che mi richiede l'importo finchè non è valido, ovvero minore del mio saldo
            {
                System.Console.WriteLine("Scegli l'importo da scommettere");
                importoScommessa = Int32.Parse(Console.ReadLine());
                if(importoScommessa<=balance)
                {
                    break;
                }
            }

            //sottraggo l'importo dal balance
            balance -= importoScommessa;

            Console.WriteLine("Scegli su quanli numeri scommettere da 1 a 10 (inserisci i numeri separati da virgole):");
            string numeroScelto = Console.ReadLine();

            

            // Dividi la stringa usando il carattere ','
            string[] numeriStringa = numeroScelto.Split(',');

            // Crea un array di interi per memorizzare i numeri e memorizzo la quantita di numeri che gioco 
            //x calcolare poi il payout correttamente
            int[] numeriArray = new int[numeriStringa.Length];
            quantitaNumeriScelti = numeriArray.Length;

            //per ogni stringa di numeriStringa la metto nell'array numeriString convertita in int
            for(int i=0; i<numeriStringa.Length; i++)
            {
                numeriArray[i] =  Int32.Parse(numeriStringa[i]);
            }
            //paragono i numeri scelti col numero estratto col random
            foreach(var numero in numeriArray)
            {
                if(numero==numeroDaInd)
                {
                    System.Console.WriteLine("è uscito il " + numeroDaInd);
                    System.Console.WriteLine("Hai vinto");
                    
                    
                    double percentualeGuadagno = 10/quantitaNumeriScelti;
                    
                    double guadagno = importoScommessa * percentualeGuadagno;
                    balance += guadagno;
                    System.Console.WriteLine("qn" + quantitaNumeriScelti);
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
        }
    }
}
        
    