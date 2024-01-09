# ESERCITAZIONE BASE SU C# .NET  CORE

Ecco alcune esercitazioni base su C# .NET Core senza l'utilizzo di namespaces

**dotnet run >> eseguire il progetto console**

- 01 - Tipi di dato e variabili
- 02 - Operatori
- 03 - Strutture di dati
- 04 - Condizioni
- 05 - Cicli 

## 01 - Esercitazioni su tipi di dato e variabili

### 02 - Dichiarare una variabile di tipo intero:



```c#


class Program{
    static void Main(string[] args)
    {
        int eta = 20; ////gli interni non necessitano di apici doppi, evitare caratteri accentati nel nome delle variabili
        Console.WriteLine($"Hai {eta} anni");
    }
}
 

```


### 03 - Dichiarare una variabile di tipo booleano:

```c#

class Program{
    static void Main(string[] args)
    {
        bool maggiorenne = true; 
        Console.WriteLine($"Sei maggiorenne? {maggiorenne}");
    }
}
```

### 04 - Decimal


```c#
class Program{
    static void Main(string[] args)
    {
        decimal numeroDecimal = 123.45m;
        Console.WriteLine($"il numero decimale è {numeroDecimal}");
    }
}

```

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

### 06 - Stampare un'istanza di tipo data che non includa l'orario

```c#
class Program
{
    static void Main(string[] args)
    {
        DateTime dataDiNascita = new DateTime(1980, 1, 1) ;
        Console.WriteLine($"Sei nato il {dataDiNascita.ToShortDateString()}"); // rappresentazione breve della data senza includere l'orario con la funz ToShortDateString()
    }
}

```c#


### 07 - Interpolazione e operatore +

```c#
class Program{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        int c = a + b;
        System.Console.WriteLine($"la somma di {a} e {b} è {c}");
    }
}
```

### 08 - Somma con decimali

```c#
class Program{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        decimal c = 1.5m; // il carattere "m" alla fine di un valore numerico letterale indica che il numero è di tipo decimal. La presenza della "m" è una convenzione sintattica specifica per i decimali in C# per evitare ambiguità tra i letterali di diversi tipi numerici. Se ometti la "m", il compilatore potrebbe interpretare il valore come un double e generare un errore di compilazione. In questo caso, il valore dell'int viene automaticamente convertito in un decimal prima della somma. anche per i double avviene.
        decimal d = a + b + c;
        System.Console.WriteLine($"la somma di {a}, {b} e {c} è {d}");
    }
}
```

### 09 - Confronto booleano tra 2 stringhe

```c#
class Program{
    static void Main(string[] args)
    {
        string nome = "Mario";
        string cognome = "Rossi";
        bool uguali = nome == cognome;
        Console.WriteLine($"I due nomi sono uguali? {uguali}");
    }
}
```

### 09.2 - Confronto booleano tra 2 stringhe con !=

```c#
class Program{
    static void Main(string[] args)
    {
        string nome = "Mario";
        string cognome = "Rossi";
        bool uguali = nome == cognome;
        bool diversi = nome != cognome;
        Console.WriteLine($"I due nomi sono uguali? {uguali}");
        Console.WriteLine($"I due nomi sono diversi? {diversi}");
    }
}
```