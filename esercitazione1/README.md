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

### 09.3 - Confronto booleano tra 2 numeri

```c#
class Program{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 10;
        bool maggiore = a > b;
        bool minoreOuguale = a <= b;
        
        Console.WriteLine($"Il primo numero è maggiore del secondo? {maggiore}");
        Console.WriteLine($"Il primo numero è minore o uguale rispetto al secondo? {minoreOuguale}");  
    }
}
```


### 10 - Array

```c#
class Program{
    static void Main(string[] args)
    {
        string[] nomi = new string[3]; //l'array deve essere predeterminato, va assegnato perciò subito il numero degli elementi
        nomi[0] = "Mario";
        nomi[1] = "Luigi"; 
        nomi[2] = "Giovanni"; 
        
        Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");
        Console.WriteLine($"Il numero di elementi è {nomi.Length}"); 
    }
}
```

### 10.1 - Rimozione elemento da array con interi e dichiarazione su una linea

```c#
class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        List<int> numberList = numbers.ToList();
        numberList.RemoveAt(2);
        numbers = numberList.ToArray();

        foreach (int number in numbers)
        {
            Console.WriteLine($"Ciao {number}");
        }
    }
}
//[1, 2, 4, 5]
```

### 10.2 - Sort per array

```c#
class Program
{
    static void Main(string[] args)
    {
        // Sort an int array
        int[] myNumbers = {5, 1, 8, 9};
        Array.Sort(myNumbers);
        foreach (int i in myNumbers)
        {
        Console.Writeline(i);
        }
        Console.WriteLine(myNumbers.Max());  // returns the largest value (9)
        Console.WriteLine(myNumbers.Min());  // returns the smallest value (1)
        Console.WriteLine(myNumbers.Sum());  // returns the sum of elements (23)
    }
}
//1
//5
//8
//9
//9 
//1 
//23
```

### Convertire l'array in un'unica stringa

```c#
class Program
{
    static void Main()
    {
        //Esempio di array join
        string[] nomi = new string[]{"Alice", "Bob", "Charlie"};

        //unisce tutti gli elementi dell'array nomi in una singola stringa
        string nomiConcatenati = String.Join(",", nomi);

        System.Console.WriteLine($"Ciao {nomiConcatenati}");
    }
}
// Ciao Alice,Bob,Charlie
```

### 11 - Liste

```c#
class Program{
    static void Main(string[] args)
    {
        List <string> nomi = new List<string>();  //utilizziamo il diamond invece delle parentesi quadre
        nomi.Add("Mario"); // l'aggiunta di un elemento avviene tramite il metodo Add()
        nomi.Add("Luigi"); // gli elementi vengono inseriti nell'ordine in cui li mettiamo
        nomi.Add("Giovanni"); 
        
        Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");
    }
}
```

### 11.1 - Liste con numeri e rimozione elemento

```c#
class Program{
    static void Main(string[] args)
    {
        List <int> numeri = new List<int>(); //gli int non necessitano gli apici doppi nemmeno qui
        numeri.Add(10);
        numeri.Add(20); 
        numeri.Add(30); 
        
        Console.WriteLine($" {numeri[0]}, {numeri[1]} e {numeri[2]}");
        Console.WriteLine($" {numeri.Count()}");
        Console.WriteLine($" {numeri}"); //da la posizione dove ha locato in memoria l'oggetto
        numeri.RemoveAt(2);
        Console.WriteLine($" {numeri[0]}, {numeri[1]} e {numeri[2]}"); // qua darà eccezione Index was out of range perchè l'elemento ad indice 2 è stato rimosso
    }
}
```

### 11.2 - Sort delle List

```c#
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a list of integers
        List<int> numbers = new List<int> { 5, 2, 8, 1, 3 };

        // Use the Sort method to sort the list
        numbers.Sort();

        // Display the sorted list
        Console.WriteLine("Sorted List:");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
    }
}
//1 2 3 5 8
```

### 11.3 - Sort delle liste personalizzato 

```c#
using System;
using System.Collections.Generic;

// Custom comparer class for sorting strings by length (Qui definiamo una classe chiamata StringLengthComparer che implementa l'interfaccia IComparer<string>. Questa interfaccia richiede l'implementazione del metodo Compare, che utilizzeremo per specificare la logica di confronto personalizzata.)
public class StringLengthComparer : IComparer<string> // l'interfaccia IComparer<T> è parte del framework .NET,
{
    public int Compare(string x, string y) //L'interfaccia IComparer<T> richiede l'implementazione del metodo Compare, che accetta due oggetti del tipo specificato (T) e restituisce un intero che indica l'ordine relativo degli oggetti.
    {
        // Compare strings based on their lengths
        return x.Length.CompareTo(y.Length);
    }
}

class Program
{
    static void Main()
    {
        // Create a list of strings
        List<string> words = new List<string> { "apple", "banana", "orange", "grape", "kiwi" };

        // Use the Sort method with the custom comparer (istanzio la classe StringLenghtComparer per usarne i metodi e dico al sort di usare il metodo dentro quella classe)
        words.Sort(new StringLengthComparer());

        // Display the sorted list
        Console.WriteLine("Sorted List by Length:");
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}
```

```c#
### 11.4 - Sort senza l'interfaccia 

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a list of strings
        List<string> words = new List<string> { "apple", "banana", "orange", "grape", "kiwi" };

        // Use Sort method with a custom comparison logic using a separate method
        words.Sort(CompareByLength);

        // Display the sorted list
        Console.WriteLine("Sorted List by Length:");
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }

    // Custom method for comparing strings by length
    static int CompareByLength(string x, string y)
    {
        return x.Length.CompareTo(y.Length);
    }
}

```

### 11.5 - Stessa cosa con lambda

```c#
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a list of strings
        List<string> words = new List<string> { "apple", "banana", "orange", "grape", "kiwi" };

        // Use Sort method with a custom comparison logic
        words.Sort((x, y) => x.Length.CompareTo(y.Length));

        // Display the sorted list
        Console.WriteLine("Sorted List by Length:");
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}
```

### 11.6 - Ordinamento complesso con liste

```c#
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create a list of numbers
        List<int> numbers = new List<int> { 15, 8, 25, 12, 7, 30, 18, 3, 10 };

        // Use Sort method with a custom comparison logic using a separate method
        numbers.Sort(CompareNumbers);

        // Display the sorted list
        Console.WriteLine("Sorted List (Multiples of 5 first, then others in descending order):");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
    }

    // Custom method for comparing numbers
    static int CompareNumbers(int x, int y)
    {
        // Multipli di 5 vengono posizionati prima
        if (x % 5 == 0 && y % 5 != 0)
            return -1; //nel metodo CompareTo, ciò che è -1 viene messo prima di ciò che è 1
        if (x % 5 != 0 && y % 5 == 0)
            return 1;

        // Ordine decrescente per gli altri numeri
        return y.CompareTo(x);
    }
}
```

### 11.7 - Convertire la lista in un'unica stringa


```c#
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Esempio con string.Join
        List<string> lista = new List<string> { "a", "b", "c" };
        string stringa = string.Join("", lista);

        Console.WriteLine(stringa);
    }
}

// a,b,c
```

### 12 - Stack (pile)

```c#
class Program
{
    static void Main(string[] args)
    {
        Stack<string> nomi = new Stack<string>(); //the last element added to the stack is the first one to be removed. 
        nomi.Push("Mario");//The code then pushes three strings onto the stack using the Push() method: "Mario", "Luigi", and "Giovanni". 
        nomi.Push("Luigi");//This means that "Giovanni" is now at the top of the stack, followed by "Luigi", and then "Mario".
        nomi.Push("Giovanni");//la stampa avviene prima della rimozione dell'elemento.
        System.Console.WriteLine($"Ciao {nomi.Pop()}, {nomi.Pop()}, {nomi.Pop()}"); //viene rimosso perciò sempre dall'ultimo aggiunto in giu
    }
}
//Ciao Giovanni, Luigi, Mario
```
### 12.1 - Stack dichiarato in 1 riga

```c#
class Program
{
    static void Main(string[] args)
    {
        Stack<string> nomi = new Stack<string>(new string[] { "Mario", "Luigi", "Giovanni" });
        foreach (string nome in nomi)
        {
            Console.WriteLine($"Ciao {nome}");
        }
    }
}
//Ciao Giovanni
//Ciao Luigi
//Ciao Mario
```

### 13 - Code 

```c#
class Program
{
    static void Main(string[] args)
    {
        Queue<string> nomi = new Queue<string>();  //the first element added to the queue is the first one to be removed. 
        nomi.Enqueue("Mario"); //la stampa avviene prima della rimozione dell'elemento.
        nomi.Count();
        nomi.Enqueue("Luigi");
        nomi.Enqueue("Giovanni");
        System.Console.WriteLine($"Ciao {nomi.Dequeue()}, {nomi.Count()}, {nomi.Dequeue()}, {nomi.Dequeue()}"); 
    }
} 
//Ciao Mario, 2, Luigi, Giovanni
```

### 14 - Dictionary 

```c#
class Program
{
    static void Main(string[] args)
    {
       Dictionary<string, string> nomi = new Dictionary<string, string>(); 
       nomi.Add("Mario", "Rossi");  //aggiungo coppie di valori
       nomi.Add("Luigi", "Verdi");
       nomi.Add("Giovanni", "Bianchi");
       System.Console.WriteLine($"Ciao {nomi["Mario"]} {nomi["Luigi"]} {nomi["Giovanni"]}"); //restituisco i valori
    }
} 
//Ciao Rossi Verdi Bianchi
```

### 14.1 - Dictionary aggiunta senza add

```c#
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> eta = new Dictionary<string, int>()
        {
            {"Mario", 25},
            {"Luigi", 30},
            {"Giovanni", 35}
        };

        Console.WriteLine($"Mario ha {eta["Mario"]} anni, Luigi {eta["Luigi"]}, Giovanni {eta["Giovanni"]}");
    }
}
//Mario ha 25 anni, Luigi 30, Giovanni 35
```


### 14.2 - Dictionary stampare chiavi

```c#
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Creazione e inizializzazione del dizionario
        Dictionary<string, int> mioDizionario = new Dictionary<string, int>();

        mioDizionario.Add("Chiave1", 10);
        mioDizionario.Add("Chiave2", 20);
        mioDizionario.Add("Chiave3", 30);

        // Stampare i valori delle chiavi
        foreach (var coppia in mioDizionario)
        {
            Console.WriteLine($"Chiave: {coppia.Key}, Valore: {coppia.Value}");
        }

        // Esempio di restituzione del valore dato una chiave specifica
        string chiaveDaCercare = "Chiave2";
        if (mioDizionario.ContainsKey(chiaveDaCercare))
        {
            int valoreAssociato = mioDizionario[chiaveDaCercare];
            Console.WriteLine($"Il valore associato alla chiave '{chiaveDaCercare}' è: {valoreAssociato}");
        }
        else
        {
            Console.WriteLine($"La chiave '{chiaveDaCercare}' non è presente nel dizionario.");
        }
    }
}
```

### 14.3 - Stampare chiavi easy 

```c#
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> eta = new Dictionary<string, int>()
        {
            {"Mario", 25},
            {"Luigi", 30},
            {"Giovanni", 35}
        };
        foreach (string nome in eta.Keys){
            Console.WriteLine($"Il signor {nome} ha {eta[$"{nome}"]} anni")
        }
    }
}
//Mario ha 25 anni, Luigi ha 30 anni, Giovanni ha 35 anni
```

### 15 - Condizione if

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        if(a>b) //tra le parentesi tonde dell'if c'è la condizione da verificare. se risulta vera, il codice tra le graffe verrà eseguito, altrimenti no
        {
            Console.WriteLine($"{a} è maggiore di {b}");
        }
        else 
        {
            Console.WriteLine($"{a} è minore di {b}");
        }
    }
} 
//10 è minore di 20
```


### 16 - Condizione if parte 2

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        if(a > b) //tra le parentesi tonde dell'if c'è la condizione da verificare. se risulta vera, il codice tra le graffe verrà eseguito, altrimenti no
        {
            Console.WriteLine($"{a} è maggiore di {b}");
        } 
        else if (a < b)
        {
            Console.WriteLine($"{a} è minore di {b}");
        }
        else //l'else deve sempre essere messo come ultima istruzione rispetto a if ed else if
        {
            Console.WriteLine($"{a} è uguale a {b}");
        }
    }
} 
//10 è minore di 20
```

### 17 - Switch 

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        switch(a)
        {
            case 10: //se il valore della variabile dentro le parentesi tonde dello switch è quello scritto dopo il case, esegue, altrimenti passa al prossimo case
                System.Console.WriteLine($"{a} è uguale a 10");
                break;
            case 20:
                System.Console.WriteLine($"{a} è uguale a 20");
                break;
            default:
                System.Console.WriteLine($"{a} non è uguale a 10 o 20");
                break;
        }
    }
} 
//10 è uguale a 10
```

### 18 - Ciclo For 

```c#
class Program
{
    static void Main(string[] args)
    {
        for(int i = 0; i < 10; i++)
        {
            System.Console.WriteLine($"Il vlaore di i è {i}");
        }
    }
} 
//Da 0 a 9
```
### 19 - Ciclo Foreach

```c#
class Program
{
    static void Main(string[] args)
    {
        string[] nomi = new string[3]; //l'array deve essere predeterminato, va assegnato perciò subito il numero degli elementi
        nomi[0] = "Mario";
        nomi[1] = "Luigi"; 
        nomi[2] = "Giovanni"; 
        
        foreach (string nome in nomi){
            Console.WriteLine($"Ciao {nome}"); 
        }
    }
}
//Ciao Mario
//Ciao Luigi
//Ciao Giovanni
```

### 20 - Esercizio Riassuntivo 

```c#
class Program
{
    static void Main(string[] args)
    {
        string[] nomi = new string[3];
        nomi[0] = "Mario";
        nomi[1] = "Luigi";
        nomi[2] = "Giovanni";
        List<string> nomiConM = new List<string>();

        foreach (string nome in nomi)
        {
            // Non è necessario dividere la parola in lettere, puoi confrontare direttamente la prima lettera
            if (nome[0] == 'M' || nome[0] == 'm') //mettendo i 2 apici da errore perchè per i singoli caratteri serve il singolo apice
            {
                // Aggiungi alla lista i nomi con la "M" o "m"
                nomiConM.Add(nome);
            }
        }

        foreach (string nomeSingolo in nomiConM)
        {
            System.Console.WriteLine(nomeSingolo);
        }
    }
}
```

### 21 - Input utente con ReadLine

```c#
class Program
{
   static void Main(string[] args)
    { 
        Console.WriteLine("scrivi il tuo nome");
        string? nome = Console.ReadLine(); //col punto di domanda anche se dichiaro una variabile che potrebbe essere null non me lo da come warning
        Console.WriteLine($"il nome inserito è {nome}, premi un tasto per terminare");
        Console.ReadKey(); //se premo un tasto mi termina il programma
    }
}
```

### 22 - Ciclo while

```c#
class Program
{
    static void Main(string[] args)
    {
        string[] nomi = { "Mario", "Luigi", "Giovanni" };

        int i = 0; //variabile contatore inizializzato a zero
        while(i < nomi.Length) //il ciclo continua finchè l'indice p minore della lunghezza dell'array
        {
            System.Console.WriteLine($"Ciao {nomi[i]}");
            i++; //incremento del contatore
        }
    }
}
```


### 22.1 - Ciclo while su lista

```c#
class Program
{
    static void Main(string[] args)
    {
        List<string> nomi = new List<string>{ "Mario", "Luigi", "Giovanni" };

        int i = 0; //variabile contatore inizializzato a zero
        while(i < nomi.Count) //il ciclo continua finchè l'indice p minore della lunghezza dell'array
        {
            System.Console.WriteLine($"Ciao {nomi[i]}");
            i++; //incremento del contatore
        }
    }
}
```

### 23 - ReadKey e ConsoleKeyInfo

```c#
class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Premi 'N' per terminare");

        //ciclo che continua fino a quando non viene prenmuto il tasto N 
        while(true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(); //Questa riga legge il tasto premuto dall'utente e salva le informazioni su di esso in una variabile keyInfo di tipo ConsoleKeyInfo.
            if (keyInfo.Key == ConsoleKey.N) //Qui viene verificato se il tasto premuto è 'N'.  non lo faccio con == "N" per non usare stringhe ma un comando apposito
            {
                break;
            }
        }
    }
}
```


### 24 - Modifiers

```c#
class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Premi 'Ctrl' + 'N' per terminare...");

        while(true)
        {
            //Aspetta finchè non viene premuto un tasto e memorizza il tasto premuto in keyInfo. Con true resta in attesa del secondo tasto senza displayarlo a tastiera
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            //Verifica se il tasto 'Ctrl' è tenuto premuto, matchando i valori binari dei tasti 
            if((keyInfo.Modifiers & ConsoleModifiers.Control) != 0)
            {
                //Controlla se il tasato premuto è 'Q'
                if(keyInfo.Key == ConsoleKey.N)
                {
                    System.Console.WriteLine("Combinazione 'Ctrl' + 'N' rilevata, uscita in corso...");
                    break;
                }
            }
        }
    }
}

/*
Il parametro booleano true nel metodo Console.ReadKey(true) indica che l'input della tastiera deve essere nascosto durante la lettura. 
Quando questo parametro è impostato su true, il carattere immesso non viene visualizzato sulla console mentre si aspetta che l'utente prema un tasto.
Se il parametro è impostato su false o non viene specificato (usando Console.ReadKey() senza argomenti), il carattere immesso sarà visibile sulla console.


I "tasti di modifica" si riferiscono ai tasti sulla tastiera che vengono premuti contemporaneamente a un tasto principale per modificare o estendere la sua funzione. 

La proprietà keyInfo.Modifiers Rappresenta i tasti di modifica associati ad un altro tasto premuto sulla tastiera e restituisce true o false se lo sto premendo
Questo valore rappresenta i tasti di controllo aggiuntivi che sono stati premuti contemporaneamente al tasto 'principale', tipo CTRL, ALT, il tasto WINDOWS. e ESC.
ConsoleModifiers.Control Indica il tasto 'Ctrl' tra i tasti di modifica possibili.
L'operatore & (AND bit a bit) combina i valori binari di keyInfo.Modifiers e ConsoleModifiers.Control
Bitwise AND operator is represented by &. It performs bitwise AND operation on the corresponding bits of two operands. If either of the bits is 0, the result is 0. Otherwise the result is 1.
L'espressione keyInfo.Modifiers & ConsoleModifiers.Control combina i tasti di modifica associati al tasto premuto con il tasto 'Ctrl'. 
Se il tasto 'Ctrl' è stato premuto, il risultato avrà almeno un bit impostato (vale a dire, sarà diverso da zero). Altrimenti, se il tasto 'Ctrl' non è stato premuto,
il risultato sarà zero. 

(Quando si preme un tasto sulla tastiera, l'informazione su quali tasti di modifica sono stati premuti viene spesso rappresentata internamente con un sistema binario, dove ciascun bit corrisponde a un tasto specifico. In questo caso, ConsoleModifiers.Control rappresenta il tasto 'Ctrl', e l'operatore & (AND bit a bit) viene utilizzato per combinare i bit associati ai tasti di modifica premuti.

Se il tasto 'Ctrl' è stato premuto, il bit corrispondente a ConsoleModifiers.Control sarà impostato a 1. Se il tasto 'Ctrl' non è stato premuto, il bit sarà a 0. Quando combiniamo questi bit con altri tasti di modifica utilizzando l'operatore &, otteniamo un risultato che conterrà 1 nei bit corrispondenti ai tasti di modifica premuti.
quando esegui (keyInfo.Modifiers & ConsoleModifiers.Control), stai facendo un'operazione di AND bit a bit tra la rappresentazione binaria dei tasti di modifica (keyInfo.Modifiers) e il valore binario rappresentante solo il tasto 'Ctrl' (ConsoleModifiers.Control).
Quindi, se il tasto 'Ctrl' è stato premuto, il risultato conterrà almeno un bit impostato (uguale a 1); se il tasto 'Ctrl' non è stato premuto, tutti i bit saranno a 0. La condizione != 0 verifica semplicemente se almeno uno di questi bit è diverso da zero, indicando che almeno un tasto di modifica è stato premuto.)


Se il tasto 'Ctrl' è stato premuto, il bit corrispondente a ConsoleModifiers.Control sarà impostato a 1, perchè?

La rappresentazione binaria di un valore di enumerazione è determinata dal modo in cui vengono assegnati i valori numerici ai membri dell'enumerazione. In C#, gli enumeratori sono rappresentati come valori integrali e, di default, il primo membro di un'enumerazione ha un valore numerico di 0, il secondo 1, il terzo 2 e così via.

Nel caso di ConsoleModifiers, che è un'enumerazione in C#, i valori numerici associati ai membri sono assegnati seguendo questa convenzione predefinita. Quindi, il primo membro (None) ha un valore di 0, il secondo membro (Alt) ha un valore di 1, il terzo membro (Control) ha un valore di 2, e così via.

Quando diciamo che "il bit corrispondente a ConsoleModifiers.Control sarà impostato a 1", significa che il valore numerico associato a ConsoleModifiers.Control è 2 (perché è il terzo membro dell'enumerazione secondo la convenzione di default). In binario, 2 si rappresenta come "10".

Quindi, se keyInfo.Modifiers rappresenta la combinazione dei tasti di modifica e ConsoleModifiers.Control è presente in questa combinazione, il bit corrispondente a ConsoleModifiers.Control sarà impostato a 1 nella rappresentazione binaria di keyInfo.Modifiers. Questo indica che il tasto 'Ctrl' è stato premuto.
*/
```


### 25 - esercizio menu con switch

```c#
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear(); // Pulisce la console ad ogni iterazione
            Console.WriteLine("Menu di Selezione");
            Console.WriteLine("1. Opzione Uno");
            Console.WriteLine("2. Opzione Due");
            Console.WriteLine("3. Opzione Tre");
            Console.WriteLine("4. Esci");

            Console.Write("Inserisci il numero dell'opzione desiderata: ");
            string input = Console.ReadLine();

            switch (input) 
            {
                case "1": //se il valore della variabile dentro le parentesi tonde dello switch è quello scritto dopo il case, esegue, altrimenti passa al prossimo case
                    Console.WriteLine("Hai selezionato l'Opzione Uno");
                    // Aggiungi qui la logica per l'Opzione Uno
                    break;
                case "2":
                    Console.WriteLine("Hai selezionato l'Opzione Due");
                    // Aggiungi qui la logica per l'Opzione Due
                    break;
                case "3":
                    Console.WriteLine("Hai selezionato l'Opzione Tre");
                    // Aggiungi qui la logica per l'Opzione Tre
                    break;
                case "4":
                    Console.WriteLine("Uscita in corso...");
                    return; // Esce dal programma
                default:
                    Console.WriteLine("Selezione non valida. Riprova.");
                    break;
            }

            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey(); // Aspetta che l'utente prema un tasto prima di continuare
        }
    }
}
```

### 26 - metodi input

```c#
class Program //aggiungere case name con variabile con nostro nome, quando facciamo case name stampi il nostro nome
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Inserisci un comando speciale (esempio: 'cmd:info', 'cmd:exit'):");

        while(true)
        {
            string? input = Console.ReadLine();

            //analizza l'input per vedere se segue un formato specifico
            if(input.StartsWith("cmd:"))
            {
                string comando = input.Substring(4); //estrae la parte del comando dopo cmd
                string nome = "Alessandro";

                switch(comando.ToLower())
                {
                    case "info":
                        System.Console.WriteLine("Comando 'info' riconosciuto. Mostrando le informazioni...");
                        //aggiungi qui la logica
                        break;
                    case "exit":
                        System.Console.WriteLine("Comando 'exit' riconosciuto. Uscita in corso...");
                        return;
                    case "name":
                        System.Console.WriteLine($"Ecco il tuo nome: {nome}");
                        break;
                    default:
                        System.Console.WriteLine($"Comando  '{comando}' non riconosciuto");
                        break;
                }
            }
            else 
            {
                System.Console.WriteLine("Input non valido. Inserisci un comando");
            }

            System.Console.WriteLine("\nInserisci un altro comando:");
        }
    }
}
```

### 26.1 - clear con input

```c#
class Program 
{
    static void Main(string[] args)
    {
        string? input = Console.ReadLine();
        if(input.StartsWith("clr"))
        {
            Console.Clear(); //pulizia console
            System.Console.WriteLine("pulizia riuscita");
        }
    }
}
```

### 26.2 - esercizio 

```c#
//fare vedere le info solo se si inserisce la password corretta come se fossero dei dati sensibili

class Program //aggiungere case name con variabile con nostro nome, quando facciamo case name stampi il nostro nome
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Inserisci un comando speciale (esempio: 'cmd:info', 'cmd:exit', cmd:login):");

        while(true)
        {
            string? input = Console.ReadLine();

            //analizza l'input per vedere se segue un formato specifico
            if(input.StartsWith("cmd:"))
            {
                string comando = input.Substring(4); //estrae la parte del comando dopo cmd
                string nome = "Alessandro";
                string password = "123";

               if(comando.ToLower() == "login")
               {
                        System.Console.WriteLine("Inserisci la password");
                        string inputPassword = Console.ReadLine();
                        string comando2 = input.Substring(4);

                         switch(comando2.ToLower())
                            {
                                case "123":
                                    System.Console.WriteLine("Comando 'info' riconosciuto. Mostrando le informazioni...");
                                    //aggiungi qui la logica
                                    break;
                            }

                switch(comando.ToLower())
                {
                    
                    case "exit":
                        System.Console.WriteLine("Comando 'exit' riconosciuto. Uscita in corso...");
                        return;
                    case "name":
                        System.Console.WriteLine($"Ecco il tuo nome: {nome}");
                        break;
                    default:
                        System.Console.WriteLine($"Comando  '{comando}' non riconosciuto");
                        break;
                }
            }
            else 
            {
                System.Console.WriteLine("Input non valido. Inserisci un comando");
            }

            System.Console.WriteLine("\nInserisci un altro comando:");
        }
    }
}}
```

### 27 - fileRead + Try-Catch

```c#
class Program //aggiungere case name con variabile con nostro nome, quando facciamo case name stampi il nostro nome
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Trascina un file qui e premi invio");
        string filePath = Console.ReadLine().Trim('"'); //creo il percorso per aprire il file, rimuovendo le virgolette che possono apparire nel percorso
         
        try
        {
            string content = File.ReadAllText(filePath); //legge tutte le righe del file e le memorizza nella stringa content
            System.Console.WriteLine("Contenuto del file:");
            System.Console.WriteLine(content);
        }
        catch(Exception ex)
        {
            System.Console.WriteLine($"Si è verificato un errore: {ex.Message}");
        }
    }
}

/*
Le virgolette intorno al percorso del file vengono considerate quando si trascina un file in una console su alcuni sistemi operativi.
 Questo comportamento può variare a seconda del sistema operativo e del modo in cui la console gestisce gli spazi nei percorsi dei file.
 */
 ```

 ### 27.1 - fileRead + Try-Catch con percorso fatto manualmente

```c#
 class Program //aggiungere case name con variabile con nostro nome, quando facciamo case name stampi il nostro nome
{
    static void Main(string[] args)
    {
        //System.Console.WriteLine("Trascina un file qui e premi invio");
        //string filePath = Console.ReadLine().Trim('"'); //creo il percorso per aprire il file, rimuovendo le virgolette che possono apparire nel percorso
        string filePath = "C:/Users/DOTNET/Documents/Corso-Dotnet-2024/CORSO-DOTNET-2024/esercitazioni-dotnet-2024/esercitazione1/prova.txt"; //percorso manualmente
        
        try
        {
            string content = File.ReadAllText(filePath); //legge tutte le righe del file e le memorizza nella stringa content
            System.Console.WriteLine("Contenuto del file:");
            System.Console.WriteLine(content);
        }
        catch(Exception ex)
        {
            System.Console.WriteLine($"Si è verificato un errore: {ex.Message}");
        }
    }
}

/*
Le virgolette intorno al percorso del file vengono considerate quando si trascina un file in una console su alcuni sistemi operativi.
 Questo comportamento può variare a seconda del sistema operativo e del modo in cui la console gestisce gli spazi nei percorsi dei file.
 */
 ```

 ### 28 - roba in +

```c#
 class Program 
{
    static void Main(string[] args)
    {
        //nasconde il cursore della console
        Console.CursorVisible = false; 

        //mostra il cursore
        Console.CursorVisible = true;

        //emette un beep
       //Console.Beep();
       
       //emette un beep con frequenza e durata specificate
       //Console.Beep(750, 300); //frequenza 750hz, durata 3000ms
       

        Console.Title = "La mia applicazione console";

        Console.Clear(); //pulizia console
    }
}
```

### 29 - Esercizio completo

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        System.Console.WriteLine("Seleziona l'opzione:");
        System.Console.WriteLine("1 - Nascondi il cursore");
        System.Console.WriteLine("2 - Mostra il cursore");
        System.Console.WriteLine("3 - Pulisci console");
        System.Console.WriteLine("4 - Emetti beep");
        System.Console.WriteLine("5 - Emetti beep prolungato");
        System.Console.WriteLine("6 - Imposta il titolo");
        System.Console.WriteLine("e - exit\n");

        while (true)
        {
            System.Console.WriteLine("Digita...");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.CursorVisible = false;
                    break;

                case "2":
                    Console.CursorVisible = true;
                    break;

                case "3":
                    Console.Clear();
                    break;

                case "4":
                    Console.Beep();
                    break;

                case "5":
                    System.Console.WriteLine("Inserisci la frequenza");
                    int freq = Int32.Parse(Console.ReadLine());

                    System.Console.WriteLine("Inserisci durata in ms");
                    int ms = Int32.Parse(Console.ReadLine());

                    Console.Beep(freq, ms);
                    break;

                case "6":
                    break;

                case "e":
                    return;

                default:
                    System.Console.WriteLine("Opzione errata:");
                    break;

            }

        }

    }
}
```

### 29.1 - Esercizio completo migliorato

```c#
class Program
{
    static void Main(string[] args)
    {   
        bool continua = true;

        do
        {
        // Console.Clear();
        System.Console.WriteLine("Seleziona l'opzione:");
        System.Console.WriteLine("1 - Nascondi il cursore");
        System.Console.WriteLine("2 - Mostra il cursore");
        System.Console.WriteLine("3 - Pulisci console");
        System.Console.WriteLine("4 - Emetti beep");
        System.Console.WriteLine("5 - Emetti beep prolungato");
        System.Console.WriteLine("6 - Imposta il titolo");
        System.Console.WriteLine("e - exit\n");

        
            System.Console.WriteLine("Digita...");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.CursorVisible = false;
                    break; //break all'interno di uno statement switch interrompe l'esecuzione del blocco switch e esce dallo switch. 

                case "2":
                    Console.CursorVisible = true;
                    break;

                case "3":
                    Console.Clear();
                    break;

                case "4":
                    Console.Beep();
                    break;

                case "5":
                    try
                    {
                    System.Console.WriteLine("Inserisci la frequenza");
                    int freq = Int32.Parse(Console.ReadLine());

                    System.Console.WriteLine("Inserisci durata in ms");
                    int ms = Int32.Parse(Console.ReadLine());
                    Console.Beep(freq, ms);
                    }
                    catch(Exception ex)
                    {
                        System.Console.WriteLine("input non valido");
                    }
                    break;

                case "6":
                    System.Console.WriteLine("Trascina un file qui e premi invio");
                    string filePath = Console.ReadLine().Trim('"'); //creo il percorso per aprire il file, rimuovendo le virgolette che possono apparire nel percorso
                    
                    try
                    {
                        string content = File.ReadAllText(filePath); //legge tutte le righe del file e le memorizza nella stringa content
                        System.Console.WriteLine("Contenuto del file:");
                        System.Console.WriteLine(content);
                    }
                    catch(Exception ex)
                    {
                        System.Console.WriteLine($"Si è verificato un errore: {ex.Message}");
                    }
                    break;

                case "e":
                    continua=false;//return; 
                    break;

                default:
                    System.Console.WriteLine("Opzione errata:");
                    break;

            }

            if(continua){
                System.Console.WriteLine("Premi un tasto per contiuare...");
                Console.ReadKey();
            }

        } while(continua);

    }
}
```

### 29.2 - Esercizio completo switch dentro switch

```c#
class Program
{
    static void Main(string[] args)
    {
        bool continua = true;

        do
        {
            // Console.Clear();
            System.Console.WriteLine("Seleziona l'opzione:");
            System.Console.WriteLine("1 - Comandi personalizzati");
            System.Console.WriteLine("2 - menu di selezione");
            System.Console.WriteLine("3 - Pulisci console");
            System.Console.WriteLine("4 - Emetti beep");
            System.Console.WriteLine("5 - Emetti beep prolungato");
            System.Console.WriteLine("6 - Imposta il titolo");
            System.Console.WriteLine("e - exit\n");


            System.Console.WriteLine("Digita...");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    System.Console.WriteLine("Inserisci un comando speciale (esempio: 'cmd:info', 'cmd:exit', 'cmd:name'):");

                    while (true)
                    {
                        string? input2 = Console.ReadLine();

                        //analizza l'input per vedere se segue un formato specifico
                        if (input2.StartsWith("cmd:"))
                        {
                            string comando = input2.Substring(4); //estrae la parte del comando dopo cmd
                            string nome = "Alessandro";

                            switch (comando.ToLower())
                            {
                                case "info":
                                    System.Console.WriteLine("Comando 'info' riconosciuto. Mostrando le informazioni...");
                                    //aggiungi qui la logica
                                    break;
                                case "exit":
                                    System.Console.WriteLine("Comando 'exit' riconosciuto. Uscita in corso...");
                                    return;
                                case "name":
                                    System.Console.WriteLine($"Ecco il tuo nome: {nome}");
                                    break;
                                default:
                                    System.Console.WriteLine($"Comando  '{comando}' non riconosciuto");
                                    break;
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Input non valido. Inserisci un comando");
                        }

                        System.Console.WriteLine("\nInserisci un altro comando:");
                    }
                    break; //break all'interno di uno statement switch interrompe l'esecuzione del blocco switch e esce dallo switch. 

                case "2":
                    bool condizione = true;
                    while (condizione)
                    {
                    //Console.Clear(); // Pulisce la console ad ogni iterazione
                    Console.WriteLine("Menu di Selezione");
                    Console.WriteLine("1. Opzione Uno");
                    Console.WriteLine("2. Opzione Due");
                    Console.WriteLine("3. Opzione Tre");
                    Console.WriteLine("4. Torna al menu principale");

                    Console.Write("Inserisci il numero dell'opzione desiderata: ");
                    string input2 = Console.ReadLine();

                    switch (input2) 
                    {
                        case "1": //se il valore della variabile dentro le parentesi tonde dello switch è quello scritto dopo il case, esegue, altrimenti passa al prossimo case
                            Console.WriteLine("Hai selezionato l'Opzione Uno");
                            // Aggiungi qui la logica per l'Opzione Uno
                            break;
                        case "2":
                            Console.WriteLine("Hai selezionato l'Opzione Due");
                            // Aggiungi qui la logica per l'Opzione Due
                            break;
                        case "3":
                            Console.WriteLine("Hai selezionato l'Opzione Tre");
                            // Aggiungi qui la logica per l'Opzione Tre
                            break;
                        case "4":
                            Console.WriteLine("Torna al menu principale...");
                            condizione=false;
                            break; // Esce dal programma
                        default:
                            Console.WriteLine("Selezione non valida. Riprova.");
                            break;
                    }
                    if(condizione) //cosi se premo il 4 mi evita ciò che lo fa già lo switch principale
                    {
                    Console.WriteLine("Premi un tasto per continuare");
                    Console.ReadKey(); // Aspetta che l'utente prema un tasto prima di continuare
                    }
                }
                break;

                case "3":
                    Console.Clear();
                    break;

                case "4":
                    Console.Beep();
                    break;

                case "5":
                    try
                    {
                        System.Console.WriteLine("Inserisci la frequenza");
                        int freq = Int32.Parse(Console.ReadLine());

                        System.Console.WriteLine("Inserisci durata in ms");
                        int ms = Int32.Parse(Console.ReadLine());
                        Console.Beep(freq, ms);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("input non valido");
                    }
                    break;

                case "6":
                    System.Console.WriteLine("Trascina un file qui e premi invio");
                    string filePath = Console.ReadLine().Trim('"'); //creo il percorso per aprire il file, rimuovendo le virgolette che possono apparire nel percorso

                    try
                    {
                        string content = File.ReadAllText(filePath); //legge tutte le righe del file e le memorizza nella stringa content
                        System.Console.WriteLine("Contenuto del file:");
                        System.Console.WriteLine(content);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine($"Si è verificato un errore: {ex.Message}");
                    }
                    break;

                case "e":
                    continua = false;//return; 
                    break;

                default:
                    System.Console.WriteLine("Opzione errata:");
                    break;

            }

            if (continua)
            {
                System.Console.WriteLine("Premi un tasto per contiuare...");
                Console.ReadKey();
            }

        } while (continua);

    }
}
```


### 30 - Lambda 

```c#
 //In C#, le espressioni lambda sono funzioni anonime che possono essere utilizzate per definire brevi blocchi di codice.

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numeri = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // .where funge come un ciclo su ogni elemento della lista, Usa una lambda per sommare tutti gli elementi pari
        int sommaPari = numeri.Where(x => x % 2 == 0).Sum();//ritorna il numero se pari

        Console.WriteLine($"La somma dei numeri pari è: {sommaPari}");
    }
}

```

### 30.1 - Stesso es senza lambda

```c#
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numeri = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Filtra numeri pari
        List<int> numeriPari = FiltraNumeriPari(numeri);

        // Calcola la somma dei numeri pari
        int sommaPari = CalcolaSomma(numeriPari);

        Console.WriteLine($"La somma dei numeri pari è: {sommaPari}");
    }

    static List<int> FiltraNumeriPari(List<int> lista)
    {
        List<int> risultato = new List<int>();

        foreach (var numero in lista)
        {
            if (numero % 2 == 0)
            {
                risultato.Add(numero);
            }
        }

        return risultato;
    }

    static int CalcolaSomma(List<int> lista)
    {
        int somma = 0;

        foreach (var numero in lista)
        {
            somma += numero;
        }

        return somma;
    }
}
```

### 30.2 - Lambda es 2

```c#
List<string> fruits =
    new List<string> { "apple", "passionfruit", "banana", "mango",
                    "orange", "blueberry", "grape", "strawberry" };

IEnumerable<string> query = fruits.Where(fruit => fruit.Length < 6);

foreach (string fruit in query)
{
    Console.WriteLine(fruit);
}
/*
 This code produces the following output:

 apple
 mango
 grape
*/
```

### 31 - funzioni asincrone

```c#
/*
Quando usiamo la parola chiave await in C#, stiamo dicendo al programma di aspettare un po' prima di fare qualcos'altro.
Immagina che stai facendo una chiamata telefonica e devi aspettare che l'altra persona risponda. 
Invece di stare in silenzio e non fare nulla mentre aspetti, potresti fare altre cose come leggere un libro o controllare il tuo telefono. await funziona in modo simile.
await è utilizzata per aspettare il completamento di un'operazione asincrona prima di procedere oltre nel codice. 
Quando usiamo await con Task.Run(() => {  codice  }), stiamo dicendo al programma di iniziare l'esecuzione del blocco di codice in un modo particolare (asincrono) e nel frattempo fare altre cose. 
Anche se il thread principale attende il completamento dell'operazione asincrona tramite await, durante questo periodo può gestire altre attività, rispondere agli input dell'utente o eseguire
 operazioni concorrenti. 
 Asincronia: I Task consentono di eseguire operazioni in modo asincrono senza bloccare il thread principale del programma. Ciò è particolarmente utile per operazioni che richiedono tempo, come le operazioni di I/O o le chiamate di rete.
*/

using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Inizio del programma");

        // Esempio di operazione asincrona con Task.Run
        string risultato = await Task.Run(() =>
        {
            // Simuliamo un'operazione intensiva
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Passo {i + 1}...");
                Task.Delay(1000).Wait(); // Simula un ritardo di 1 secondo
            }

            return "Operazione asincrona completata!";
        });

        // Stampiamo il risultato dopo il completamento dell'operazione asincrona
        Console.WriteLine(risultato);

        Console.WriteLine("Fine del programma");
    }
}
```

### 31.2 - Esercizio Funzioni asincrone

```c#
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
```

### 31.3 - Altro es funzioni asincrone

```c#
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Inizio del programma");

        // Chiamata a una funzione asincrona
        Task funzioneAsincrona = EsempioFunzioneAsincrona();

        Console.WriteLine("Prima del ciclo");

        // Esegui un ciclo mentre aspetta il completamento della funzione asincrona EsempioFunzioneAsincrona()
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Ciclo {i + 1}");
            await Task.Delay(500); // Attendi 0.5 secondi prima di ogni iterazione perchè aspetta che finisca il delay
        }

        // Aspetta il completamento della funzione asincrona prima di proseguire oltre nel codice
        await funzioneAsincrona;

        Console.WriteLine("Fine del programma");
    }

    static async Task EsempioFunzioneAsincrona()
    {
        Console.WriteLine("Inizio della funzione asincrona");

        // Simulazione di un'attesa asincrona, ad esempio una richiesta a un servizio web
        await Task.Delay(2000);

        Console.WriteLine("Fine della funzione asincrona");
    }
}
```

### 31.4 - Altro es funzioni asincrone MIGLIORE

```c#

/*
        1)Chiamata alla prima funzione asincrona (EsempioFunzioneAsincrona):
        Il metodo EsempioFunzioneAsincrona viene avviato in modo asincrono, e Task.Delay(2000) simula un'attesa di 2 secondi.
        L'esecuzione del metodo Main continua immediatamente dopo la chiamata a EsempioFunzioneAsincrona, senza aspettare che l'operazione completi.

        2)Inizio del ciclo for e chiamata alla seconda funzione asincrona (EsempioFunzioneAsincrona):
        Mentre l'operazione1 si sta eseguendo in background, il ciclo for viene eseguito, stampando i messaggi sulla console ogni 0.5 secondi con altro op async await Task.Delay(500);
        (await non blocca il thread principale; invece, sospende temporaneamente l'esecuzione del metodo in cui si trova)
        Nel frattempo, EsempioFunzioneAsincrona viene chiamato nuovamente per operazione2 e inizia a eseguire un'altra op asincrona di attesa di 2 secondi.

        3) Continuazione del ciclo e attesa asincrona:
        Il ciclo for continua a eseguire le sue iterazioni ogni 0.5 secondi mentre operazione1 e operazione2 sono ancora in eseuzione.

        4)Aspetta il completamento di operazione1 e operazione2 senza andare avanti con le istruzioni:
        await operazione1;
        await operazione2;

        -- il tipo di ritorno può essere Task (se non restituisce alcun valore) o Task<T> (se restituisce un valore di tipo T) --
        */

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

        // Continua ad eseguire altre operazioni asincrone mentre aspetta il completamento delle prime due
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Altre operazioni in corso... Ciclo {i + 1}");
            await Task.Delay(500); // // ulteriore operazione asincrona che esegue un ritardo di 0.5 secondi. è asincrona perché impiega un certo periodo di tempo per completarsi  e durante questo periodo, anziché bloccare il thread, consente al thread principale di continuare con altre attività. anche il ciclo for prende tempo. ma il delay è async per natura.
            //l'await attende il codice dentro il ciclo for prima di reiterare ma non blocca gli altri threads in esecuzione.
            //'await non blocca il thread principale; invece, sospende temporaneamente l'esecuzione del metodo o flusso in cui si trova, consentendo al thread principale di continuare con altre attività. è come se x ogni nuova op asincrona si creasse un branch/flusso separato in + e ogni await si riferisce a quel branch. vedi il flusso come branch.
        }

        // Aspetta il completamento delle due operazioni asincrone
        await operazione1; // non blocca operazione2. L'await in C# consente di aspettare il completamento di un'operazione asincrona specifica (o meglio di quel flusso di istruzioni)
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
```
 
### 31.5 - SImulazione Esercizio funzioni asincrone in aula

```c#
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        int timeoutInSeconds = 5; //inizializza il tempo di timeout
        System.Console.WriteLine($"Inserisci un input entro {timeoutInSeconds}");

        bool inputReceived = false; //inizializza input come non ricevuto finchè non si verifica il Console.KeyAvailable
        string? input = ""; //inizializza una variabile di tipo string chiamata input con una stringa vuota così può assegnare un valore ad input
        //all'interno del ciclo e poi accedere a quel valore anche a ldi fuori del cicl (all'interno dell'intera funzione Main)
        DateTime endTime = DateTime.Now.AddSeconds(timeoutInSeconds); // DateTime.Now restituisce l'ora corrente. Il metodo AddSeconds(timeoutInSeconds)
        //aggiunge il numero specificato di secondi (in questo caso, il valore della variabile timeoutInSeconds) all'ora corrente. 
        //Il risultato è un DateTime che rappresenta il momento esatto quando il tempo di attesa è in scadenza

        while(DateTime.Now < endTime)// Il ciclo while (DateTime.Now < endTime) continua a eseguirsi finchè l'ora corrente (DateTime.Now) è inferiore a 
        //endTime. QUesto significa che il ciclo continuerà a girare per la durata specificata da timeoutinSeconds (5)
        {
            if(Console.KeyAvailable) //viene utilizzato per verificare se è stato premuto un tasto, permettendo al programma di reagire immediatamente
            //all'input dell'utente senza bloccare l'esecuzione
            {
                input = Console.ReadLine();
                inputReceived = true; //dato che il valore di input viene controllato dopo il ciclo per determinare se l'utente ha fornito un input,
                //inizializzandola con una stringa vuota si stabilisce un valore di partenza come noto. Se input rimane una stringa vuota dopo il ciclo,
                //significa che l'utente non ha inserito alcun dato
                break;
            }

            Thread.Sleep(100); //piccola pausa per ridurre il carico sulla cpu
        }
        if (inputReceived)
        {
            System.Console.WriteLine($"Hai inserito: {input}");
        }
        else
        {
            System.Console.WriteLine("Tempo scaduto");
        }
    }
}
```

### 31.6 - Esercizio Funzioni asincrone in aula


```c#
//inputTask è un task che attende l'input dell'utente
//delayTask è un task che attende per un periodo di tempo specificato (5 secondi in questo caso)


class Program
{
    static async Task Main(string[] args) //L'utilizzo di async è necessario perché il metodo Main contiene operazioni asincrone come Task.Run, Task.Delay e await. Quando si utilizzano operazioni asincrone in un metodo, è necessario dichiarare tale metodo come async.
    {
        int timeoutInSeconds = 5; //imposta il tempo di attesa in secondi

        Task inputTask = Task.Run(() => //oggetto che esegue codice nel blocco quando eseguito
        {
            Console.WriteLine($"Inserisci un input entro {timeoutInSeconds} secondi:");
            return Console.ReadLine();
        });

        //La chiamata Task.Delay restituisce un task che si completa dopo il periodo di ritardo specificato. timespan sono i secondi del delay
        Task delayTask = Task.Delay(TimeSpan.FromSeconds(timeoutInSeconds)); 

        //Questa istruzione attende che uno qualsiasi dei due task (inputTask o delayTask) venga completato. L'operazione await restituirà il task che si completa per primo.
        //== inputTask: Viene verificato se il task completato è inputTask. Questo significa che l'utente ha inserito un input prima che scadesse il tempo.
        if (await Task.WhenAny(inputTask,delayTask) == inputTask)
        {
            //l'utente ha inserito un input
            string input = await (inputTask as Task<string>);
            System.Console.WriteLine($"Hai inserito: {input}");//questo serve solo a displayare l'input immesso
        }
        else
        {
            //il tempo è scaduto
            System.Console.WriteLine("tempo scaduto");
        }
    }
}

/*
Task è parte del namespace System.Threading.Tasks e rappresenta un'attività asincrona in C#. È utilizzato per gestire operazioni asincrone e parallele in modo efficiente. Il framework .NET offre molte funzionalità per la gestione delle attività, tra cui Task.Run che ti permette di eseguire un blocco di codice in modo asincrono.

Input utente: L'operazione Console.ReadLine() è una chiamata bloccante che attende che l'utente inserisca un input. Utilizzando Task.Run, questa operazione può essere eseguita in modo asincrono in un altro thread, consentendo al programma di continuare ad eseguire altre operazioni mentre è in attesa dell'input utente.

Ritardo di tempo: L'operazione Task.Delay è utilizzata per creare un ritardo di tempo senza bloccare il thread principale. Anche in questo caso, l'utilizzo di operazioni asincrone consente al programma di procedere con altre operazioni mentre aspetta che scada il tempo.
il tutto serve a compiere in contemporanea le azioni di attesa input utente e conteggio del tempo

 1)Utilizzando Task.Run e Console.ReadLine(), l'input dell'utente viene gestito in modo asincrono in un thread separato, permettendo al programma di continuare ad eseguire altre operazioni nel frattempo.
 2)Conteggio del tempo: Utilizzando Task.Delay, il programma crea un task che rappresenta un ritardo di tempo. Nel frattempo, il thread principale del programma può continuare ad eseguire altre operazioni.
 3)Il punto chiave è l'utilizzo di Task.WhenAny con l'operatore await. Questo permette al programma di attendere che uno qualsiasi dei due task (input utente o ritardo di tempo) venga completato. Quando uno dei due si completa, il programma può reagire di conseguenza: se l'utente ha inserito un input, lo legge e lo mostra; altrimenti, se il tempo è scaduto, mostra un messaggio di "tempo scaduto".

 Task.WhenAny(inputTask, delayTask) aspetta che uno qualsiasi dei due task (inputTask o delayTask) venga completato.
 L'await viene utilizzato per ottenere il risultato di questa operazione asincrona.
 La condizione == inputTask verifica se il task completato è inputTask.

 Quindi, il blocco di codice all'interno dell'if verrà eseguito solo se inputTask è stato completato prima di delayTask. In altre parole, se l'utente ha inserito un input prima che il tempo scadesse, il blocco di codice all'interno dell'if verrà eseguito.
 */
```

### 32 - classe Random

```c#
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
```

### 32.1 - classe Random con somma evidenziata in verde e pause

```c#
class Program
{
    static void Main()
    {
        Random random = new Random();
        int somma = 0;
        for (int i = 0; i < 10; i++) //reitera 10 volte
        {
            int numero = random.Next(1,11); //genera numero casuale tra 1 e 10
            System.Console.Write("numero generato: "); //.Write per non andare a capo
            Console.ForegroundColor = ConsoleColor.Green; //cambio colore dei caratteri displayati dal terminale
            System.Console.WriteLine($"{numero}");
            Thread.Sleep(1000); //sono delle pause di n secondi che fa fare al programma prima di riprendere con l'esecuzione
            somma += numero; //somma = somma + numero
            Console.ResetColor(); //resetto colore caratteri
            
            System.Console.WriteLine($"La somma è {somma}");
            Thread.Sleep(1000);
        }
    }
}
```

### 32.2 - Random su array

```c#
class Program
{
    static void Main()
    {
        string[] nomi = ["Mario", "Luigi", "Giovanni"]; //array di stringhe
        Random random = new Random();
        int indice = random.Next(0,nomi.Length);
        System.Console.WriteLine($"Il nome sorteggiato è {nomi[indice]}");  
    }
}
```

### 32.3 - Random su lista

```c#
class Program
{
    static void Main()
    {
        List<String> nomi = ["Alex", "Simone", "Fabio", "Giada", "Carlo", "Dylan", "Natalia", "Alessandro"]; 
        Random random = new Random();
        int indice = random.Next(0,nomi.Count);
        System.Console.WriteLine($"Il nome sorteggiato è {nomi[indice]}");  
    }
}
```

### 33 - Fizz Buzz

```c#
class Program  //div per 3 stampi Fizz, per 5 stampi buzz, per entrambi stampi FizzBuzz
{
    static void Main()
    {
        int[] numeri = new int[100];
        for (int i = 0; i < (numeri.Length); i++)
        {
            numeri[i] = i+1;
        }

        foreach (int numero in numeri)
        {
            

             if (numero % 3 == 0 && numero % 5 == 0)
            {
                System.Console.WriteLine($"{numero} -> Fizz Buzz");

            }

            else if (numero % 3 == 0)
            {
                System.Console.WriteLine($"{numero} -> Fizz");

            }
            else if (numero % 5 == 0)
            {
                System.Console.WriteLine($"{numero} -> Buzz");

            }
            else
            {
                System.Console.WriteLine(numero);

            }

        }
    }
}
```

### 33.1 - Fizz Buzz con Random

```c#
class Program  //div per 3 stampi Fizz, per 5 stampi buzz, per entrambi stampi FizzBuzz
{
    static void Main()
    {
        Random random = new Random();
        int numeroSorteggiato = random.Next(0,101);
        //System.Console.WriteLine($"Il numero sorteggiato è {numeroSorteggiato}");  

        if (numeroSorteggiato % 3 == 0 && numeroSorteggiato % 5 == 0)
            {
                System.Console.WriteLine($"{numeroSorteggiato} -> Fizz Buzz");
            }
        else if (numeroSorteggiato % 3 == 0)
            {
                System.Console.WriteLine($"{numeroSorteggiato} -> Fizz");

            }
            else if (numeroSorteggiato % 5 == 0)
            {
                System.Console.WriteLine($"{numeroSorteggiato} -> Buzz");

            }
            else
            {
                System.Console.WriteLine(numeroSorteggiato);

            }
    }
}
```

### 33.2 - FizzBuzz con liste

```c#
class Program  
{
    static void Main()
    {
        List<int> Fizz = new List<int>();
        List<int> Buzz = new List<int>();
        List<int> FizzBuzz = new List<int>();

        while ((Fizz.Count + Buzz.Count + FizzBuzz.Count) < 100) //essendo che la prima iterazione parte da quando la lista è a 0, lo fa 100 volte
        {
            Random random = new Random();
            int numeroSorteggiato = random.Next(0, 101);
            //System.Console.WriteLine($"Il numero sorteggiato è {numeroSorteggiato}");  

            if (numeroSorteggiato % 3 == 0 && numeroSorteggiato % 5 == 0)
            {
                System.Console.WriteLine($"{numeroSorteggiato} -> Fizz Buzz");
                 Thread.Sleep(2000);
                FizzBuzz.Add(numeroSorteggiato);
                string joinFizzBuzz = string.Join(", ", FizzBuzz);
                System.Console.WriteLine("Lista FizzBuzz :" + joinFizzBuzz);
                 Thread.Sleep(2000);
                
            }
            else if (numeroSorteggiato % 3 == 0)
            {
                System.Console.WriteLine($"{numeroSorteggiato} -> Fizz");
                 Thread.Sleep(2000);
                Fizz.Add(numeroSorteggiato);
                string joinFizz = string.Join(", ", Fizz);
                System.Console.WriteLine("Lista Fizz :" + joinFizz);
                 Thread.Sleep(2000);
                
            }
            else if (numeroSorteggiato % 5 == 0)
            {
                System.Console.WriteLine($"{numeroSorteggiato} -> Buzz");
                 Thread.Sleep(2000);
                Buzz.Add(numeroSorteggiato);
                string joinBuzz = string.Join(", ", Buzz);
                System.Console.WriteLine("Lista Buzz :" + joinBuzz);
                 Thread.Sleep(2000);
            }
            else
            {
                System.Console.WriteLine(numeroSorteggiato);

            }
        }
        System.Console.WriteLine(Fizz.Count + Buzz.Count + FizzBuzz.Count);   
        System.Console.WriteLine("lista Fizz senza duplicati e ordinata:");
        List<int> fizzNoDuplicati = Fizz.Distinct().ToList();
        System.Console.WriteLine(fizzNoDuplicati);
        fizzNoDuplicati.Sort();
        System.Console.WriteLine(string.Join(", ", fizzNoDuplicati));
    }
}
```
```c#
### BONUS - es mio dowload immagine da url

using System;
using System.IO;
using System.Net.Http;

class Program
{
    static void Main()
    {
        //// Definisci l'URL dell'immagine che vuoi scaricare (tasto destro su immagine e apri in nuova scheda)
        string imageUrl = "https://services.meteored.com/img/article/il-telescopio-spaziale-james-webb-ci-regala-incredibili-immagini-del-mostro-verde-1705007220340_1024.jpg";

        // Specifica il percorso in cui salvare l'immagine scaricata
        string outputPath = @"C:/Users/DOTNET/Documents/Corso-Dotnet-2024/CORSO-DOTNET-2024/esercitazioni-dotnet-2024/esercitazione1/imgs";

if (!Directory.Exists(outputPath))
{
    Directory.CreateDirectory(outputPath);
}

        DownloadImage(imageUrl, outputPath);

        Console.WriteLine("Immagine scaricata con successo.");
        Console.ReadLine();
    }

    static void DownloadImage(string url, string outputPath)
    {
        // Crea un'istanza della classe HttpClient per effettuare richieste HTTP
        using (HttpClient client = new HttpClient())
        {
            // Scarica i byte dell'immagine dall'URL
            byte[] imageData = client.GetByteArrayAsync(url).Result;

            // Salva i byte dell'immagine in un file
            File.WriteAllBytes(outputPath, imageData);
        }
    }
}
```

### 34 - calcolatrice

```c#
using System;
using System.IO;
using System.Net.Http;

class Program
{
    static void Main()
    {

        //metodo che chieda il primo numero, metodo che chieda il secondo numero e un metodo che chieda l'operazione da fare. getire ecc /0, 1/2 da 0..
        System.Console.WriteLine("Inserisci il primo numero");
        int number = Convert.ToInt32(Console.ReadLine());

        System.Console.WriteLine("Inserisci il secondo numero");
        int number2 = Convert.ToInt32(Console.ReadLine());

        System.Console.WriteLine("Digita: 1 per somma, 2 per sottrazione, 3 per moltiplicazione, 4 per divisione");
        int input = Convert.ToInt32(Console.ReadLine());


        //bool condizione = true;
        while (true)
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
```

### 34.1 - Cacolatrice con try cathc

```c#
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
```

### 35 - Indovina Numero

```c#
class Program //implementare: numero di tentativi quando indoviniamo, se inseriamo numero + alto o basso ci da suggerimenti dicendoci se il numero è + alto o + basso
{
    static void Main()
    {
       
        Random random = new Random();

        int numeroDaIndovinare = random.Next(1,101); //genera numero casuale tra 1 e 10;
        int numeroTentativiMax = 10;
        int contatoreTentativi = 0;
        int rangeIniziale = 80;
        // int numeroInferioreRange = numeroDaIndovinare - (rangeIniziale/2);
        int numeroInferioreRange = 0;
        int numeroSuperioreRange = 0;

        
        System.Console.WriteLine("Trova il numero da indovinare: è compreso tra 1 e 100. Hai 10 tentativi!");
        System.Console.WriteLine("Inserisci il numero");
        int number = Convert.ToInt32(Console.ReadLine());

       
        
        while(number!=numeroDaIndovinare && numeroTentativiMax>0)
        {
            System.Console.WriteLine("Sbagliato! Ritenta");
            //number = Convert.ToInt32(Console.ReadLine());
            
            numeroTentativiMax --;
            contatoreTentativi++;
            if(number<numeroDaIndovinare)
            {
                System.Console.WriteLine("prova con un numero più alto ;)");
            }
            else if(number>numeroDaIndovinare)
            {
                System.Console.WriteLine("prova con un numero più basso ;)");
            }
            

            Random random2 = new Random();
                
            //voglio che generi un range pari al rangeIniziale displayando il numero inferiore del range e il numero maggiore del range
            while(numeroInferioreRange > numeroDaIndovinare || numeroSuperioreRange < numeroDaIndovinare || (numeroSuperioreRange - numeroInferioreRange)!=rangeIniziale)
            {
                numeroInferioreRange = random2.Next(1,101);
                numeroSuperioreRange = random2.Next(1,101);
            }
            //System.Console.WriteLine("Sbagliato! Ritenta");
            System.Console.WriteLine("il numero da indovinare si trova tra " + numeroInferioreRange + " e " + numeroSuperioreRange);
            rangeIniziale -= 10; //restringe il range di 10 a ogni tentativo
            if(rangeIniziale<0)
            {
                System.Console.WriteLine("hai perso :(");
                return;
            }
            number = Convert.ToInt32(Console.ReadLine());
            
        }

        if(number==numeroDaIndovinare){
            System.Console.WriteLine("giusto bravo");
            numeroTentativiMax--;
            contatoreTentativi++;
            System.Console.WriteLine($"numero di tentativi rimasti = {numeroTentativiMax}");
            System.Console.WriteLine($"numero di tentativi = {contatoreTentativi}");
        }  
    }
}
```

### 35.1 - Estrazione roulette con calcolo vincita/perdita e balance

```c#
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
```

###

```c#
//implementare: numero di tentativi quando indoviniamo, se inseriamo numero + alto o basso ci da suggerimenti dicendoci se il numero è + alto o + basso
//input utente per fargli mettere una moneta
//ricalcolare ogni volta il numero di monete presenti nella macchinetta

class Program //roulette
{ 
    static void Main()
    {
        double balance=100.0;
        double importoScommessa=0;
        //int punteggio = 0;
        int quantitaNumeriScelti = 0;
        double probabilitaVittoria = (10 * quantitaNumeriScelti) ;
        
        

        while (true)
        {
            Random random = new Random();
            int numeroDaInd = random.Next(1, 11);
            Console.WriteLine("\nIndovina il numero sorteggiato");
            
            while(true) //ciclo che mi richiede l'importo finchè non è valido, ovvero minore del mio saldo
            {
                System.Console.WriteLine("Scegli l'importo da scommettere");
                importoScommessa = Convert.ToDouble(Console.ReadLine());
                if(importoScommessa<=balance)
                {
                    break;
                }
            }

            //sottraggo l'importo dal balance
            balance -= importoScommessa;

            Console.WriteLine("Scegli su quali numeri scommettere da 1 a 10 (inserisci i numeri separati da virgole):");
            string numeroScelto = Console.ReadLine();

            

            // Divido la stringa usando il carattere ','
            
            string[] numeriStringa = numeroScelto.Split(',');
            // Console.WriteLine(numeriStringa[1]);

            // Creo un array di interi per memorizzare i numeri e memorizzo la quantita di numeri che gioco 
            //x calcolare poi il payout correttamente
            int[] numeriArray = new int[numeriStringa.Length];

            quantitaNumeriScelti = numeriArray.Length;
            
            //per ogni stringa di numeriStringa la metto nell'array numeriString convertita in int
            for(int i=0; i<numeriStringa.Length; i++)
            {
                numeriArray[i] =  Int32.Parse(numeriStringa[i]);
                //Console.WriteLine(numeriArray[i]);
            }
            //paragono i numeri scelti col numero estratto col random
            foreach(int numero in numeriArray)
            {
                if(numero==numeroDaInd)
                {
                    System.Console.WriteLine("è uscito il " + numeroDaInd);
                    
                    
                    double percentualeGuadagno = 10.0/quantitaNumeriScelti;
                    
                    double guadagno = importoScommessa * percentualeGuadagno;
                    balance += guadagno;
                    System.Console.WriteLine("Hai vinto " + guadagno);
                    break;
                }   
                //va subito qui ogni volta che sbaglia
                else{
                    System.Console.WriteLine("è uscito il numero " + numeroDaInd);
                    System.Console.WriteLine("Hai perso :(");
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
``` 

### eccezioni

Gli esempi piu comuni sono:
- System.IO.IOException ( si verifica quando si tenta di accedere a un file che non esiste)
- System.IndexOutOfRangeException (quando si tenta di accedere ad elemento di un array con indice non valido)
- System.NullReferenceException (si verifica quando si tenta di accedere a un oggetto null)
- System.OutOfMemoryException (si verifica quando non c'è abbastanza memoria disponibile)
- System.StackOverflowException (si verifica quando la pila è piena)

Eccezioni generate dal programmatore:

- System.ArgumentException (si verifica quando un argomento di un metodo non è valido)
- System.ArgumentNullException (si verifica quando un argomento di un metodo è null)
- System.ArgumentOutOfRangeException (si verifica quando un argomento di un metodo è fuori dal range consentito)
- System.DividedByZeroException (quando si tenta di dividere per 0)
- System.InvalidCastException (si verifica quando si tenta di convertire un tipo in un altro tipo non valido)
- System.NotImplementedException (si verifica quando si tenta di usare un metodo non implementato)


Si usano 3 tipi:
 - try-cath-finally -> il finally viene sempre eseguito
 - try-catch-finally-throw -> il finally viene eseguito solo se non viene generata un exxezione
 - try-parse
    
```c#
try
{
    //codice che può generare un eccezione
}
catch
{
    //codice che gestisce l'eccezione
}
finally
{
    //codice che viene sempre eseguito
}

try
{
    //codice che può generare un eccezione
}
catch
{
    //codice che gestisce l'eccezione
    throw;
}
finally
{
    //codice che viene eseguito solo se non viene generata un'eccezione
}

```

- Il try-parse lo si usa quando invece che gestire l'eccezione si vuole solo controllare se l'eccezioni è andata a buon fine o no (dando true se si e false se no invece che un eccezione)

### vogliamo verificare che l'utente inserisca un numero tra 1 e 10

```c#
using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Inserisci un numero tra 1 e 10");
        try{
        int numero = int.Parse(Console.ReadLine()!);
        if(numero<1 || numero>10)
        {
            Console.WriteLine("Il numero non è valido");
            return;
        }

        Console.WriteLine($"Il numero inserito è {numero}");
        
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Il numero non è valido!!");
            return;
        }
    }
}
```

### vogliamo gestire System.IO.IOException (si vierifica quando si tenta di accedere a un file che non esiste)

```c#

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string contenuto = File.ReadAllText("file.txt"); //il file deve essere nella stessa cartella del programma
            Console.WriteLine(contenuto);
        }
        catch(Exception e)
        {
            System.Console.WriteLine("Il file non esiste");
            return;
        }
    }
}

```
### gestiamo System.IndexOutOfRangeException

```c#
class Program
{
    static void Main(string[] args)
    {
        int [] numeri = {1,2,3};
        try
        {
           System.Console.WriteLine(numeri[2]); //3
           System.Console.WriteLine(numeri[3]); //indice non valido
           System.Console.WriteLine(numeri[1]); // non stampa perchè entrato nel catch
        }
        catch(Exception e)
        {
            System.Console.WriteLine("Indice non valido");
            System.Console.WriteLine("errore non trattato: " + e.Message);
            return;
        }
        finally
        {
            System.Console.WriteLine(numeri[0]); //lo stampa 
        }
    }
}
```

### Vogliamo gestire System.NullReferenceException ( si verifica quando il reference punta a un field di un oggetto che è null)

```c#
class Program
{
    static void Main(string[] args)
    {
        string nome = null; //stringa senza nulla
        try
        {
            System.Console.WriteLine(nome.Length);
        }
        catch(Exception e)
        {
            System.Console.WriteLine("Il nome non è valido");
            System.Console.WriteLine("errore non trattato: " + e.Message);
            return;
        }
    }
}
```
### System.OutOfMemoryException

```c#
class Program
{
    static void Main(string[] args)
    {
        try
        {
            int [] numeri = new int[int.MaxValue]; //è il max value che può contenere un int, e un array non ci arriva
        }
        catch(Exception e)
        {
            System.Console.WriteLine("Memoria insufficiente");
            System.Console.WriteLine(e.Message); //messaggio dell'eccezione
            System.Console.WriteLine(e.Data); //dati aggiuntivi dell'eccezione
            System.Console.WriteLine(e.HResult); //codice numerico dell'eccezione
            return;
        }
    }
}
```

### Stack Overflow exception

```c#
class Program
{
    static void Main(string[] args)
    {
        try
        {
            StackOverflow(); // il metodo viene chiamato ricorsivamente 24000 volte e poi va in eccezione
        }
        catch(Exception e)
        {
            System.Console.WriteLine("StackOverflow");
            System.Console.WriteLine("errore non trattato: " + e.Message);
            return;
        }

        static void StackOverflow()
        {
            StackOverflow();
        }
    }
}
```

### Errore di conversione System.ArgumentException

```c#
class Program
{
    static void Main(string[] args)
    {
       try
       {
          int numero = int.Parse("ciao"); //il metodo parse genera un'eccezione perchè ciao non è un numero
       }
       catch(Exception e)
       {
            System.Console.WriteLine("il numero non è valido");
            System.Console.WriteLine("errore non trattato: " + e.Message);
            return;
       }
    }
}
```



```c#
class Program
{
    static void Main(string[] args)
    {
       try
       {
          int zero = 0;
          int numero = 1/zero; //errore
       }
       catch(Exception e)
       {
            System.Console.WriteLine("divisione per 0");
            System.Console.WriteLine("errore non trattato: " + e.Message);

            return;
       }
    }
}
```

```c#
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

            // while(true){
            // try{
            Console.WriteLine("Scegli su quali numeri scommettere da 1 a 10 (inserisci i numeri separati da virgole):");
            numeroScelto = Console.ReadLine();
            
            // }
            

            // Divido la stringa usando il carattere ','
            string[] numeriStringa = numeroScelto.Split(',');


            // Creo un array di interi per memorizzare i numeri e memorizzo la quantita di numeri che gioco 
            //x calcolare poi il payout correttamente
            int[] numeriArray = new int[numeriStringa.Length];

            quantitaNumeriScelti = numeriArray.Length;
            
            //per ogni stringa di numeriStringa la metto nell'array numeriString convertita in int
            for(int i=0; i<numeriStringa.Length; i++)
            {
                numeriArray[i] =  Int32.Parse(numeriStringa[i]);
                //Console.WriteLine(numeriArray[i]);
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

```

```c#



### simulazione roulette con try-catch e %vittorie e sconfitte

class Program //roulette , da implementare switch per puntare su pari e dispari, e implementare lo 0
{
    static void Main()
    {

        int vittorie = 0;
        int sconfitte = 0;

        //----------------------------------------

        double balance = 100.0;
        double importoScommessa = 0;
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
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("formato non valido");
                }
            }

            //sottraggo l'importo dal balance
            balance -= importoScommessa;

            while (true)
            {
                try
                {
                    Console.WriteLine("Scegli su quali numeri scommettere da 1 a 10 (inserisci i numeri separati da virgole):");
                    numeroScelto = Console.ReadLine();


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
                    System.Console.WriteLine("Hai vinto " + guadagno);
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
```


### Progetto con anche la scelta dei numeri pari/dispari e prima metà/seconda metà

```c#

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
                        // System.Console.WriteLine("scelta fatta!");
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
```