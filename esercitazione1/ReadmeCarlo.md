stabilire gli obiettivi specifici (valutare l'usabilità e capire le esigenze degli utenti)

identificare i criteri di successo (quali risultati ti soddisfano)

segnalare problemi e suggerimenti 

comunicazione efficace, condividi le tue opinioni in modo onesto e dettagliato

utilizza strumenti come Jira o Trello per rimanere in comunicazione con i collaboratori
e tenere traccia di ciò che hai già fatto, stai facendo, devi ancora fare

riconoscimento e ringraziamento per i beta tester (molto gradito)




COSE IMPORTANTI 

- il metodo CalcolaPercentuale lo puoi definire fuori dal while (in realtà anche fuori dal Main) per poterlo riutilizzare (o in generale per ordine)    OK

- quando scegli quanto scommettere avrebbe senso vedere anche quanto balance ti rimane (o magari metterlo nel messaggio di errore quando uno prova a scommettere di più)     OK

- quello del pari o dispari si può fare un controllo          NI
  if (numeroEstratto % 2 = 0)   
  senza dover fare l'array di tutti i numeri pari

MEDIE 

- al primo giro la percentuale di vittorie e sconfitte è ovviamente zero quindi si può non scrivere        OK
- mettere un limite alle cifre o comunque alle partite (con le moltiplicazioni vengono numeri tipo 1.666666666666668 e se perdi 1.66 rimani con 0.006666666668)
  puoi mettere un controllo tipo 
  if (balance < 0.01) 
  { non puoi più giocare }


CAZZATINE

- ci sono varie quick fix suggerite direttamente da VS Code a inizio codice
  molte delle quali sono semplicemente che non serve dare un valore iniziale per poi sovrascriverlo alle variabili

- a riga 86 "3: numero singoli" è un errore di battitura ma mi dà l'idea che potresti fare due casi: 1. numero singolo e 2. numeri singoli      OK

- Int32.Parse(Console.ReadLine()); ti segnala un warning che si risolve semplicemente mettendo ! alla fine prima del punto e virgola      OK

- puoi essere più chiaro nella spiegazione del tipo di scommessa al primo giro e in generale nei messaggi all'utente, ad esempio a riga 106
  "prima metà(1 a 5) o seconda metà(6 a 10)?"
  potrebbe diventare " il numero estratto appartiene alla prima metà o alla seconda? "

- a riga 110                   OK  -> mancava il default, se qua mettevo 3 me lo prendeva comunque

        case 1:
            System.Console.WriteLine("scelta fatta!");
            break;
        case 2:
            System.Console.WriteLine("scelta fatta!");
            break;

    puoi scrivere direttamente 

        case 1: case 2: 
           System.Console.WriteLine("scelta fatta!");
           break;

- a riga 126 
                System.Console.WriteLine("input non valido");
                System.Console.WriteLine(); 

        puoi scrivere 
                System.Console.WriteLine("input non valido \n");
        
- 