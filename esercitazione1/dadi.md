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
  - Casella 4  - Muoviti una posizione davanti al primo (le abilità della casella non si attivano)
  - Casella 8  - Teletrasporto 1: Spostati alla casella 14
  - Casella 10 - Raggiungimento: Spostati nella posizione del primo giocatore
  - Casella 12 - Il Pozzo: Se atterri sulla casella 12, finisci nel pozzo e perdi un turno:
  - Casella 15 - Teletrasporto: spostati alla posizione 23
  - Casella 16 - Cambio abilità: puoi scegliere se cambiare la tua abilità e tenerla fino a fine gioco
  - Casella 17 - Ruba per il prossimo giro l'abilità di un giocatore, quel giocatore la perderà per il prossimo turno e te la avrai in aggiunta alla tua
  - Casella 24 - Il Dottore: Se atterri qui, recupera immediatamente un turno perso. 
  - Casella 26 - Disabilitante: Il giocatore che finisce qui perde le sue abilità fino a fine partita
  - Casella 29 - Lo scambio: Scegli un giocatore. Scambiatevi di posizione sulla scacchiera.
  - Casella 30 - Il Ponte: Salta due caselle in avanti.
  - Casella 33 - La Malasorte: Perdi un turno a causa di sfortuna.
  - Casella 37 - Ritorno alle origini: torna alla casella 18
  - Casella 38 - Rilancio arretrante: rilanci i dadi e ti muoverai indietro invece che avanti
  - Casella 42 - Torna all'inizio
  - Casella 46 - Vittoria: Hai vinto!


- il programma farà scegliere ad ogni giocatore un'abilità iniziale tra:
  - Controllo: decidi se avanzare di 1 quando atterri su una casella (prima di atterrare)
  - sposta avanti di uno un avversario a scelta
  - giochi con 1, 2 o 3 dadi invece che con 2 ogni tiro (scegli tu)
  - i giocatori che atterrano su un multiplo di 4 ritornano alla posizione in cui erano prima del lancio
  - ogni giro decidi per un giocatore se farlo rilanciare o meno prima che atterri sulla casella
  - se un gicatore si sposta per via di un abilità quel giocatore deve spostarsi indietro di 4 dopo esser atterrato sulla casella 
  - Sei immune alla abilità degli altri giocatori e delle caselle che vuoi che non si attivino
  - possono esser tirati al massimo 2 dadi per giocatore
  - disabilità l'abilità di un giocatore (puoi scegliere ogni giro un nuovo giocatore)


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

- IMPO: se escono due numeri uguali dai dati si tira 2 volte e non cambia il turno <input type="checkbox" checked>
- IMPO: far visualizzare visivamente la situazione nelle caselle storandola in un txt/csv


## implementazioni secondarie 
- timer di gioco
- effetti caselle
- bonus
- IMPO: quando si arriva alla fine se si supera la casella di vittoria si torna indietro di n volte che la si è superata