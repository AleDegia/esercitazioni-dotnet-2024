using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Inizio del programma");

        // Esempio di Task.Run per eseguire un ciclo che richiede tempo
        var taskEsempioCiclo = Task.Run(async () => await EsempioCiclo());

        // Operazioni che possono essere eseguite durante l'attesa
        await Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Attività durante l'attesa: Passo {i + 1}");
                Task.Delay(500).Wait(); // Simula un ritardo di 0.5 secondi durante ogni passo
            }
        });

        // Attendiamo il completamento dell'operazione che richiede tempo
        await taskEsempioCiclo;

        Console.WriteLine("Fine del programma");
    }

    static async Task EsempioCiclo()
    {
        Console.WriteLine("Inizio dell'operazione che richiede tempo");

        // Simulazione di un ciclo che richiede tempo
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Passo {i + 1}...");
            await Task.Delay(2000); // Simula un ritardo di 2 secondi per ogni passo
        }

        Console.WriteLine("Fine dell'operazione che richiede tempo");
    }
}
