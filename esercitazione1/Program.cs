//programma che utilizza la classe random x generare un numero compreso tra 1 e 10 per 10 volte (grazie al ciclo for) e vogliamo calcolare la somma
//per istanziare una classe si usa il costruttore new nomeClasse()
class Program
{
    static void Main()
    {
        Random random = new Random();
        int somma = 0;
        for (int i = 0; i < 10; i++)
        {
            int numero = random.Next(1,11); //genera numero casuale tra 1 e 10
            System.Console.WriteLine($"numero generato: {numero}");
            
            somma += numero; //somma = somma + numero
            System.Console.WriteLine($"La somma è {somma}");
        }
    }
}