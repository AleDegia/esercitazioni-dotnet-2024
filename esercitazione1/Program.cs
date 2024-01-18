using System;
using System.IO;
using System.Net.Http;

class Program
{
    static void Main()
    {
        int number =0;
        int number2 = 0;
        int input =0;
        //bool verifica = true;

        while(true){
        try{

        //metodo che chieda il primo numero, metodo che chieda il secondo numero e un metodo che chieda l'operazione da fare. getire ecc /0, 1/2 da 0.., vogio che se sbaglio un inserimento m
        //mi richieda quell'inserimento specifico e non riparta richiedendo dal primo numero
        System.Console.WriteLine("Inserisci il primo numero");
        number = Convert.ToInt32(Console.ReadLine());
        
        System.Console.WriteLine("Inserisci il secondo numero");
        number2 = Convert.ToInt32(Console.ReadLine());

        System.Console.WriteLine("Digita: 1 per somma, 2 per sottrazione, 3 per moltiplicazione, 4 per divisione");
        ConsoleKeyInfo key = Console.ReadKey(true); //La versione di ReadKey con true come argomento imposta la proprietà Intercept su true, il che significa che il tasto premuto non verrà visualizzato sulla console. Ciò consente di acquisire l'input da tastiera senza dover premere invio.
        input = int.Parse(key.KeyChar.ToString());//conversione da keychar a stringa a intero

        // Verifica se l'input è valido
        if (input >= 1 && input <= 4)
        {
            
            // Esci dal ciclo while se l'input è valido
            break;
        }
        else
        {
            System.Console.WriteLine("Input non valido. Riprova.");
            continue; //rinizia il ciclo
        }
         }
        catch (Exception ex)
        {
            System.Console.WriteLine("input non valido");
            //verifica = false;
            

        }}

        bool condizione = true;
        while (condizione)
        {
            switch (input)
            {
                case 1: //se il valore della variabile dentro le parentesi tonde dello switch è quello scritto dopo il case, esegue, altrimenti passa al prossimo case
                    System.Console.WriteLine($"{number} + {number2} è uguale a {number + number2}");
                    break;
                case 2:
                    System.Console.WriteLine($"{number} - {number2} è uguale a {number - number2}");
                    break;
                case 3: //se il valore della variabile dentro le parentesi tonde dello switch è quello scritto dopo il case, esegue, altrimenti passa al prossimo case
                    System.Console.WriteLine($"{number} * {number2} è uguale a {number * number2}");
                    break;
                case 4:
                    System.Console.WriteLine($"{number} / {number2} è uguale a {number / number2}");
                    break;
                default:
                    System.Console.WriteLine($"operazione non riconosciuta");
                    break;
            }

            System.Console.WriteLine("Digita: 1 per cambiare i valori dei due numeri, 2 per cambiare tipo di operazione, 3 per uscire ");
            int input2 = Convert.ToInt32(Console.ReadLine());

            switch (input2)
            {
                case 1: //se il valore della variabile dentro le parentesi tonde dello switch è quello scritto dopo il case, esegue, altrimenti passa al prossimo case
                    System.Console.WriteLine("Inserisci il primo numero");
                    number = Convert.ToInt32(Console.ReadLine());

                    System.Console.WriteLine("Inserisci il secondo numero");
                    number2 = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2:
                    System.Console.WriteLine("Digita: 1 per somma, 2 per sottrazione, 3 per moltiplicazione, 4 per divisione");
                    input = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3: //se il valore della variabile dentro le parentesi tonde dello switch è quello scritto dopo il case, esegue, altrimenti passa al prossimo case
                    System.Console.WriteLine($"stai uscendo..");
                    return;
                default:
                    System.Console.WriteLine($"operazione non riconosciuta");
                    break;
            }
        }
    }
}