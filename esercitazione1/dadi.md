### gioco dell'oca
progetteremo un'applicazione per giocare al gioco dell'oca, da solo o in piu persone.


## Definizione dei Requisiti e Analisi:
- obiettivo: gioco di dell'oca che termina quando un utente vince
- target: tutti gli interessati
- L'applicazione deve mostrare un messaggio di errore se il giocatore inserisce input non validi. 
- l'applicazione deve essere in grado di gestire un numero massimo di 6 giocatori
- l'applicazione deve essere in grado di chiedere il nome dei giocatori uno ad uno in base al numero di giocatori inserito prima
- se si è da soli l'avversario sarà il computer
- L'applicazione deve tener conto del punteggio dei vari giocatori e dei nomi (utilizzando un txt in modo che anche se si spegne il computer si possa continuare la partita un altra volta)
- il programma deve essere in grado di gestire i turni di gioco basati sul lancio di 2 dadi per turno
- di default ogni giocatore tira una volta sola ed il turno passa al giocatore successivo, mentre se esce numero doppio dai dadi può tirare un altra volta (questo ogni volta che esce numero doppio)
- il programma gestisce le funzionalità delle caselle con regole specifiche: 
  - Casella 12 - Il Pozzo: Se atterri sulla casella 12, finisci nel pozzo e perdi un turno:
  - Casella 24 - Il Dottore: Se atterri qui, recupera immediatamente un turno perso. 
  - Casella 30 - Il Ponte: Salta due caselle in avanti.
  - Casella 33 - La Malasorte: Perdi un turno a causa di sfortuna.
  - Casella 37 - Ritorno alle origini: torna alla casella 18
  - Casella 38 - Rilancio arretrante: rilanci i dadi e ti muoverai indietro invece che avanti


- il programma farà scegliere ad ogni giocatore un'abilità iniziale tra:
 - decidi se avanzare di 1 quando atterri su una casella (prima di atterrare)
 - sposta avanti di uno un avversario a scelta
 - giochi con 3 dadi invece che con 2
 - i giocatori che atterrano su un multiplo di 4 ritornano alla posizione in cui erano prima del lancio


## Definizione di Strutture e Convenzioni:

- punteggio: casella attuale in cui si trova il giocatore con obiettivo di raggiungere la casella finale del percorso
- possibilità di giocare in più persone (fare una richiesta iniziale)
- eseguire regole in base alla casella in cui si finisce ()
- regole bonus: sposta l'avversario indietro/avanti di uno/due/ecc (non mi piacciono i giochi al 100% di fortuna senza )strategia.
  - sposta l'avversario avanti o indietro di un numero casuale tra 1 e 5
  - poter settare il tempo massimo di gioco (la partita finisce dopo n minuti, ed il giocatore + vicino all'obiettivo vince)


## sequenza del lavoro

1) creazione della possibilità di giocare in + persone (chiedo in quanti giocatori si è)    <input type="checkbox" checked>
2) chiedo i nomi dei giocatori e li salvo nelle relative variabili                          <input type="checkbox" checked>
3) creo la logica dietro al movimento sulle caselle: random x i dadi, spostamento sull'array con numeri caselle,  <input type="checkbox" checked>
4) creo la logica per giocare un turno alla volta in base al numero dei giocatori (numero doppio tira 2 volte)  <input type="checkbox" checked>
5) due numeri uguali non cambia il turno + vittoria se arrivo al numero esatto + torno indietro nelle caselle se lo supero
# IMPLEMENTAZIONI



## implementazione primarie 

- IMPO: se escono due numeri uguali dai dati si tira 2 volte e non cambia il turno
- IMPO: quando si arriva alla fine se si supera la casella di vittoria si torna indietro di n volte che la si è superata


## implementazioni secondarie 
- timer di gioco
- effetti caselle
- bonus