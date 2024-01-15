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