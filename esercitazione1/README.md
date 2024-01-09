# esercitazioni-dotnet-2024

>Prima esercitazione riguardante il versionamento

- 1 Versione semplice senza class e metodi entry point
- 2 Versione con entry point (metodo main static void)


### 05 - Dichiarare una variabile di tipo data:

```c#
class Program{
    static void Main(string[] args)
    {
        DateTime dataDiNascita = new DateTime(1980, 1, 1) ;
        Console.WriteLine($"Sei ìnato il {dataDiNascita}");
    }
}

```