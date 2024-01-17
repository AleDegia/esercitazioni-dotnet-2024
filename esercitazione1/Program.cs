
using System.Reflection.Metadata;

class Program  //div per 3 stampi Fizz, per 5 stampi buzz, per entrambi stampi FizzBuzz
{
    static void Main()
    {
        Random random = new Random();
        int numeroSorteggiato = random.Next(0,101);
        //System.Console.WriteLine($"Il numero sorteggiato è {numeroSorteggiato}");  

        // if (numeroSorteggiato % 3 == 0 && numeroSorteggiato % 5 == 0)
        //     {
        //         System.Console.WriteLine($"{numeroSorteggiato} -> Fizz Buzz");
        //     }
        // else if (numeroSorteggiato % 3 == 0)
        //     {
        //         System.Console.WriteLine($"{numeroSorteggiato} -> Fizz");

        //     }
        //     else if (numeroSorteggiato % 5 == 0)
        //     {
        //         System.Console.WriteLine($"{numeroSorteggiato} -> Buzz");

        //     }
        //     else
        //     {
        //         System.Console.WriteLine(numeroSorteggiato);

        //     }
        
    }
}
