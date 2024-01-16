using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main() //questo ci da accesso a Task.Delay ad esempio
    {
        Console.WriteLine("Inizio del programma");

        // Chiamata a due funzioni asincrone
        Task operazione1 = EsempioFunzioneAsincrona("Operazione 1", 2000); //task fa si di chiamare in esecuzione la prima funzione asincrona e nel frattempo andare avanti nel codice al for
        Task operazione2 = EsempioFunzioneAsincrona("Operazione 2", 1000);

        // Continua ad eseguire altre operazioni asincrone mentre avviene il completamento delle prime due
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Altre operazioni in corso... Ciclo {i + 1}");
            await Task.Delay(500); // ulteriore operazione asincrona che esegue un ritardo di 0.5 secondi
        }

        // Aspetta il completamento delle due operazioni asincrone
        await operazione1;
        await operazione2;

        Console.WriteLine("Fine del programma");
    }

    static async Task EsempioFunzioneAsincrona(string nomeOperazione, int millisecondiAttessa)
    {
        Console.WriteLine($"Inizio di {nomeOperazione}");

        // Simula un'attesa asincrona
        await Task.Delay(millisecondiAttessa);

        Console.WriteLine($"Fine di {nomeOperazione}");
    }
}